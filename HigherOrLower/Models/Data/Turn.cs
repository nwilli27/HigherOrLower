using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	/// <summary>
	/// Holds data for a Turn
	/// 
	/// Author: Nolan Williams
	/// Date:	4/18/2021
	/// </summary>
	public class Turn
	{

		/// <summary>
		/// Gets or sets the turn identifier.
		/// </summary>
		/// <value>
		/// The turn identifier.
		/// </value>
		public int TurnId { get; set; }

		/// <summary>
		/// Gets or sets the order.
		/// </summary>
		/// <value>
		/// The order.
		/// </value>
		public int Order { get; set; }

		/// <summary>
		/// Gets or sets the showing card identifier.
		/// </summary>
		/// <value>
		/// The showing card identifier.
		/// </value>
		public int? ShowingCardId { get; set; }

		/// <summary>
		/// Gets or sets the showing card.
		/// </summary>
		/// <value>
		/// The showing card.
		/// </value>
		public PlayingCard ShowingCard { get; set; }

		/// <summary>
		/// Gets or sets the flipped card identifier.
		/// </summary>
		/// <value>
		/// The flipped card identifier.
		/// </value>
		public int? FlippedCardId { get; set; }

		/// <summary>
		/// Gets or sets the flipped card.
		/// </summary>
		/// <value>
		/// The flipped card.
		/// </value>
		public PlayingCard FlippedCard { get; set; }

		/// <summary>
		/// Gets or sets the action type identifier.
		/// </summary>
		/// <value>
		/// The action type identifier.
		/// </value>
		public int ActionTypeId { get; set; }

		/// <summary>
		/// Gets or sets the type of the action.
		/// </summary>
		/// <value>
		/// The type of the action.
		/// </value>
		public ActionType ActionType { get; set; }

		/// <summary>
		/// Gets or sets the guess type identifier.
		/// </summary>
		/// <value>
		/// The guess type identifier.
		/// </value>
		public int? GuessTypeId { get; set; }

		/// <summary>
		/// Gets or sets the type of the guess.
		/// </summary>
		/// <value>
		/// The type of the guess.
		/// </value>
		public GuessType GuessType { get; set; }

		/// <summary>
		/// Gets a value indicating whether this instance is game over.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is game over; otherwise, <c>false</c>.
		/// </value>
		public bool IsGameOver => ActionType?.Type == GameActionType.GameOver || ActionType?.Type == GameActionType.Hold;

		/// <summary>
		/// Gets a value indicating whether this instance is scoreable.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is scoreable; otherwise, <c>false</c>.
		/// </value>
		public bool IsScoreable => !IsGameOver && ActionType?.Type != GameActionType.Start;

		/// <summary>
		/// Gets a value indicating whether this instance has held.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance has held; otherwise, <c>false</c>.
		/// </value>
		public bool HasHeld => ActionType?.Type == GameActionType.Hold;

		/// <summary>
		/// Gets the result.
		/// </summary>
		/// <value>
		/// The result.
		/// </value>
		public string Result => IsGameOver ? "Game Over" : string.Empty;

	}
}
