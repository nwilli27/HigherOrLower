using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	public class PlayingCardDL
	{
		#region Members

		private readonly IHigherOrLowerDataAccessor data;
		private static readonly Random random = new Random();

		#endregion

		#region Constants

		private const int StartingPlayingCardId = 1;
		private const int EndingPlayingCardId = 52;

		#endregion

		#region Construction

		public PlayingCardDL(IHigherOrLowerDataAccessor data)
		{
			this.data = data;
		}

		#endregion

		#region Methods

		public PlayingCard GetNextShuffledCardNotAlreadyShown(int gamePlayId)
		{
			PlayingCard nextPlayingCard = null;
			var shownCards = this.data.GamePlays.Get(new QueryOptions<GamePlay>()
			{
				Includes = "Turns.Turn",
				Where = p => p.GamePlayId == gamePlayId
			}).Turns;

			while (nextPlayingCard == null)
			{
				var randomPlayingCardId = getRandomPlayingCardId();
				if (!shownCards.Any(p => p.Turn.ShowingCardId == randomPlayingCardId || p.Turn.FlippedCardId == randomPlayingCardId))
				{
					nextPlayingCard = this.data.PlayingCards.Get(randomPlayingCardId);
				}
			}

			return nextPlayingCard;
		}

		private static int getRandomPlayingCardId()
		{
			return random.Next(StartingPlayingCardId, EndingPlayingCardId);
		}

		#endregion
	}
}
