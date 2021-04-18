using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	/// <summary>
	/// Seeds PlayingCards
	/// 
	/// Author: Nolan Williams
	/// Date:	4/18/2021
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{HigherOrLower.Models.PlayingCard}" />
	public class SeedPlayingCards : IEntityTypeConfiguration<PlayingCard>
	{

		/// <summary>
		/// Configures the entity of type <typeparamref name="TEntity" />.
		/// </summary>
		/// <param name="builder">The builder to be used to configure the entity type.</param>
		public void Configure(EntityTypeBuilder<PlayingCard> builder)
		{
			builder.HasData(
				new PlayingCard() { PlayingCardId = 1, Suit = "Spades", Type = "Ace", Value = 1 },
				new PlayingCard() { PlayingCardId = 2, Suit = "Spades", Type = "2", Value = 2 },
				new PlayingCard() { PlayingCardId = 3, Suit = "Spades", Type = "3", Value = 3 },
				new PlayingCard() { PlayingCardId = 4, Suit = "Spades", Type = "4", Value = 4 },
				new PlayingCard() { PlayingCardId = 5, Suit = "Spades", Type = "5", Value = 5 },
				new PlayingCard() { PlayingCardId = 6, Suit = "Spades", Type = "6", Value = 6 },
				new PlayingCard() { PlayingCardId = 7, Suit = "Spades", Type = "7", Value = 7 },
				new PlayingCard() { PlayingCardId = 8, Suit = "Spades", Type = "8", Value = 8 },
				new PlayingCard() { PlayingCardId = 9, Suit = "Spades", Type = "9", Value = 9 },
				new PlayingCard() { PlayingCardId = 10, Suit = "Spades", Type = "10", Value = 10 },
				new PlayingCard() { PlayingCardId = 11, Suit = "Spades", Type = "Jack", Value = 11 },
				new PlayingCard() { PlayingCardId = 12, Suit = "Spades", Type = "Queen", Value = 12 },
				new PlayingCard() { PlayingCardId = 13, Suit = "Spades", Type = "King", Value = 13 },

				new PlayingCard() { PlayingCardId = 14, Suit = "Hearts", Type = "Ace", Value = 1 },
				new PlayingCard() { PlayingCardId = 15, Suit = "Hearts", Type = "2", Value = 2 },
				new PlayingCard() { PlayingCardId = 16, Suit = "Hearts", Type = "3", Value = 3 },
				new PlayingCard() { PlayingCardId = 17, Suit = "Hearts", Type = "4", Value = 4 },
				new PlayingCard() { PlayingCardId = 18, Suit = "Hearts", Type = "5", Value = 5 },
				new PlayingCard() { PlayingCardId = 19, Suit = "Hearts", Type = "6", Value = 6 },
				new PlayingCard() { PlayingCardId = 20, Suit = "Hearts", Type = "7", Value = 7 },
				new PlayingCard() { PlayingCardId = 21, Suit = "Hearts", Type = "8", Value = 8 },
				new PlayingCard() { PlayingCardId = 22, Suit = "Hearts", Type = "9", Value = 9 },
				new PlayingCard() { PlayingCardId = 23, Suit = "Hearts", Type = "10", Value = 10 },
				new PlayingCard() { PlayingCardId = 24, Suit = "Hearts", Type = "Jack", Value = 11 },
				new PlayingCard() { PlayingCardId = 25, Suit = "Hearts", Type = "Queen", Value = 12 },
				new PlayingCard() { PlayingCardId = 26, Suit = "Hearts", Type = "King", Value = 13 },

				new PlayingCard() { PlayingCardId = 27, Suit = "Clubs", Type = "Ace", Value = 1 },
				new PlayingCard() { PlayingCardId = 28, Suit = "Clubs", Type = "2", Value = 2 },
				new PlayingCard() { PlayingCardId = 29, Suit = "Clubs", Type = "3", Value = 3 },
				new PlayingCard() { PlayingCardId = 30, Suit = "Clubs", Type = "4", Value = 4 },
				new PlayingCard() { PlayingCardId = 31, Suit = "Clubs", Type = "5", Value = 5 },
				new PlayingCard() { PlayingCardId = 32, Suit = "Clubs", Type = "6", Value = 6 },
				new PlayingCard() { PlayingCardId = 33, Suit = "Clubs", Type = "7", Value = 7 },
				new PlayingCard() { PlayingCardId = 34, Suit = "Clubs", Type = "8", Value = 8 },
				new PlayingCard() { PlayingCardId = 35, Suit = "Clubs", Type = "9", Value = 9 },
				new PlayingCard() { PlayingCardId = 36, Suit = "Clubs", Type = "10", Value = 10 },
				new PlayingCard() { PlayingCardId = 37, Suit = "Clubs", Type = "Jack", Value = 11 },
				new PlayingCard() { PlayingCardId = 38, Suit = "Clubs", Type = "Queen", Value = 12 },
				new PlayingCard() { PlayingCardId = 39, Suit = "Clubs", Type = "King", Value = 13 },

				new PlayingCard() { PlayingCardId = 40, Suit = "Diamonds", Type = "Ace", Value = 1 },
				new PlayingCard() { PlayingCardId = 41, Suit = "Diamonds", Type = "2", Value = 2 },
				new PlayingCard() { PlayingCardId = 42, Suit = "Diamonds", Type = "3", Value = 3 },
				new PlayingCard() { PlayingCardId = 43, Suit = "Diamonds", Type = "4", Value = 4 },
				new PlayingCard() { PlayingCardId = 44, Suit = "Diamonds", Type = "5", Value = 5 },
				new PlayingCard() { PlayingCardId = 45, Suit = "Diamonds", Type = "6", Value = 6 },
				new PlayingCard() { PlayingCardId = 46, Suit = "Diamonds", Type = "7", Value = 7 },
				new PlayingCard() { PlayingCardId = 47, Suit = "Diamonds", Type = "8", Value = 8 },
				new PlayingCard() { PlayingCardId = 48, Suit = "Diamonds", Type = "9", Value = 9 },
				new PlayingCard() { PlayingCardId = 49, Suit = "Diamonds", Type = "10", Value = 10 },
				new PlayingCard() { PlayingCardId = 50, Suit = "Diamonds", Type = "Jack", Value = 11 },
				new PlayingCard() { PlayingCardId = 51, Suit = "Diamonds", Type = "Queen", Value = 12 },
				new PlayingCard() { PlayingCardId = 52, Suit = "Diamonds", Type = "King", Value = 13 });
		}
	}
}
