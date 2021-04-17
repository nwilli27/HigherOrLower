using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentGamePlayId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePlays",
                columns: table => new
                {
                    GamePlayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlays", x => x.GamePlayId);
                    table.ForeignKey(
                        name: "FK_GamePlays_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayingCards",
                columns: table => new
                {
                    PlayingCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Suit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: false),
                    GamePlayId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayingCards", x => x.PlayingCardId);
                    table.ForeignKey(
                        name: "FK_PlayingCards_GamePlays_GamePlayId",
                        column: x => x.GamePlayId,
                        principalTable: "GamePlays",
                        principalColumn: "GamePlayId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Turns",
                columns: table => new
                {
                    TurnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ShowingCardId = table.Column<int>(type: "int", nullable: true),
                    FlippedCardId = table.Column<int>(type: "int", nullable: true),
                    ActionTypeId = table.Column<int>(type: "int", nullable: false),
                    GuessTypeId = table.Column<int>(type: "int", nullable: true)
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
                    TurnId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayTurns", x => new { x.GamePlayId, x.TurnId });
                    table.ForeignKey(
                        name: "FK_GamePlayTurns_GamePlays_GamePlayId",
                        column: x => x.GamePlayId,
                        principalTable: "GamePlays",
                        principalColumn: "GamePlayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlayTurns_Turns_TurnId",
                        column: x => x.TurnId,
                        principalTable: "Turns",
                        principalColumn: "TurnId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ActionTypes",
                columns: new[] { "ActionTypeId", "Description" },
                values: new object[,]
                {
                    { 1, "Start" },
                    { 2, "Continue" },
                    { 3, "Hold" },
                    { 4, "Game Over" }
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
                columns: new[] { "PlayingCardId", "GamePlayId", "Suit", "Type", "Value" },
                values: new object[,]
                {
                    { 36, null, "Clubs", "10", 10 },
                    { 35, null, "Clubs", "9", 9 },
                    { 34, null, "Clubs", "8", 8 },
                    { 33, null, "Clubs", "7", 7 },
                    { 30, null, "Clubs", "4", 4 },
                    { 31, null, "Clubs", "5", 5 },
                    { 37, null, "Clubs", "Jack", 11 },
                    { 29, null, "Clubs", "3", 3 },
                    { 28, null, "Clubs", "2", 2 },
                    { 32, null, "Clubs", "6", 6 },
                    { 38, null, "Clubs", "Queen", 12 },
                    { 41, null, "Diamonds", "2", 2 },
                    { 40, null, "Diamonds", "Ace", 1 },
                    { 27, null, "Clubs", "Ace", 1 },
                    { 42, null, "Diamonds", "3", 3 },
                    { 43, null, "Diamonds", "4", 4 },
                    { 44, null, "Diamonds", "5", 5 },
                    { 45, null, "Diamonds", "6", 6 },
                    { 46, null, "Diamonds", "7", 7 },
                    { 47, null, "Diamonds", "8", 8 },
                    { 48, null, "Diamonds", "9", 9 },
                    { 49, null, "Diamonds", "10", 10 },
                    { 50, null, "Diamonds", "Jack", 11 },
                    { 39, null, "Clubs", "King", 13 },
                    { 26, null, "Hearts", "King", 13 },
                    { 23, null, "Hearts", "10", 10 },
                    { 24, null, "Hearts", "Jack", 11 },
                    { 1, null, "Spades", "Ace", 1 },
                    { 2, null, "Spades", "2", 2 },
                    { 3, null, "Spades", "3", 3 },
                    { 4, null, "Spades", "4", 4 },
                    { 5, null, "Spades", "5", 5 },
                    { 6, null, "Spades", "6", 6 },
                    { 7, null, "Spades", "7", 7 },
                    { 8, null, "Spades", "8", 8 },
                    { 9, null, "Spades", "9", 9 }
                });

            migrationBuilder.InsertData(
                table: "PlayingCards",
                columns: new[] { "PlayingCardId", "GamePlayId", "Suit", "Type", "Value" },
                values: new object[,]
                {
                    { 10, null, "Spades", "10", 10 },
                    { 11, null, "Spades", "Jack", 11 },
                    { 12, null, "Spades", "Queen", 12 },
                    { 13, null, "Spades", "King", 13 },
                    { 14, null, "Hearts", "Ace", 1 },
                    { 15, null, "Hearts", "2", 2 },
                    { 16, null, "Hearts", "3", 3 },
                    { 17, null, "Hearts", "4", 4 },
                    { 18, null, "Hearts", "5", 5 },
                    { 19, null, "Hearts", "6", 6 },
                    { 20, null, "Hearts", "7", 7 },
                    { 21, null, "Hearts", "8", 8 },
                    { 22, null, "Hearts", "9", 9 },
                    { 51, null, "Diamonds", "Queen", 12 },
                    { 25, null, "Hearts", "Queen", 12 },
                    { 52, null, "Diamonds", "King", 13 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlays_UserId",
                table: "GamePlays",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayTurns_TurnId",
                table: "GamePlayTurns",
                column: "TurnId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayingCards_GamePlayId",
                table: "PlayingCards",
                column: "GamePlayId");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "GamePlayTurns");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Turns");

            migrationBuilder.DropTable(
                name: "ActionTypes");

            migrationBuilder.DropTable(
                name: "GuessTypes");

            migrationBuilder.DropTable(
                name: "PlayingCards");

            migrationBuilder.DropTable(
                name: "GamePlays");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
