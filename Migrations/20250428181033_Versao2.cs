using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modulum.Api.Migrations
{
    /// <inheritdoc />
    public partial class Versao2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                schema: "dbo",
                table: "tbl_table",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_table_IdUsuario",
                schema: "dbo",
                table: "tbl_table",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_table_tbl_user_IdUsuario",
                schema: "dbo",
                table: "tbl_table",
                column: "IdUsuario",
                principalSchema: "dbo",
                principalTable: "tbl_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_table_tbl_user_IdUsuario",
                schema: "dbo",
                table: "tbl_table");

            migrationBuilder.DropIndex(
                name: "IX_tbl_table_IdUsuario",
                schema: "dbo",
                table: "tbl_table");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                schema: "dbo",
                table: "tbl_table");
        }
    }
}
