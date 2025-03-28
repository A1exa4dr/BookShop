using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop.Migrations
{
    /// <inheritdoc />
    public partial class migr3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PaymentTypes_PaymentTypeId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentTypeId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AverageRating",
                table: "Books",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PaymentTypes_PaymentTypeId",
                table: "Orders",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "PaymentTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PaymentTypes_PaymentTypeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentTypeId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PaymentTypes_PaymentTypeId",
                table: "Orders",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "PaymentTypeId");
        }
    }
}
