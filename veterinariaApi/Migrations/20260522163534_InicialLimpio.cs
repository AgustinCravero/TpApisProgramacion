using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace veterinariaApi.Migrations
{
    /// <inheritdoc />
    public partial class InicialLimpio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_Atenciones_Animales_AnimalId",
                table: "Atenciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Atenciones_Tratamientos_TratamientoId",
                table: "Atenciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Razas_TiposAnimales_TipoId",
                table: "Razas");

            migrationBuilder.DropIndex(
                name: "IX_Razas_TipoId",
                table: "Razas");

            migrationBuilder.DropIndex(
                name: "IX_Atenciones_AnimalId",
                table: "Atenciones");

            migrationBuilder.DropIndex(
                name: "IX_Atenciones_TratamientoId",
                table: "Atenciones");

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
                name: "TipoId",
                table: "Razas");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "Atenciones");

            migrationBuilder.DropColumn(
                name: "TratamientoId",
                table: "Atenciones");

            migrationBuilder.DropColumn(
                name: "DuenioId",
                table: "Animales");

            migrationBuilder.DropColumn(
                name: "RazaId",
                table: "Animales");

            migrationBuilder.DropColumn(
                name: "TipoId",
                table: "Animales");

            migrationBuilder.CreateIndex(
                name: "IX_Razas_IdTipo",
                table: "Razas",
                column: "IdTipo");

            migrationBuilder.CreateIndex(
                name: "IX_Atenciones_IdAnimal",
                table: "Atenciones",
                column: "IdAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_Atenciones_IdTratamiento",
                table: "Atenciones",
                column: "IdTratamiento");

            migrationBuilder.CreateIndex(
                name: "IX_Animales_IdDuenio",
                table: "Animales",
                column: "IdDuenio");

            migrationBuilder.CreateIndex(
                name: "IX_Animales_IdRaza",
                table: "Animales",
                column: "IdRaza");

            migrationBuilder.CreateIndex(
                name: "IX_Animales_IdTipo",
                table: "Animales",
                column: "IdTipo");

            migrationBuilder.AddForeignKey(
                name: "FK_Animales_Duenios_IdDuenio",
                table: "Animales",
                column: "IdDuenio",
                principalTable: "Duenios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Animales_Razas_IdRaza",
                table: "Animales",
                column: "IdRaza",
                principalTable: "Razas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Animales_TiposAnimales_IdTipo",
                table: "Animales",
                column: "IdTipo",
                principalTable: "TiposAnimales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Atenciones_Animales_IdAnimal",
                table: "Atenciones",
                column: "IdAnimal",
                principalTable: "Animales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Atenciones_Tratamientos_IdTratamiento",
                table: "Atenciones",
                column: "IdTratamiento",
                principalTable: "Tratamientos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Razas_TiposAnimales_IdTipo",
                table: "Razas",
                column: "IdTipo",
                principalTable: "TiposAnimales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animales_Duenios_IdDuenio",
                table: "Animales");

            migrationBuilder.DropForeignKey(
                name: "FK_Animales_Razas_IdRaza",
                table: "Animales");

            migrationBuilder.DropForeignKey(
                name: "FK_Animales_TiposAnimales_IdTipo",
                table: "Animales");

            migrationBuilder.DropForeignKey(
                name: "FK_Atenciones_Animales_IdAnimal",
                table: "Atenciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Atenciones_Tratamientos_IdTratamiento",
                table: "Atenciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Razas_TiposAnimales_IdTipo",
                table: "Razas");

            migrationBuilder.DropIndex(
                name: "IX_Razas_IdTipo",
                table: "Razas");

            migrationBuilder.DropIndex(
                name: "IX_Atenciones_IdAnimal",
                table: "Atenciones");

            migrationBuilder.DropIndex(
                name: "IX_Atenciones_IdTratamiento",
                table: "Atenciones");

            migrationBuilder.DropIndex(
                name: "IX_Animales_IdDuenio",
                table: "Animales");

            migrationBuilder.DropIndex(
                name: "IX_Animales_IdRaza",
                table: "Animales");

            migrationBuilder.DropIndex(
                name: "IX_Animales_IdTipo",
                table: "Animales");

            migrationBuilder.AddColumn<int>(
                name: "TipoId",
                table: "Razas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnimalId",
                table: "Atenciones",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TratamientoId",
                table: "Atenciones",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Razas_TipoId",
                table: "Razas",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Atenciones_Animales_AnimalId",
                table: "Atenciones",
                column: "AnimalId",
                principalTable: "Animales",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Atenciones_Tratamientos_TratamientoId",
                table: "Atenciones",
                column: "TratamientoId",
                principalTable: "Tratamientos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Razas_TiposAnimales_TipoId",
                table: "Razas",
                column: "TipoId",
                principalTable: "TiposAnimales",
                principalColumn: "Id");
        }
    }
}
