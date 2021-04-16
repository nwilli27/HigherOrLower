using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	public class GamePlayTurn
	{
		public int GamePlayId { get; set; }
		public int GameTurnId { get; set; }
		public GamePlay GamePlay { get; set; }
		public Turn GameTurn { get; set; }
	}
}
