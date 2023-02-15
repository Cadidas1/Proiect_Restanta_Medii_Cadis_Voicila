using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Restanta_Medii_Cadis_Voicila.Migrations
{
    public partial class Reprezentanta1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReprezentantaID",
                table: "Masina",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Reprezentanta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeReprezentanta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reprezentanta", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Masina_ReprezentantaID",
                table: "Masina",
                column: "ReprezentantaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Masina_Reprezentanta_ReprezentantaID",
                table: "Masina",
                column: "ReprezentantaID",
                principalTable: "Reprezentanta",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Masina_Reprezentanta_ReprezentantaID",
                table: "Masina");

            migrationBuilder.DropTable(
                name: "Reprezentanta");

            migrationBuilder.DropIndex(
                name: "IX_Masina_ReprezentantaID",
                table: "Masina");

            migrationBuilder.DropColumn(
                name: "ReprezentantaID",
                table: "Masina");
        }
    }
}
