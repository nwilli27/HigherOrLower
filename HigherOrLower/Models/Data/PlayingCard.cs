using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	public class PlayingCard
	{
		public int PlayingCardId { get; set; }
		public string Suit { get; set; }
		public string Type { get; set; }
		public int Value { get; set; }
		public string Description => $"{Type} {Suit}";
	}
}
