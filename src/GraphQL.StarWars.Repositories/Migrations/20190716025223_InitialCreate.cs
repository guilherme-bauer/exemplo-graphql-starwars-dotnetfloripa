﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQL.StarWars.Repositories.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    PrimaryFunction = table.Column<string>(nullable: true),
                    HomePlanetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Planets_HomePlanetId",
                        column: x => x.HomePlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterFriends",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false),
                    FriendId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterFriends", x => new { x.CharacterId, x.FriendId });
                    table.ForeignKey(
                        name: "FK_CharacterFriends_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharacterFriends_Characters_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    HeroId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episodes_Characters_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterEpisodes",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false),
                    EpisodeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterEpisodes", x => new { x.CharacterId, x.EpisodeId });
                    table.ForeignKey(
                        name: "FK_CharacterEpisodes_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharacterEpisodes_Episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterEpisodes_EpisodeId",
                table: "CharacterEpisodes",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterFriends_FriendId",
                table: "CharacterFriends",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_HomePlanetId",
                table: "Characters",
                column: "HomePlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_HeroId",
                table: "Episodes",
                column: "HeroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterEpisodes");

            migrationBuilder.DropTable(
                name: "CharacterFriends");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Planets");
        }
    }
}
