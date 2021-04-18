using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	/// <summary>
	/// Holds data for a PlayingCard
	/// 
	/// Author: Nolan Williams
	/// Date:	4/18/2021
	/// </summary>
	public class PlayingCard
	{

		/// <summary>
		/// Gets or sets the playing card identifier.
		/// </summary>
		/// <value>
		/// The playing card identifier.
		/// </value>
		public int PlayingCardId { get; set; }

		/// <summary>
		/// Gets or sets the suit.
		/// </summary>
		/// <value>
		/// The suit.
		/// </value>
		public string Suit { get; set; }

		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		/// <value>
		/// The type.
		/// </value>
		public string Type { get; set; }

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>
		/// The value.
		/// </value>
		public int Value { get; set; }

		/// <summary>
		/// Gets the description.
		/// </summary>
		/// <value>
		/// The description.
		/// </value>
		public string Description => $"{Type} {Suit}";
	}
}
