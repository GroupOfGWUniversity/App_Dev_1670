using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_Dev_1670.Migrations
{
    /// <inheritdoc />
    public partial class updateDatabaseBaseOnERD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookOrder_Books_BooksBookID",
                table: "BookOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_BookOrder_Order_OrdersOrderID",
                table: "BookOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Sellers_SellerID",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customers_CustomerID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Sellers_SellerID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Order_OrderID",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "BookCustomer");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Payments_OrderID",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_SellerID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "SellerID",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "OrdersOrderID",
                table: "BookOrder",
                newName: "ListOfOrdersOrderID");

            migrationBuilder.RenameColumn(
                name: "BooksBookID",
                table: "BookOrder",
                newName: "BooksInOrderBookID");

            migrationBuilder.RenameIndex(
                name: "IX_BookOrder_OrdersOrderID",
                table: "BookOrder",
                newName: "IX_BookOrder_ListOfOrdersOrderID");

            migrationBuilder.AddColumn<int>(
                name: "PaymentID",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "SellerID",
                table: "Books",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "Condition",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AvatarUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    BooksInCartBookID = table.Column<int>(type: "int", nullable: false),
                    ListOfCustomersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => new { x.BooksInCartBookID, x.ListOfCustomersId });
                    table.ForeignKey(
                        name: "FK_Cart_AspNetUsers_ListOfCustomersId",
                        column: x => x.ListOfCustomersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cart_Books_BooksInCartBookID",
                        column: x => x.BooksInCartBookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderUser",
                columns: table => new
                {
                    ListOfUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ListOrdersOrderID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderUser", x => new { x.ListOfUsersId, x.ListOrdersOrderID });
                    table.ForeignKey(
                        name: "FK_OrderUser_AspNetUsers_ListOfUsersId",
                        column: x => x.ListOfUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderUser_Order_ListOrdersOrderID",
                        column: x => x.ListOrdersOrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentID",
                table: "Order",
                column: "PaymentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ListOfCustomersId",
                table: "Cart",
                column: "ListOfCustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderUser_ListOrdersOrderID",
                table: "OrderUser",
                column: "ListOrdersOrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookOrder_Books_BooksInOrderBookID",
                table: "BookOrder",
                column: "BooksInOrderBookID",
                principalTable: "Books",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookOrder_Order_ListOfOrdersOrderID",
                table: "BookOrder",
                column: "ListOfOrdersOrderID",
                principalTable: "Order",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_AspNetUsers_SellerID",
                table: "Books",
                column: "SellerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Payments_PaymentID",
                table: "Order",
                column: "PaymentID",
                principalTable: "Payments",
                principalColumn: "PaymentID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookOrder_Books_BooksInOrderBookID",
                table: "BookOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_BookOrder_Order_ListOfOrdersOrderID",
                table: "BookOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_AspNetUsers_SellerID",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Payments_PaymentID",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "OrderUser");

            migrationBuilder.DropIndex(
                name: "IX_Order_PaymentID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PaymentID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "AvatarUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ListOfOrdersOrderID",
                table: "BookOrder",
                newName: "OrdersOrderID");

            migrationBuilder.RenameColumn(
                name: "BooksInOrderBookID",
                table: "BookOrder",
                newName: "BooksBookID");

            migrationBuilder.RenameIndex(
                name: "IX_BookOrder_ListOfOrdersOrderID",
                table: "BookOrder",
                newName: "IX_BookOrder_OrdersOrderID");

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SellerID",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SellerID",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Condition",
                table: "Books",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    SellerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.SellerID);
                });

            migrationBuilder.CreateTable(
                name: "BookCustomer",
                columns: table => new
                {
                    BooksBookID = table.Column<int>(type: "int", nullable: false),
                    CustomersCustomerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCustomer", x => new { x.BooksBookID, x.CustomersCustomerID });
                    table.ForeignKey(
                        name: "FK_BookCustomer_Books_BooksBookID",
                        column: x => x.BooksBookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCustomer_Customers_CustomersCustomerID",
                        column: x => x.CustomersCustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderID",
                table: "Payments",
                column: "OrderID",
                unique: true,
                filter: "[OrderID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerID",
                table: "Order",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_SellerID",
                table: "Order",
                column: "SellerID");

            migrationBuilder.CreateIndex(
                name: "IX_BookCustomer_CustomersCustomerID",
                table: "BookCustomer",
                column: "CustomersCustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookOrder_Books_BooksBookID",
                table: "BookOrder",
                column: "BooksBookID",
                principalTable: "Books",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookOrder_Order_OrdersOrderID",
                table: "BookOrder",
                column: "OrdersOrderID",
                principalTable: "Order",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Sellers_SellerID",
                table: "Books",
                column: "SellerID",
                principalTable: "Sellers",
                principalColumn: "SellerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customers_CustomerID",
                table: "Order",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Sellers_SellerID",
                table: "Order",
                column: "SellerID",
                principalTable: "Sellers",
                principalColumn: "SellerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Order_OrderID",
                table: "Payments",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "OrderID");
        }
    }
}
