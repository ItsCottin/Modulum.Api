using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modulum.Api.Migrations
{
    /// <inheritdoc />
    public partial class addColumn2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                schema: "dbo",
                table: "tbl_user",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                schema: "dbo",
                table: "tbl_user");
        }
    }
}
