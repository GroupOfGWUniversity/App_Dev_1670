using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_Dev_1670.Migrations
{
    /// <inheritdoc />
    public partial class updateTableOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeader_Payments_PaymentID",
                table: "OrderHeader");

            migrationBuilder.DropTable(
                name: "ApplicationUserOrder");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_OrderHeader_PaymentID",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "PaymentID",
                table: "OrderHeader");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserID",
                table: "OrderHeader",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                table: "OrderHeader",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDueDate",
                table: "OrderHeader",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PaymentIntentId",
                table: "OrderHeader",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "OrderHeader",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeader_ApplicationUserID",
                table: "OrderHeader",
                column: "ApplicationUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeader_AspNetUsers_ApplicationUserID",
                table: "OrderHeader",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeader_AspNetUsers_ApplicationUserID",
                table: "OrderHeader");

            migrationBuilder.DropIndex(
                name: "IX_OrderHeader_ApplicationUserID",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "ApplicationUserID",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "PaymentDueDate",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "PaymentIntentId",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "OrderHeader");

            migrationBuilder.AddColumn<int>(
                name: "PaymentID",
                table: "OrderHeader",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ApplicationUserOrder",
                columns: table => new
                {
                    ListOfUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ListOrdersOrderID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserOrder", x => new { x.ListOfUsersId, x.ListOrdersOrderID });
                    table.ForeignKey(
                        name: "FK_ApplicationUserOrder_AspNetUsers_ListOfUsersId",
                        column: x => x.ListOfUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserOrder_OrderHeader_ListOrdersOrderID",
                        column: x => x.ListOrdersOrderID,
                        principalTable: "OrderHeader",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeader_PaymentID",
                table: "OrderHeader",
                column: "PaymentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserOrder_ListOrdersOrderID",
                table: "ApplicationUserOrder",
                column: "ListOrdersOrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeader_Payments_PaymentID",
                table: "OrderHeader",
                column: "PaymentID",
                principalTable: "Payments",
                principalColumn: "PaymentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
