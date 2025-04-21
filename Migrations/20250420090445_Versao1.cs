using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modulum.Api.Migrations
{
    /// <inheritdoc />
    public partial class Versao1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                schema: "dbo",
                table: "tbl_versao");

            migrationBuilder.DropColumn(
                name: "Versao",
                schema: "dbo",
                table: "tbl_versao");

            migrationBuilder.AddColumn<string>(
                name: "Framework",
                schema: "dbo",
                table: "tbl_versao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pacote",
                schema: "dbo",
                table: "tbl_versao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PacoteRaiz",
                schema: "dbo",
                table: "tbl_versao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RequestedVersion",
                schema: "dbo",
                table: "tbl_versao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResolvedVersion",
                schema: "dbo",
                table: "tbl_versao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Framework",
                schema: "dbo",
                table: "tbl_versao");

            migrationBuilder.DropColumn(
                name: "Pacote",
                schema: "dbo",
                table: "tbl_versao");

            migrationBuilder.DropColumn(
                name: "PacoteRaiz",
                schema: "dbo",
                table: "tbl_versao");

            migrationBuilder.DropColumn(
                name: "RequestedVersion",
                schema: "dbo",
                table: "tbl_versao");

            migrationBuilder.DropColumn(
                name: "ResolvedVersion",
                schema: "dbo",
                table: "tbl_versao");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                schema: "dbo",
                table: "tbl_versao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Versao",
                schema: "dbo",
                table: "tbl_versao",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
