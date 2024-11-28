using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscalaWebMvc.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarEscala : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Escala",
                table: "Escala");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Escala");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Escala",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Escala");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Escala",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Escala",
                table: "Escala",
                column: "Id");
        }
    }
}
