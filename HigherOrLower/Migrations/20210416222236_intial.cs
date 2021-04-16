using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HigherOrLower.Migrations
{
    public partial class intial : Migration
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
                name: "IX_GamePlayTurns_TurnId",
                table: "GamePlayTurns",
                column: "TurnId");

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
                name: "AspNetUsers");

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
