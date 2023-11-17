using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalGalaxy.DataAccess.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class CustomizeSecurity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LockoutEnd",
                table: "Usuario",
                newName: "BloqueoHasta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BloqueoHasta",
                table: "Usuario",
                newName: "LockoutEnd");
        }
    }
}
