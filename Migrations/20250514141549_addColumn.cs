using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modulum.Api.Migrations
{
    /// <inheritdoc />
    public partial class addColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsObrigatorio",
                schema: "dbo",
                table: "tbl_relationship",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsObrigatorio",
                schema: "dbo",
                table: "tbl_relationship");
        }
    }
}
