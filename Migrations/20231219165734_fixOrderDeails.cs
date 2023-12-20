using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_Dev_1670.Migrations
{
    /// <inheritdoc />
    public partial class fixOrderDeails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserOrder_Order_ListOrdersOrderID",
                table: "ApplicationUserOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Payments_PaymentID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Order_OrderID",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "OrderHeader");

            migrationBuilder.RenameIndex(
                name: "IX_Order_PaymentID",
                table: "OrderHeader",
                newName: "IX_OrderHeader_PaymentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderHeader",
                table: "OrderHeader",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserOrder_OrderHeader_ListOrdersOrderID",
                table: "ApplicationUserOrder",
                column: "ListOrdersOrderID",
                principalTable: "OrderHeader",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_OrderHeader_OrderID",
                table: "OrderDetails",
                column: "OrderID",
                principalTable: "OrderHeader",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeader_Payments_PaymentID",
                table: "OrderHeader",
                column: "PaymentID",
                principalTable: "Payments",
                principalColumn: "PaymentID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserOrder_OrderHeader_ListOrdersOrderID",
                table: "ApplicationUserOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_OrderHeader_OrderID",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeader_Payments_PaymentID",
                table: "OrderHeader");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderHeader",
                table: "OrderHeader");

            migrationBuilder.RenameTable(
                name: "OrderHeader",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_OrderHeader_PaymentID",
                table: "Order",
                newName: "IX_Order_PaymentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserOrder_Order_ListOrdersOrderID",
                table: "ApplicationUserOrder",
                column: "ListOrdersOrderID",
                principalTable: "Order",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Payments_PaymentID",
                table: "Order",
                column: "PaymentID",
                principalTable: "Payments",
                principalColumn: "PaymentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Order_OrderID",
                table: "OrderDetails",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
