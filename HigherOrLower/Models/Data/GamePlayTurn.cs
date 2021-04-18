using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	/// <summary>
	/// Holds data for a GamePlayTurn
	/// 
	/// Author: Nolan Williams
	/// Date:	4/18/2021
	/// </summary>
	public class GamePlayTurn
	{

		/// <summary>
		/// Gets or sets the game play identifier.
		/// </summary>
		/// <value>
		/// The game play identifier.
		/// </value>
		public int GamePlayId { get; set; }

		/// <summary>
		/// Gets or sets the turn identifier.
		/// </summary>
		/// <value>
		/// The turn identifier.
		/// </value>
		public int TurnId { get; set; }

		/// <summary>
		/// Gets or sets the game play.
		/// </summary>
		/// <value>
		/// The game play.
		/// </value>
		public GamePlay GamePlay { get; set; }

		/// <summary>
		/// Gets or sets the turn.
		/// </summary>
		/// <value>
		/// The turn.
		/// </value>
		public Turn Turn { get; set; }
	}
}
