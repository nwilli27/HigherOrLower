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

		public string GetPlayingCardImagePath(PlayingCard card)
		{
			if (card != null)
			{
				return $"https://tekeye.uk/playing_cards/images/svg_playing_cards/fronts/{card.Suit.ToLower()}_{card.Type.ToLower()}.svg";
			}

			return string.Empty;
		}
	}
}
