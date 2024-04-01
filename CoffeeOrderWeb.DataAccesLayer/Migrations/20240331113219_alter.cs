using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeOrderWeb.DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class alter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "OrderDetails");
        }
    }
}
