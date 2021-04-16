using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	/// <summary>
	/// Holds the implementation for the IHigherOrLowerDataAccessor
	/// 
	/// Author: Nolan Williams
	/// Date:	4/16/2021
	/// </summary>
	/// <seealso cref="HigherOrLower.Models.IHigherOrLowerDataAccessor" />
	public class HigherOrLowerDataAccessor : IHigherOrLowerDataAccessor
	{
		#region Members

		private HigherOrLowerContext context { get; set; }

		private Repository<ActionType> actionTypes;
		private Repository<GamePlay> gamePlays;
		private Repository<GamePlayTurn> gamePlayTurns;
		private Repository<GuessType> guessTypes;
		private Repository<PlayingCard> playingCards;
		private Repository<Turn> turns;

		#endregion

		#region Construction

		/// <summary>
		/// Initializes a new instance of the <see cref="HigherOrLowerDataAccessor"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public HigherOrLowerDataAccessor(HigherOrLowerContext context) => this.context = context;

		#endregion

		#region IHigherOrLowerDataAccessor

		/// <summary>
		/// Gets the action types.
		/// </summary>
		/// <value>
		/// The action types.
		/// </value>
		public IRepository<ActionType> ActionTypes
		{
			get
			{
				if (this.actionTypes == null) this.actionTypes = new Repository<ActionType>(context);
				return this.actionTypes;
			}
		}

		/// <summary>
		/// Gets the game plays.
		/// </summary>
		/// <value>
		/// The game plays.
		/// </value>
		public IRepository<GamePlay> GamePlays
		{
			get
			{
				if (this.gamePlays == null) this.gamePlays = new Repository<GamePlay>(context);
				return this.gamePlays;
			}
		}

		/// <summary>
		/// Gets the game play turns.
		/// </summary>
		/// <value>
		/// The game play turns.
		/// </value>
		public IRepository<GamePlayTurn> GamePlayTurns
		{
			get
			{
				if (this.gamePlayTurns == null) this.gamePlayTurns = new Repository<GamePlayTurn>(context);
				return this.gamePlayTurns;
			}
		}

		/// <summary>
		/// Gets the guess types.
		/// </summary>
		/// <value>
		/// The guess types.
		/// </value>
		public IRepository<GuessType> GuessTypes
		{
			get
			{
				if (this.guessTypes == null) this.guessTypes = new Repository<GuessType>(context);
				return this.guessTypes;
			}
		}

		/// <summary>
		/// Gets the playing cards.
		/// </summary>
		/// <value>
		/// The playing cards.
		/// </value>
		public IRepository<PlayingCard> PlayingCards
		{
			get
			{
				if (this.playingCards == null) this.playingCards = new Repository<PlayingCard>(context);
				return this.playingCards;
			}
		}

		/// <summary>
		/// Gets the turns.
		/// </summary>
		/// <value>
		/// The turns.
		/// </value>
		public IRepository<Turn> Turns
		{
			get
			{
				if (this.turns == null) this.turns = new Repository<Turn>(context);
				return this.turns;
			}
		}

		/// <summary>
		/// Saves this instance.
		/// </summary>
		public void Save() => this.context.SaveChanges();

		#endregion
	}
}
