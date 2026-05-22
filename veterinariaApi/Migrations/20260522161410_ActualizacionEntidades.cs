using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace veterinariaApi.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdTipo",
                table: "Animales",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DuenioId",
                table: "Animales",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RazaId",
                table: "Animales",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoId",
                table: "Animales",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Duenios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duenios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposAnimales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposAnimales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tratamientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tratamientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Razas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipo = table.Column<int>(type: "int", nullable: false),
                    TipoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Razas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Razas_TiposAnimales_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TiposAnimales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Atenciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTratamiento = table.Column<int>(type: "int", nullable: false),
                    TratamientoId = table.Column<int>(type: "int", nullable: true),
                    Medicamentos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdAnimal = table.Column<int>(type: "int", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atenciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atenciones_Animales_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animales",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Atenciones_Tratamientos_TratamientoId",
                        column: x => x.TratamientoId,
                        principalTable: "Tratamientos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animales_DuenioId",
                table: "Animales",
                column: "DuenioId");

            migrationBuilder.CreateIndex(
                name: "IX_Animales_RazaId",
                table: "Animales",
                column: "RazaId");

            migrationBuilder.CreateIndex(
                name: "IX_Animales_TipoId",
                table: "Animales",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Atenciones_AnimalId",
                table: "Atenciones",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Atenciones_TratamientoId",
                table: "Atenciones",
                column: "TratamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Razas_TipoId",
                table: "Razas",
                column: "TipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animales_Duenios_DuenioId",
                table: "Animales",
                column: "DuenioId",
                principalTable: "Duenios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Animales_Razas_RazaId",
                table: "Animales",
                column: "RazaId",
                principalTable: "Razas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Animales_TiposAnimales_TipoId",
                table: "Animales",
                column: "TipoId",
                principalTable: "TiposAnimales",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animales_Duenios_DuenioId",
                table: "Animales");

            migrationBuilder.DropForeignKey(
                name: "FK_Animales_Razas_RazaId",
                table: "Animales");

            migrationBuilder.DropForeignKey(
                name: "FK_Animales_TiposAnimales_TipoId",
                table: "Animales");

            migrationBuilder.DropTable(
                name: "Atenciones");

            migrationBuilder.DropTable(
                name: "Duenios");

            migrationBuilder.DropTable(
                name: "Razas");

            migrationBuilder.DropTable(
                name: "Tratamientos");

            migrationBuilder.DropTable(
                name: "TiposAnimales");

            migrationBuilder.DropIndex(
                name: "IX_Animales_DuenioId",
                table: "Animales");

            migrationBuilder.DropIndex(
                name: "IX_Animales_RazaId",
                table: "Animales");

            migrationBuilder.DropIndex(
                name: "IX_Animales_TipoId",
                table: "Animales");

            migrationBuilder.DropColumn(
                name: "DuenioId",
                table: "Animales");

            migrationBuilder.DropColumn(
                name: "RazaId",
                table: "Animales");

            migrationBuilder.DropColumn(
                name: "TipoId",
                table: "Animales");

            migrationBuilder.AlterColumn<string>(
                name: "IdTipo",
                table: "Animales",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
