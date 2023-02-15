using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Restanta_Medii_Cadis_Voicila.Migrations
{
    public partial class agentinchirieri123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgentInchirieri",
                table: "Masina");

            migrationBuilder.AddColumn<int>(
                name: "AgentInchirieriID",
                table: "Masina",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Masina_AgentInchirieriID",
                table: "Masina",
                column: "AgentInchirieriID");

            migrationBuilder.AddForeignKey(
                name: "FK_Masina_AgentInchirieri_AgentInchirieriID",
                table: "Masina",
                column: "AgentInchirieriID",
                principalTable: "AgentInchirieri",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Masina_AgentInchirieri_AgentInchirieriID",
                table: "Masina");

            migrationBuilder.DropIndex(
                name: "IX_Masina_AgentInchirieriID",
                table: "Masina");

            migrationBuilder.DropColumn(
                name: "AgentInchirieriID",
                table: "Masina");

            migrationBuilder.AddColumn<string>(
                name: "AgentInchirieri",
                table: "Masina",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
