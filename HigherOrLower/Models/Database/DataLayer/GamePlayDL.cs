using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	public class GamePlayDL
	{
		private readonly IHigherOrLowerDataAccessor data;

		public GamePlayDL(IHigherOrLowerDataAccessor data)
		{
			this.data = data;
		}

		public GamePlay GetUserCurrentGamePlay(int currentGamePlayId)
		{
			GamePlay gamePlay = null;

			if (currentGamePlayId > 0)
			{
				gamePlay = this.data.GamePlays.Get(new QueryOptions<GamePlay>()
				{
					Includes = "Turns.Turn",
					Where = p => p.GamePlayId == currentGamePlayId
				});
				foreach (var turn in gamePlay.Turns)
				{
					var card = this.data.PlayingCards.Get(1);
					turn.Turn.ActionType = this.data.ActionTypes.Get(turn.Turn.ActionTypeId);
					turn.Turn.GuessType = turn.Turn.GuessTypeId != null ? this.data.GuessTypes.Get(turn.Turn.GuessTypeId.Value) : null;
					turn.Turn.ShowingCard = this.data.PlayingCards.Get(new QueryOptions<PlayingCard>() { Where = p => p.PlayingCardId == turn.Turn.ShowingCardId });
					turn.Turn.FlippedCard = turn.Turn.FlippedCardId != null ? this.data.PlayingCards.Get(turn.Turn.FlippedCardId.Value) : null;
				}
			}

			return gamePlay;
		}

		public GamePlay InitializeNewGamePlayFor(User user)
		{
			var gamePlay = new GamePlay
			{
				UserId = user.Id
			};
			this.data.GamePlays.Insert(gamePlay);
			this.data.Save();

			var initialTurn = gamePlay.GetInitialTurn();
			initialTurn.FlippedCardId = new PlayingCardDL(data).GetNextShuffledCardNotAlreadyShown(gamePlay.GamePlayId).PlayingCardId;
			this.data.Turns.Insert(initialTurn);
			this.data.Save();

			this.saveGamePlayTurn(gamePlay.GamePlayId, initialTurn.TurnId);

			return gamePlay;
		}

		public void HandleGuess(int gamePlayId, int showingCardId, bool guessedHigher)
		{
			var flippedCard = new PlayingCardDL(data).GetNextShuffledCardNotAlreadyShown(gamePlayId);
			var showingCard = this.data.PlayingCards.Get(showingCardId);

			var nextTurn = guessedHigher
						 ? this.getNextTurnBasedOnGuess(showingCard, flippedCard, gamePlayId, true)
						 : this.getNextTurnBasedOnGuess(showingCard, flippedCard, gamePlayId, false);
			this.data.Turns.Insert(nextTurn);
			this.data.Save();

			this.saveGamePlayTurn(gamePlayId, nextTurn.TurnId);
		}

		public void HandleHold(int gamePlayId, int showingCardId)
		{
			var showingCard = this.data.PlayingCards.Get(showingCardId);

			var nextTurn = new Turn()
			{
				Order = this.data.GamePlays.Get(new QueryOptions<GamePlay>() { Includes = "Turns.Turn", Where = p => p.GamePlayId == gamePlayId }).Turns.Count + 1,
				ShowingCardId = showingCard.PlayingCardId,
				ActionTypeId = (int)GameActionType.Hold
			};
			this.data.Turns.Insert(nextTurn);
			this.data.Save();

			this.saveGamePlayTurn(gamePlayId, nextTurn.TurnId);
		}

		#region Private Helpers

		private Turn getNextTurnBasedOnGuess(PlayingCard showingCard, PlayingCard flippedCard, int gamePlayId, bool guessedHigher)
		{
			Turn nextTurn = null;
			var hasGuessedHigherRight = flippedCard.Value > showingCard.Value && guessedHigher;
			var hasGuessedLowerRight = flippedCard.Value < showingCard.Value && !guessedHigher;
			var hasGuessedLowerWrong = flippedCard.Value >= showingCard.Value && !guessedHigher;
			var hasGuessedHigherWrong = flippedCard.Value <= showingCard.Value && guessedHigher;

			if (hasGuessedHigherRight || hasGuessedLowerRight)
			{
				nextTurn = new Turn()
				{
					Order = this.data.GamePlays.Get(new QueryOptions<GamePlay>() { Includes = "Turns.Turn", Where = p => p.GamePlayId == gamePlayId }).Turns.Count + 1,
					ShowingCardId = showingCard.PlayingCardId,
					FlippedCardId = flippedCard.PlayingCardId,
					ActionTypeId = (int)GameActionType.Continue,
					GuessTypeId = guessedHigher ? (int)GameGuessType.Higher : (int)GameGuessType.Lower
				};
			}
			else if (hasGuessedLowerWrong || hasGuessedHigherWrong)
			{
				nextTurn = new Turn()
				{
					Order = this.data.GamePlays.Get(new QueryOptions<GamePlay>() { Includes = "Turns.Turn", Where = p => p.GamePlayId == gamePlayId }).Turns.Count + 1,
					ShowingCardId = showingCard.PlayingCardId,
					FlippedCardId = flippedCard.PlayingCardId,
					ActionTypeId = (int)GameActionType.GameOver,
					GuessTypeId = guessedHigher ? (int)GameGuessType.Higher : (int)GameGuessType.Lower
				};
			}

			return nextTurn;
		}

		private void saveGamePlayTurn(int gamePlayId, int turnId)
		{
			var gamePlayTurn = new GamePlayTurn()
			{
				GamePlayId = gamePlayId,
				TurnId = turnId
			};
			this.data.GamePlayTurns.Insert(gamePlayTurn);
			this.data.Save();
		}

		#endregion
	}
}
