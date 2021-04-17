using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	public class GamePlay
	{

		public int GamePlayId { get; set; }

		public string UserId { get; set; }
		public User User { get; set; }

		public IList<PlayingCard> PulledCards { get; set; }

		public Turn CurrentTurn => this.Turns?.Last()?.Turn;
		public bool IsGameOver => this.CurrentTurn.IsGameOver;

		public ICollection<GamePlayTurn> Turns { get; set; }

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
