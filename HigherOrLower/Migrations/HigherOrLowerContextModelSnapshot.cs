﻿// <auto-generated />
using HigherOrLower.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HigherOrLower.Migrations
{
    [DbContext(typeof(HigherOrLowerContext))]
    partial class HigherOrLowerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HigherOrLower.Models.ActionType", b =>
                {
                    b.Property<int>("ActionTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActionTypeId");

                    b.ToTable("ActionTypes");

                    b.HasData(
                        new
                        {
                            ActionTypeId = 1,
                            Description = "Continue"
                        },
                        new
                        {
                            ActionTypeId = 2,
                            Description = "Hold"
                        },
                        new
                        {
                            ActionTypeId = 3,
                            Description = "Game Over"
                        });
                });

            modelBuilder.Entity("HigherOrLower.Models.GamePlay", b =>
                {
                    b.Property<int>("GamePlayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("GamePlayId");

                    b.ToTable("GamePlays");
                });

            modelBuilder.Entity("HigherOrLower.Models.GamePlayTurn", b =>
                {
                    b.Property<int>("GamePlayId")
                        .HasColumnType("int");

                    b.Property<int>("GameTurnId")
                        .HasColumnType("int");

                    b.HasKey("GamePlayId", "GameTurnId");

                    b.HasIndex("GameTurnId");

                    b.ToTable("GamePlayTurns");
                });

            modelBuilder.Entity("HigherOrLower.Models.GuessType", b =>
                {
                    b.Property<int>("GuessTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GuessTypeId");

                    b.ToTable("GuessTypes");

                    b.HasData(
                        new
                        {
                            GuessTypeId = 1,
                            Description = "Higher"
                        },
                        new
                        {
                            GuessTypeId = 2,
                            Description = "Lower"
                        });
                });

            modelBuilder.Entity("HigherOrLower.Models.PlayingCard", b =>
                {
                    b.Property<int>("PlayingCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Suit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("PlayingCardId");

                    b.ToTable("PlayingCards");

                    b.HasData(
                        new
                        {
                            PlayingCardId = 1,
                            Suit = "Spades",
                            Type = "Ace",
                            Value = 1
                        },
                        new
                        {
                            PlayingCardId = 2,
                            Suit = "Spades",
                            Type = "2",
                            Value = 2
                        },
                        new
                        {
                            PlayingCardId = 3,
                            Suit = "Spades",
                            Type = "3",
                            Value = 3
                        },
                        new
                        {
                            PlayingCardId = 4,
                            Suit = "Spades",
                            Type = "4",
                            Value = 4
                        },
                        new
                        {
                            PlayingCardId = 5,
                            Suit = "Spades",
                            Type = "5",
                            Value = 5
                        },
                        new
                        {
                            PlayingCardId = 6,
                            Suit = "Spades",
                            Type = "6",
                            Value = 6
                        },
                        new
                        {
                            PlayingCardId = 7,
                            Suit = "Spades",
                            Type = "7",
                            Value = 7
                        },
                        new
                        {
                            PlayingCardId = 8,
                            Suit = "Spades",
                            Type = "8",
                            Value = 8
                        },
                        new
                        {
                            PlayingCardId = 9,
                            Suit = "Spades",
                            Type = "9",
                            Value = 9
                        },
                        new
                        {
                            PlayingCardId = 10,
                            Suit = "Spades",
                            Type = "10",
                            Value = 10
                        },
                        new
                        {
                            PlayingCardId = 11,
                            Suit = "Spades",
                            Type = "Jack",
                            Value = 11
                        },
                        new
                        {
                            PlayingCardId = 12,
                            Suit = "Spades",
                            Type = "Queen",
                            Value = 12
                        },
                        new
                        {
                            PlayingCardId = 13,
                            Suit = "Spades",
                            Type = "King",
                            Value = 13
                        },
                        new
                        {
                            PlayingCardId = 14,
                            Suit = "Hearts",
                            Type = "Ace",
                            Value = 1
                        },
                        new
                        {
                            PlayingCardId = 15,
                            Suit = "Hearts",
                            Type = "2",
                            Value = 2
                        },
                        new
                        {
                            PlayingCardId = 16,
                            Suit = "Hearts",
                            Type = "3",
                            Value = 3
                        },
                        new
                        {
                            PlayingCardId = 17,
                            Suit = "Hearts",
                            Type = "4",
                            Value = 4
                        },
                        new
                        {
                            PlayingCardId = 18,
                            Suit = "Hearts",
                            Type = "5",
                            Value = 5
                        },
                        new
                        {
                            PlayingCardId = 19,
                            Suit = "Hearts",
                            Type = "6",
                            Value = 6
                        },
                        new
                        {
                            PlayingCardId = 20,
                            Suit = "Hearts",
                            Type = "7",
                            Value = 7
                        },
                        new
                        {
                            PlayingCardId = 21,
                            Suit = "Hearts",
                            Type = "8",
                            Value = 8
                        },
                        new
                        {
                            PlayingCardId = 22,
                            Suit = "Hearts",
                            Type = "9",
                            Value = 9
                        },
                        new
                        {
                            PlayingCardId = 23,
                            Suit = "Hearts",
                            Type = "10",
                            Value = 10
                        },
                        new
                        {
                            PlayingCardId = 24,
                            Suit = "Hearts",
                            Type = "Jack",
                            Value = 11
                        },
                        new
                        {
                            PlayingCardId = 25,
                            Suit = "Hearts",
                            Type = "Queen",
                            Value = 12
                        },
                        new
                        {
                            PlayingCardId = 26,
                            Suit = "Hearts",
                            Type = "King",
                            Value = 13
                        },
                        new
                        {
                            PlayingCardId = 27,
                            Suit = "Clubs",
                            Type = "Ace",
                            Value = 1
                        },
                        new
                        {
                            PlayingCardId = 28,
                            Suit = "Clubs",
                            Type = "2",
                            Value = 2
                        },
                        new
                        {
                            PlayingCardId = 29,
                            Suit = "Clubs",
                            Type = "3",
                            Value = 3
                        },
                        new
                        {
                            PlayingCardId = 30,
                            Suit = "Clubs",
                            Type = "4",
                            Value = 4
                        },
                        new
                        {
                            PlayingCardId = 31,
                            Suit = "Clubs",
                            Type = "5",
                            Value = 5
                        },
                        new
                        {
                            PlayingCardId = 32,
                            Suit = "Clubs",
                            Type = "6",
                            Value = 6
                        },
                        new
                        {
                            PlayingCardId = 33,
                            Suit = "Clubs",
                            Type = "7",
                            Value = 7
                        },
                        new
                        {
                            PlayingCardId = 34,
                            Suit = "Clubs",
                            Type = "8",
                            Value = 8
                        },
                        new
                        {
                            PlayingCardId = 35,
                            Suit = "Clubs",
                            Type = "9",
                            Value = 9
                        },
                        new
                        {
                            PlayingCardId = 36,
                            Suit = "Clubs",
                            Type = "10",
                            Value = 10
                        },
                        new
                        {
                            PlayingCardId = 37,
                            Suit = "Clubs",
                            Type = "Jack",
                            Value = 11
                        },
                        new
                        {
                            PlayingCardId = 38,
                            Suit = "Clubs",
                            Type = "Queen",
                            Value = 12
                        },
                        new
                        {
                            PlayingCardId = 39,
                            Suit = "Clubs",
                            Type = "King",
                            Value = 13
                        },
                        new
                        {
                            PlayingCardId = 40,
                            Suit = "Diamonds",
                            Type = "Ace",
                            Value = 1
                        },
                        new
                        {
                            PlayingCardId = 41,
                            Suit = "Diamonds",
                            Type = "2",
                            Value = 2
                        },
                        new
                        {
                            PlayingCardId = 42,
                            Suit = "Diamonds",
                            Type = "3",
                            Value = 3
                        },
                        new
                        {
                            PlayingCardId = 43,
                            Suit = "Diamonds",
                            Type = "4",
                            Value = 4
                        },
                        new
                        {
                            PlayingCardId = 44,
                            Suit = "Diamonds",
                            Type = "5",
                            Value = 5
                        },
                        new
                        {
                            PlayingCardId = 45,
                            Suit = "Diamonds",
                            Type = "6",
                            Value = 6
                        },
                        new
                        {
                            PlayingCardId = 46,
                            Suit = "Diamonds",
                            Type = "7",
                            Value = 7
                        },
                        new
                        {
                            PlayingCardId = 47,
                            Suit = "Diamonds",
                            Type = "8",
                            Value = 8
                        },
                        new
                        {
                            PlayingCardId = 48,
                            Suit = "Diamonds",
                            Type = "9",
                            Value = 9
                        },
                        new
                        {
                            PlayingCardId = 49,
                            Suit = "Diamonds",
                            Type = "10",
                            Value = 10
                        },
                        new
                        {
                            PlayingCardId = 50,
                            Suit = "Diamonds",
                            Type = "Jack",
                            Value = 11
                        },
                        new
                        {
                            PlayingCardId = 51,
                            Suit = "Diamonds",
                            Type = "Queen",
                            Value = 12
                        },
                        new
                        {
                            PlayingCardId = 52,
                            Suit = "Diamonds",
                            Type = "King",
                            Value = 13
                        });
                });

            modelBuilder.Entity("HigherOrLower.Models.Turn", b =>
                {
                    b.Property<int>("TurnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionTypeId")
                        .HasColumnType("int");

                    b.Property<int>("FlippedCardId")
                        .HasColumnType("int");

                    b.Property<int>("GuessTypeId")
                        .HasColumnType("int");

                    b.Property<int>("ShowingCardId")
                        .HasColumnType("int");

                    b.HasKey("TurnId");

                    b.HasIndex("ActionTypeId");

                    b.HasIndex("FlippedCardId");

                    b.HasIndex("GuessTypeId");

                    b.HasIndex("ShowingCardId");

                    b.ToTable("Turns");
                });

            modelBuilder.Entity("HigherOrLower.Models.GamePlayTurn", b =>
                {
                    b.HasOne("HigherOrLower.Models.GamePlay", "GamePlay")
                        .WithMany("Turns")
                        .HasForeignKey("GamePlayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HigherOrLower.Models.Turn", "GameTurn")
                        .WithMany()
                        .HasForeignKey("GameTurnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GamePlay");

                    b.Navigation("GameTurn");
                });

            modelBuilder.Entity("HigherOrLower.Models.Turn", b =>
                {
                    b.HasOne("HigherOrLower.Models.ActionType", "ActionType")
                        .WithMany()
                        .HasForeignKey("ActionTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HigherOrLower.Models.PlayingCard", "FlippedCard")
                        .WithMany()
                        .HasForeignKey("FlippedCardId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HigherOrLower.Models.GuessType", "GuessType")
                        .WithMany()
                        .HasForeignKey("GuessTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HigherOrLower.Models.PlayingCard", "ShowingCard")
                        .WithMany()
                        .HasForeignKey("ShowingCardId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ActionType");

                    b.Navigation("FlippedCard");

                    b.Navigation("GuessType");

                    b.Navigation("ShowingCard");
                });

            modelBuilder.Entity("HigherOrLower.Models.GamePlay", b =>
                {
                    b.Navigation("Turns");
                });
#pragma warning restore 612, 618
        }
    }
}
