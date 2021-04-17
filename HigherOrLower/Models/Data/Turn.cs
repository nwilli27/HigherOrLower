using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	public class Turn
	{
		public int TurnId { get; set; }
		public int Order { get; set; }
		public int? ShowingCardId { get; set; }
		public PlayingCard ShowingCard { get; set; }
		public int? FlippedCardId { get; set; }
		public PlayingCard FlippedCard { get; set; }
		public int ActionTypeId { get; set; }
		public ActionType ActionType { get; set; }
		public int? GuessTypeId { get; set; }
		public GuessType GuessType { get; set; }
		public bool IsGameOver => ActionType?.Type == GameActionType.GameOver || ActionType?.Type == GameActionType.Hold;
		public bool IsScoreable => !IsGameOver && ActionType?.Type != GameActionType.Start;
		public bool HasHeld => ActionType?.Type == GameActionType.Hold;
		public string Result => IsGameOver ? "Game Over" : string.Empty;

	}
}
