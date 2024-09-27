using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Migrations
{
    /// <inheritdoc />
    public partial class dd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "item_master",
                columns: table => new
                {
                    productId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    itemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    entryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    disPer = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    entryBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_master", x => x.productId);
                });

            migrationBuilder.CreateTable(
                name: "sales_booking",
                columns: table => new
                {
                    bookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    trnno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    totalAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    extraCarringCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    bookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    specialDiscPer = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    specialDisAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    bokingPrefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    payment = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales_booking", x => x.bookingId);
                });

            migrationBuilder.CreateTable(
                name: "sales_booking_details",
                columns: table => new
                {
                    bookinDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookingId = table.Column<int>(type: "int", nullable: false),
                    trnno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    productCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    rete = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    productDisPer = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    productDisAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    lineAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sales_bookingbookingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales_booking_details", x => x.bookinDetailsId);
                    table.ForeignKey(
                        name: "FK_sales_booking_details_sales_booking_sales_bookingbookingId",
                        column: x => x.sales_bookingbookingId,
                        principalTable: "sales_booking",
                        principalColumn: "bookingId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_sales_booking_details_sales_bookingbookingId",
                table: "sales_booking_details",
                column: "sales_bookingbookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "item_master");

            migrationBuilder.DropTable(
                name: "sales_booking_details");

            migrationBuilder.DropTable(
                name: "sales_booking");
        }
    }
}
