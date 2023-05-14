using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projet.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evenements",
                columns: table => new
                {
                    idEvent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<float>(type: "real", nullable: false),
                    dateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nombreMax = table.Column<int>(type: "int", nullable: false),
                    descriptionEvent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nomEvent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prix = table.Column<float>(type: "real", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evenements", x => x.idEvent);
                });

            migrationBuilder.CreateTable(
                name: "Villes",
                columns: table => new
                {
                    idVille = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomVille = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codePostal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villes", x => x.idVille);
                });

            migrationBuilder.CreateTable(
                name: "Activites",
                columns: table => new
                {
                    idActivite = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descriptionAct = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nomActivite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idEvent = table.Column<int>(type: "int", nullable: false),
                    idVille = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activites", x => x.idActivite);
                    table.ForeignKey(
                        name: "FK_Activites_Evenements_idEvent",
                        column: x => x.idEvent,
                        principalTable: "Evenements",
                        principalColumn: "idEvent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activites_Villes_idVille",
                        column: x => x.idVille,
                        principalTable: "Villes",
                        principalColumn: "idVille",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activites_idEvent",
                table: "Activites",
                column: "idEvent");

            migrationBuilder.CreateIndex(
                name: "IX_Activites_idVille",
                table: "Activites",
                column: "idVille");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activites");

            migrationBuilder.DropTable(
                name: "Evenements");

            migrationBuilder.DropTable(
                name: "Villes");
        }
    }
}
