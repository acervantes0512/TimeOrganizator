using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class updateTipoTiempo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoProyectoId",
                table: "TiposTiempo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TiposTiempo_TipoProyectoId",
                table: "TiposTiempo",
                column: "TipoProyectoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TiposTiempo_TiposProyecto_TipoProyectoId",
                table: "TiposTiempo",
                column: "TipoProyectoId",
                principalTable: "TiposProyecto",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TiposTiempo_TiposProyecto_TipoProyectoId",
                table: "TiposTiempo");

            migrationBuilder.DropIndex(
                name: "IX_TiposTiempo_TipoProyectoId",
                table: "TiposTiempo");

            migrationBuilder.DropColumn(
                name: "TipoProyectoId",
                table: "TiposTiempo");
        }
    }
}
