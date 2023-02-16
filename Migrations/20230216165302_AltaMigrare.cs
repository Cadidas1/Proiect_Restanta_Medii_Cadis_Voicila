using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Restanta_Medii_Cadis_Voicila.Migrations
{
    public partial class AltaMigrare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Membru",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumarDeTelefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membru", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Inchiriere",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembruID = table.Column<int>(type: "int", nullable: true),
                    MasinaID = table.Column<int>(type: "int", nullable: true),
                    DataReturnarii = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inchiriere", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Inchiriere_Masina_MasinaID",
                        column: x => x.MasinaID,
                        principalTable: "Masina",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Inchiriere_Membru_MembruID",
                        column: x => x.MembruID,
                        principalTable: "Membru",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inchiriere_MasinaID",
                table: "Inchiriere",
                column: "MasinaID");

            migrationBuilder.CreateIndex(
                name: "IX_Inchiriere_MembruID",
                table: "Inchiriere",
                column: "MembruID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inchiriere");

            migrationBuilder.DropTable(
                name: "Membru");
        }
    }
}
