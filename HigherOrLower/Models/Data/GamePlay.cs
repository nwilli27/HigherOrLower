using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	/// <summary>
	/// Holds data for a GamePlay
	/// 
	/// Author: Nolan Williams
	/// Date:	4/18/2021
	/// </summary>
	public class GamePlay
	{

		/// <summary>
		/// Gets or sets the game play identifier.
		/// </summary>
		/// <value>
		/// The game play identifier.
		/// </value>
		public int GamePlayId { get; set; }

		/// <summary>
		/// Gets or sets the user identifier.
		/// </summary>
		/// <value>
		/// The user identifier.
		/// </value>
		public string UserId { get; set; }

		/// <summary>
		/// Gets or sets the user.
		/// </summary>
		/// <value>
		/// The user.
		/// </value>
		public User User { get; set; }

		/// <summary>
		/// Gets or sets the pulled cards.
		/// </summary>
		/// <value>
		/// The pulled cards.
		/// </value>
		public IList<PlayingCard> PulledCards { get; set; }

		/// <summary>
		/// Gets the current turn.
		/// </summary>
		/// <value>
		/// The current turn.
		/// </value>
		public Turn CurrentTurn => this.Turns?.Last()?.Turn;

		/// <summary>
		/// Gets a value indicating whether this instance is game over.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is game over; otherwise, <c>false</c>.
		/// </value>
		public bool IsGameOver => this.CurrentTurn.IsGameOver;

		/// <summary>
		/// Gets the score.
		/// </summary>
		/// <value>
		/// The score.
		/// </value>
		public int Score => this.CurrentTurn.HasHeld ? this.Turns.Count(t => t.Turn.IsScoreable) : 0;

		/// <summary>
		/// Gets the game status.
		/// </summary>
		/// <returns></returns>
		public string GetGameStatus()
		{
			if (IsGameOver)
			{
				return $"Game Over - Final Score: {Score}";
			}
			else
			{
				return $"Guess Higher or Lower";
			}
		}

		/// <summary>
		/// Gets or sets the turns.
		/// </summary>
		/// <value>
		/// The turns.
		/// </value>
		public ICollection<GamePlayTurn> Turns { get; set; }

		/// <summary>
		/// Gets the initial turn.
		/// </summary>
		/// <returns></returns>
		public Turn GetInitialTurn()
		{
			return new Turn()
			{
				ActionTypeId = (int) GameActionType.Start,
				Order = 1
			};
		}
	}
}
