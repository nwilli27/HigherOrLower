using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	/// <summary>
	/// Holds data needed for GamePlay View
	/// 
	/// Author: Nolan Williams
	/// Date:	4/18/2021
	/// </summary>
	public class GamePlayViewModel
	{

		/// <summary>
		/// Gets or sets the game play.
		/// </summary>
		/// <value>
		/// The game play.
		/// </value>
		public GamePlay GamePlay { get; set; }

		/// <summary>
		/// Gets or sets the game status.
		/// </summary>
		/// <value>
		/// The game status.
		/// </value>
		public string GameStatus { get; set; }

		/// <summary>
		/// Gets the playing card image path.
		/// </summary>
		/// <param name="gamePlay">The game play.</param>
		/// <returns>The playing card image path</returns>
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
