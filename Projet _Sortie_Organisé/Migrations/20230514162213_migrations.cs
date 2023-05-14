using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projet__Sortie_Organisé.Migrations
{
    public partial class migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cin",
                table: "Evenements",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Personnes",
                columns: table => new
                {
                    cin = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnes", x => x.cin);
                });

            migrationBuilder.CreateTable(
                name: "EvenementUtilisateur",
                columns: table => new
                {
                    evenementsidEvent = table.Column<int>(type: "int", nullable: false),
                    utilisateurscin = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvenementUtilisateur", x => new { x.evenementsidEvent, x.utilisateurscin });
                    table.ForeignKey(
                        name: "FK_EvenementUtilisateur_Evenements_evenementsidEvent",
                        column: x => x.evenementsidEvent,
                        principalTable: "Evenements",
                        principalColumn: "idEvent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvenementUtilisateur_Personnes_utilisateurscin",
                        column: x => x.utilisateurscin,
                        principalTable: "Personnes",
                        principalColumn: "cin",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evenements_cin",
                table: "Evenements",
                column: "cin");

            migrationBuilder.CreateIndex(
                name: "IX_EvenementUtilisateur_utilisateurscin",
                table: "EvenementUtilisateur",
                column: "utilisateurscin");

            migrationBuilder.AddForeignKey(
                name: "FK_Evenements_Personnes_cin",
                table: "Evenements",
                column: "cin",
                principalTable: "Personnes",
                principalColumn: "cin",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evenements_Personnes_cin",
                table: "Evenements");

            migrationBuilder.DropTable(
                name: "EvenementUtilisateur");

            migrationBuilder.DropTable(
                name: "Personnes");

            migrationBuilder.DropIndex(
                name: "IX_Evenements_cin",
                table: "Evenements");

            migrationBuilder.DropColumn(
                name: "cin",
                table: "Evenements");
        }
    }
}
