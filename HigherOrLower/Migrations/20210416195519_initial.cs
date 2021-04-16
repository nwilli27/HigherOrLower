﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace HigherOrLower.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionTypes",
                columns: table => new
                {
                    ActionTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionTypes", x => x.ActionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "GamePlays",
                columns: table => new
                {
                    GamePlayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlays", x => x.GamePlayId);
                });

            migrationBuilder.CreateTable(
                name: "GuessTypes",
                columns: table => new
                {
                    GuessTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuessTypes", x => x.GuessTypeId);
                });

            migrationBuilder.CreateTable(
                name: "PlayingCards",
                columns: table => new
                {
                    PlayingCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Suit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayingCards", x => x.PlayingCardId);
                });

            migrationBuilder.CreateTable(
                name: "Turns",
                columns: table => new
                {
                    TurnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowingCardId = table.Column<int>(type: "int", nullable: false),
                    FlippedCardId = table.Column<int>(type: "int", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: false),
                    GuessTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turns", x => x.TurnId);
                    table.ForeignKey(
                        name: "FK_Turns_ActionTypes_ActionTypeId",
                        column: x => x.ActionTypeId,
                        principalTable: "ActionTypes",
                        principalColumn: "ActionTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Turns_GuessTypes_GuessTypeId",
                        column: x => x.GuessTypeId,
                        principalTable: "GuessTypes",
                        principalColumn: "GuessTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Turns_PlayingCards_FlippedCardId",
                        column: x => x.FlippedCardId,
                        principalTable: "PlayingCards",
                        principalColumn: "PlayingCardId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Turns_PlayingCards_ShowingCardId",
                        column: x => x.ShowingCardId,
                        principalTable: "PlayingCards",
                        principalColumn: "PlayingCardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GamePlayTurns",
                columns: table => new
                {
                    GamePlayId = table.Column<int>(type: "int", nullable: false),
                    GameTurnId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayTurns", x => new { x.GamePlayId, x.GameTurnId });
                    table.ForeignKey(
                        name: "FK_GamePlayTurns_GamePlays_GamePlayId",
                        column: x => x.GamePlayId,
                        principalTable: "GamePlays",
                        principalColumn: "GamePlayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlayTurns_Turns_GameTurnId",
                        column: x => x.GameTurnId,
                        principalTable: "Turns",
                        principalColumn: "TurnId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ActionTypes",
                columns: new[] { "ActionTypeId", "Description" },
                values: new object[,]
                {
                    { 1, "Continue" },
                    { 2, "Hold" },
                    { 3, "Game Over" }
                });

            migrationBuilder.InsertData(
                table: "GuessTypes",
                columns: new[] { "GuessTypeId", "Description" },
                values: new object[,]
                {
                    { 1, "Higher" },
                    { 2, "Lower" }
                });

            migrationBuilder.InsertData(
                table: "PlayingCards",
                columns: new[] { "PlayingCardId", "Suit", "Type", "Value" },
                values: new object[,]
                {
                    { 28, "Clubs", "2", 2 },
                    { 29, "Clubs", "3", 3 },
                    { 30, "Clubs", "4", 4 },
                    { 31, "Clubs", "5", 5 },
                    { 32, "Clubs", "6", 6 },
                    { 33, "Clubs", "7", 7 },
                    { 34, "Clubs", "8", 8 },
                    { 35, "Clubs", "9", 9 },
                    { 36, "Clubs", "10", 10 },
                    { 37, "Clubs", "Jack", 11 },
                    { 38, "Clubs", "Queen", 12 },
                    { 41, "Diamonds", "2", 2 },
                    { 40, "Diamonds", "Ace", 1 },
                    { 27, "Clubs", "Ace", 1 },
                    { 42, "Diamonds", "3", 3 },
                    { 43, "Diamonds", "4", 4 },
                    { 44, "Diamonds", "5", 5 },
                    { 45, "Diamonds", "6", 6 },
                    { 46, "Diamonds", "7", 7 },
                    { 47, "Diamonds", "8", 8 },
                    { 48, "Diamonds", "9", 9 },
                    { 49, "Diamonds", "10", 10 },
                    { 50, "Diamonds", "Jack", 11 },
                    { 39, "Clubs", "King", 13 },
                    { 26, "Hearts", "King", 13 },
                    { 24, "Hearts", "Jack", 11 },
                    { 51, "Diamonds", "Queen", 12 },
                    { 1, "Spades", "Ace", 1 },
                    { 2, "Spades", "2", 2 },
                    { 3, "Spades", "3", 3 },
                    { 4, "Spades", "4", 4 },
                    { 5, "Spades", "5", 5 },
                    { 6, "Spades", "6", 6 },
                    { 7, "Spades", "7", 7 },
                    { 8, "Spades", "8", 8 },
                    { 9, "Spades", "9", 9 },
                    { 10, "Spades", "10", 10 }
                });

            migrationBuilder.InsertData(
                table: "PlayingCards",
                columns: new[] { "PlayingCardId", "Suit", "Type", "Value" },
                values: new object[,]
                {
                    { 11, "Spades", "Jack", 11 },
                    { 12, "Spades", "Queen", 12 },
                    { 13, "Spades", "King", 13 },
                    { 14, "Hearts", "Ace", 1 },
                    { 15, "Hearts", "2", 2 },
                    { 16, "Hearts", "3", 3 },
                    { 17, "Hearts", "4", 4 },
                    { 18, "Hearts", "5", 5 },
                    { 19, "Hearts", "6", 6 },
                    { 20, "Hearts", "7", 7 },
                    { 21, "Hearts", "8", 8 },
                    { 22, "Hearts", "9", 9 },
                    { 23, "Hearts", "10", 10 },
                    { 25, "Hearts", "Queen", 12 },
                    { 52, "Diamonds", "King", 13 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayTurns_GameTurnId",
                table: "GamePlayTurns",
                column: "GameTurnId");

            migrationBuilder.CreateIndex(
                name: "IX_Turns_ActionTypeId",
                table: "Turns",
                column: "ActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Turns_FlippedCardId",
                table: "Turns",
                column: "FlippedCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Turns_GuessTypeId",
                table: "Turns",
                column: "GuessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Turns_ShowingCardId",
                table: "Turns",
                column: "ShowingCardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamePlayTurns");

            migrationBuilder.DropTable(
                name: "GamePlays");

            migrationBuilder.DropTable(
                name: "Turns");

            migrationBuilder.DropTable(
                name: "ActionTypes");

            migrationBuilder.DropTable(
                name: "GuessTypes");

            migrationBuilder.DropTable(
                name: "PlayingCards");
        }
    }
}
