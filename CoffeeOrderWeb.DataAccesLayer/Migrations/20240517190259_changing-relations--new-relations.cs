using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeOrderWeb.DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class changingrelationsnewrelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentInformations_AspNetUsers_UserId",
                table: "PaymentInformations");

            migrationBuilder.DropIndex(
                name: "IX_PaymentInformations_UserId",
                table: "PaymentInformations");

            migrationBuilder.DropColumn(
                name: "CreditCartCvv",
                table: "PaymentInformations");

            migrationBuilder.DropColumn(
                name: "CreditCartDate",
                table: "PaymentInformations");

            migrationBuilder.DropColumn(
                name: "CreditCartName",
                table: "PaymentInformations");

            migrationBuilder.DropColumn(
                name: "CreditCartNo",
                table: "PaymentInformations");

            migrationBuilder.DropColumn(
                name: "CreditCartType",
                table: "PaymentInformations");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PaymentInformations",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "IsSaved",
                table: "PaymentInformations",
                newName: "PaymentConfirmed");

            migrationBuilder.AddColumn<bool>(
                name: "Cash",
                table: "PaymentInformations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CreditCard",
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

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardCvv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCards_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInformations_OrderId",
                table: "PaymentInformations",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_UserId",
                table: "CreditCards",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentInformations_Orders_OrderId",
                table: "PaymentInformations",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentInformations_Orders_OrderId",
                table: "PaymentInformations");

            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropIndex(
                name: "IX_PaymentInformations_OrderId",
                table: "PaymentInformations");

            migrationBuilder.DropColumn(
                name: "Cash",
                table: "PaymentInformations");

            migrationBuilder.DropColumn(
                name: "CreditCard",
                table: "PaymentInformations");

            migrationBuilder.DropColumn(
                name: "PaymentAtAdress",
                table: "PaymentInformations");

            migrationBuilder.RenameColumn(
                name: "PaymentConfirmed",
                table: "PaymentInformations",
                newName: "IsSaved");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "PaymentInformations",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "CreditCartCvv",
                table: "PaymentInformations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreditCartDate",
                table: "PaymentInformations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreditCartName",
                table: "PaymentInformations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreditCartNo",
                table: "PaymentInformations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreditCartType",
                table: "PaymentInformations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInformations_UserId",
                table: "PaymentInformations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentInformations_AspNetUsers_UserId",
                table: "PaymentInformations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
