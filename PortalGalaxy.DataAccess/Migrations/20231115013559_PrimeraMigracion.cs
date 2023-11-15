using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PortalGalaxy.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroDocumento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NombreCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Departamento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Distrito = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaInscripcion = table.Column<DateTime>(type: "DATE", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NroDocumento = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructor_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Taller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "DATE", nullable: false),
                    HoraInicio = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Situacion = table.Column<int>(type: "int", nullable: false),
                    PortadaUrl = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    TemarioUrl = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taller", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taller_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Taller_Instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Inscripcion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlumnoId = table.Column<int>(type: "int", nullable: false),
                    TallerId = table.Column<int>(type: "int", nullable: false),
                    Situacion = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripcion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscripcion_Alumno_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumno",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inscripcion_Taller_TallerId",
                        column: x => x.TallerId,
                        principalTable: "Taller",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Id", "Estado", "FechaCreacion", "Nombre" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), ".NET" },
                    { 2, true, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Java" },
                    { 3, true, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AWS" },
                    { 4, true, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Azure" },
                    { 5, true, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Python" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_AlumnoId",
                table: "Inscripcion",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_TallerId",
                table: "Inscripcion",
                column: "TallerId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_CategoriaId",
                table: "Instructor",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Taller_CategoriaId",
                table: "Taller",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Taller_InstructorId",
                table: "Taller",
                column: "InstructorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscripcion");

            migrationBuilder.DropTable(
                name: "Alumno");

            migrationBuilder.DropTable(
                name: "Taller");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
