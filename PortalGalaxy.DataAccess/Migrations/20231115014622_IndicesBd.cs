using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalGalaxy.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class IndicesBd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Taller_Nombre",
                table: "Taller",
                column: "Nombre");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_NroDocumento",
                table: "Instructor",
                column: "NroDocumento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Taller_Nombre",
                table: "Taller");

            migrationBuilder.DropIndex(
                name: "IX_Instructor_NroDocumento",
                table: "Instructor");
        }
    }
}
