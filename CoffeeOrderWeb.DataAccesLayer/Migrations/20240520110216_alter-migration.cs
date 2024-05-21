using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeOrderWeb.DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class altermigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cash",
                table: "PaymentInformations");

            migrationBuilder.DropColumn(
                name: "PaymentAtAdress",
                table: "PaymentInformations");

            migrationBuilder.AddColumn<string>(
                name: "CashOrPayAtAdress",
                table: "PaymentInformations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CashOrPayAtAdress",
                table: "PaymentInformations");

            migrationBuilder.AddColumn<bool>(
                name: "Cash",
                table: "PaymentInformations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PaymentAtAdress",
                table: "PaymentInformations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
