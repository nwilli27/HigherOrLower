using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	public class GamePlayViewModel
	{
		public GamePlay GamePlay { get; set; }
		public string GameStatus { get; set; }

		public string GetPlayingCardImagePath(GamePlay gamePlay)
		{
			var card = gamePlay.CurrentTurn.HasHeld
					 ? gamePlay.CurrentTurn.ShowingCard
					 : gamePlay.CurrentTurn.FlippedCard;

			return card != null
				 ? $"https://tekeye.uk/playing_cards/images/svg_playing_cards/fronts/{card.Suit.ToLower()}_{card.Type.ToLower()}.svg"
				 : string.Empty;
		}
	}
}
