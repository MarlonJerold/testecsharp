using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class NovoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacina_Posto_PostoId",
                table: "Vacina");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vacina",
                table: "Vacina");

            migrationBuilder.RenameTable(
                name: "Vacina",
                newName: "Vacinas");

            migrationBuilder.RenameIndex(
                name: "IX_Vacina_PostoId",
                table: "Vacinas",
                newName: "IX_Vacinas_PostoId");

            migrationBuilder.AlterColumn<Guid>(
                name: "PostoId",
                table: "Vacinas",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vacinas",
                table: "Vacinas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Vacinas_Posto_PostoId",
                table: "Vacinas",
                column: "PostoId",
                principalTable: "Posto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacinas_Posto_PostoId",
                table: "Vacinas");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vacinas",
                table: "Vacinas");

            migrationBuilder.RenameTable(
                name: "Vacinas",
                newName: "Vacina");

            migrationBuilder.RenameIndex(
                name: "IX_Vacinas_PostoId",
                table: "Vacina",
                newName: "IX_Vacina_PostoId");

            migrationBuilder.AlterColumn<Guid>(
                name: "PostoId",
                table: "Vacina",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vacina",
                table: "Vacina",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacina_Posto_PostoId",
                table: "Vacina",
                column: "PostoId",
                principalTable: "Posto",
                principalColumn: "Id");
        }
    }
}
