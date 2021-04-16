using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	public interface IHigherOrLowerDataAccessor
	{

		/// <summary>
		/// Gets the action types.
		/// </summary>
		/// <value>
		/// The action types.
		/// </value>
		IRepository<ActionType> ActionTypes { get; }

		/// <summary>
		/// Gets the game plays.
		/// </summary>
		/// <value>
		/// The game plays.
		/// </value>
		IRepository<GamePlay> GamePlays { get; }

		/// <summary>
		/// Gets the game play turns.
		/// </summary>
		/// <value>
		/// The game play turns.
		/// </value>
		IRepository<GamePlayTurn> GamePlayTurns { get; }

		/// <summary>
		/// Gets the guess types.
		/// </summary>
		/// <value>
		/// The guess types.
		/// </value>
		IRepository<GuessType> GuessTypes { get; }

		/// <summary>
		/// Gets the playing cards.
		/// </summary>
		/// <value>
		/// The playing cards.
		/// </value>
		IRepository<PlayingCard> PlayingCards { get; }

		/// <summary>
		/// Gets the turns.
		/// </summary>
		/// <value>
		/// The turns.
		/// </value>
		IRepository<Turn> Turns { get; }

		/// <summary>
		/// Saves this instance.
		/// </summary>
		void Save();
	}
}
