using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Migrations
{
    /// <inheritdoc />
    public partial class fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    cusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cusEntrydate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cusEntryBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.cusId);
                });

            migrationBuilder.CreateTable(
                name: "delivery_details",
                columns: table => new
                {
                    deliveryDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deliveryId = table.Column<int>(type: "int", nullable: false),
                    deliveryNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    productCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery_details", x => x.deliveryDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "delivery_head",
                columns: table => new
                {
                    deliveryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deliveryNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bookingNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    totalDeliveryQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    deliveredBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deliveryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    customerCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery_head", x => x.deliveryId);
                });

            migrationBuilder.CreateTable(
                name: "product_stock",
                columns: table => new
                {
                    stock_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<int>(type: "int", nullable: false),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stockQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    lastUpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_stock", x => x.stock_id);
                });

            migrationBuilder.CreateTable(
                name: "purchase_order",
                columns: table => new
                {
                    purId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    trnno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    totalAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    extraCarringCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    bookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    specialDiscPer = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    specialDisAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    purchsePrefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    payment = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchase_order", x => x.purId);
                });

            migrationBuilder.CreateTable(
                name: "purchase_order_details",
                columns: table => new
                {
                    purDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    purId = table.Column<int>(type: "int", nullable: false),
                    trnno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    productCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    productDisPer = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    productDisAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    lineAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchase_order_details", x => x.purDetailsId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "delivery_details");

            migrationBuilder.DropTable(
                name: "delivery_head");

            migrationBuilder.DropTable(
                name: "product_stock");

            migrationBuilder.DropTable(
                name: "purchase_order");

            migrationBuilder.DropTable(
                name: "purchase_order_details");
        }
    }
}
