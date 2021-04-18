using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	/// <summary>
	/// Holds abstracted functionality to interact with DB for a GamePlay
	/// 
	/// Author: Nolan Williams
	/// Date:	4/18/2021
	/// </summary>
	public class GamePlayDL
	{
		#region Members

		private readonly IHigherOrLowerDataAccessor data;
		private readonly UserManager<User> userManager;

		#endregion

		#region Construction

		/// <summary>
		/// Initializes a new instance of the <see cref="GamePlayDL"/> class.
		/// </summary>
		/// <param name="data">The data.</param>
		/// <param name="userManager">The user manager.</param>
		public GamePlayDL(IHigherOrLowerDataAccessor data, UserManager<User> userManager)
		{
			this.data = data;
			this.userManager = userManager;
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Gets the game play.
		/// </summary>
		/// <param name="gamePlayId">The game play identifier.</param>
		/// <returns>The game play populated based on the given [gamePlayId].</returns>
		public GamePlay GetGamePlay(int gamePlayId)
		{
			GamePlay gamePlay = null;

			if (gamePlayId > 0)
			{
				gamePlay = this.data.GamePlays.Get(new QueryOptions<GamePlay>()
				{
					Includes = "Turns.Turn",
					Where = p => p.GamePlayId == gamePlayId
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

		/// <summary>
		/// Initializes the new game play for a [user].
		/// </summary>
		/// <param name="user">The user.</param>
		/// <returns>Returns the initialized game play for [user].</returns>
		public GamePlay InitializeNewGamePlayFor(User user)
		{
			var gamePlay = new GamePlay
			{
				UserId = user.Id
			};
			this.data.GamePlays.Insert(gamePlay);
			this.data.Save();

			var initialTurn = gamePlay.GetInitialTurn();
			initialTurn.FlippedCardId = new PlayingCardDL(data).PullNextRandomPlayingCard(gamePlay.GamePlayId).PlayingCardId;
			this.data.Turns.Insert(initialTurn);
			this.data.Save();

			this.saveGamePlayTurn(gamePlay.GamePlayId, initialTurn.TurnId);

			return gamePlay;
		}

		/// <summary>
		/// Initializes the new game play for admin [user].
		/// </summary>
		/// <param name="user">The user.</param>
		/// <returns>Gameplay that is initialized for [user].</returns>
		public GamePlay InitializeNewGamePlayForAdmin(User user)
		{
			var gamePlay = new GamePlay
			{
				UserId = user.Id
			};
			this.data.GamePlays.Insert(gamePlay);
			this.data.Save();

			var initialTurn = gamePlay.GetInitialTurn();
			initialTurn.FlippedCardId = 1;
			this.data.Turns.Insert(initialTurn);
			this.data.Save();

			this.saveGamePlayTurn(gamePlay.GamePlayId, initialTurn.TurnId);

			return gamePlay;
		}

		/// <summary>
		/// Handles the user guess and updates the game state.
		/// </summary>
		/// <param name="gamePlayId">The game play identifier.</param>
		/// <param name="showingCardId">The showing card identifier.</param>
		/// <param name="guessedHigher">if set to <c>true</c> [guessed higher].</param>
		public void HandleGuess(int gamePlayId, int showingCardId, bool guessedHigher)
		{
			var gamePlay = this.GetGamePlay(gamePlayId);
			var totalPlayingCards = this.data.PlayingCards.List(new QueryOptions<PlayingCard>()).Count();

			if (gamePlay.Turns.Count == totalPlayingCards)
			{
				this.HandleHold(gamePlayId, showingCardId);
			}
			else
			{
				var flippedCard = new PlayingCardDL(data).PullNextRandomPlayingCard(gamePlayId);
				this.handleGuessWithFlippedCard(gamePlayId, showingCardId, guessedHigher, flippedCard);
			}
		}

		/// <summary>
		/// Handles the guess for admin and updates the game state.
		/// </summary>
		/// <param name="gamePlayId">The game play identifier.</param>
		/// <param name="showingCardId">The showing card identifier.</param>
		/// <param name="guessedHigher">if set to <c>true</c> [guessed higher].</param>
		public void HandleGuessForAdmin(int gamePlayId, int showingCardId, bool guessedHigher)
		{
			var flippedCard = this.data.PlayingCards.Get(showingCardId + 1);

			if (flippedCard == null)
			{
				this.HandleHold(gamePlayId, showingCardId);
			}
			else
			{
				this.handleGuessWithFlippedCard(gamePlayId, showingCardId, guessedHigher, flippedCard);
			}
		}

		/// <summary>
		/// Handles the hold and updates the game state
		/// </summary>
		/// <param name="gamePlayId">The game play identifier.</param>
		/// <param name="showingCardId">The showing card identifier.</param>
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

		/// <summary>
		/// Gets the user high score games.
		/// </summary>
		/// <param name="user">The user.</param>
		/// <param name="topAmount">The top amount.</param>
		/// <returns></returns>
		public IList<GamePlay> GetUserHighScoreGames(User user, int topAmount)
		{
			var userGames = this.data.GamePlays.List(new QueryOptions<GamePlay>()
			{
				Includes = "Turns.Turn, Turns.Turn.ActionType",
				Where = p => p.UserId == user.Id
			});

			var highScoreGames = new List<GamePlay>();
			var userGamesOrdered = userGames.OrderByDescending(g => g.Score);

			if (userGames.Count() >= topAmount)
			{
				highScoreGames = userGamesOrdered.Take(topAmount).ToList();
			}
			else
			{
				highScoreGames = userGamesOrdered.Take(userGames.Count()).ToList();
			}

			var highScoreGamesPopulated = new List<GamePlay>();
			foreach(var game in highScoreGames)
			{
				if (game.Score > 0)
				{
					highScoreGamesPopulated.Add(this.GetGamePlay(game.GamePlayId));
				}
			}
			return highScoreGamesPopulated;
		}

		#endregion

		#region Private Helpers

		private void handleGuessWithFlippedCard(int gamePlayId, int showingCardId, bool guessedHigher, PlayingCard flippedCard)
		{
			var showingCard = this.data.PlayingCards.Get(showingCardId);

			var nextTurn = guessedHigher
						 ? this.getNextTurnBasedOnGuess(showingCard, flippedCard, gamePlayId, true)
						 : this.getNextTurnBasedOnGuess(showingCard, flippedCard, gamePlayId, false);
			this.data.Turns.Insert(nextTurn);
			this.data.Save();

			this.saveGamePlayTurn(gamePlayId, nextTurn.TurnId);
		}

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
