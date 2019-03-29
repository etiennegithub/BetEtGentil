using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BetEtMechant.Migrations
{
    public partial class AddChampionship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChampionshipID",
                table: "Teams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "Logo",
                table: "Teams",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Teams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Championships",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championships", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ChampionshipID",
                table: "Teams",
                column: "ChampionshipID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Championships_ChampionshipID",
                table: "Teams",
                column: "ChampionshipID",
                principalTable: "Championships",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Championships_ChampionshipID",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "Championships");

            migrationBuilder.DropIndex(
                name: "IX_Teams_ChampionshipID",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ChampionshipID",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Teams");
        }
    }
}
