using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalGalaxy.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DescripcionEnTaller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Taller",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Taller");
        }
    }
}
