using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	public class GamePlay
	{
		public int GamePlayId { get; set; }
		public ICollection<GamePlayTurn> Turns { get; set; }
	}
}
