﻿// <auto-generated />
using System;
using Inventory.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inventory.Migrations
{
    [DbContext(typeof(MyDbContex))]
    partial class MyDbContexModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Inventory.Model.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userId"));

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("isActive")
                        .HasColumnType("int");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Inventory.Model.customer", b =>
                {
                    b.Property<int>("cusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cusId"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cusEntryBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("cusEntrydate")
                        .HasColumnType("datetime2");

                    b.Property<string>("customerCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customerPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cusId");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("Inventory.Model.delivery_details", b =>
                {
                    b.Property<int>("deliveryDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("deliveryDetailsId"));

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("deliveryId")
                        .HasColumnType("int");

                    b.Property<string>("deliveryNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("quantity")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("deliveryDetailsId");

                    b.ToTable("delivery_details");
                });

            modelBuilder.Entity("Inventory.Model.delivery_head", b =>
                {
                    b.Property<int>("deliveryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("deliveryId"));

                    b.Property<string>("bookingNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customerCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("deliveredBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("deliveryNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("deliveryTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("totalDeliveryQty")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("deliveryId");

                    b.ToTable("delivery_head");
                });

            modelBuilder.Entity("Inventory.Model.item_master", b =>
                {
                    b.Property<int>("productId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("productId"));

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("disPer")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("entryBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("entryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("itemCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("itemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("productId");

                    b.ToTable("item_master");
                });

            modelBuilder.Entity("Inventory.Model.product_stock", b =>
                {
                    b.Property<int>("stock_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("stock_id"));

                    b.Property<string>("lastUpdateBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("lastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("productCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("stockQty")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("stock_id");

                    b.ToTable("product_stock");
                });

            modelBuilder.Entity("Inventory.Model.purchase_order", b =>
                {
                    b.Property<int>("purId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("purId"));

                    b.Property<DateTime>("bookingDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("extraCarringCharge")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("payment")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("purchsePrefix")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("remarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("specialDisAmt")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("specialDiscPer")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("totalAmt")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("trnno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("purId");

                    b.ToTable("purchase_order");
                });

            modelBuilder.Entity("Inventory.Model.purchase_order_details", b =>
                {
                    b.Property<int>("purDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("purDetailsId"));

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("lineAmt")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("productCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("productDisAmt")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("productDisPer")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("purId")
                        .HasColumnType("int");

                    b.Property<decimal>("quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("trnno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("purDetailsId");

                    b.ToTable("purchase_order_details");
                });

            modelBuilder.Entity("Inventory.Model.sales_booking", b =>
                {
                    b.Property<int>("bookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("bookingId"));

                    b.Property<string>("bokingPrefix")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("bookingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("customerCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("extraCarringCharge")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("payment")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("remarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("specialDisAmt")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("specialDiscPer")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("totalAmt")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("trnno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("bookingId");

                    b.ToTable("sales_booking");
                });

            modelBuilder.Entity("Inventory.Model.sales_booking_details", b =>
                {
                    b.Property<int>("bookinDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("bookinDetailsId"));

                    b.Property<int>("bookingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("lineAmt")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("productCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("productDisAmt")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("productDisPer")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("rete")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("sales_bookingbookingId")
                        .HasColumnType("int");

                    b.Property<string>("trnno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("bookinDetailsId");

                    b.HasIndex("sales_bookingbookingId");

                    b.ToTable("sales_booking_details");
                });

            modelBuilder.Entity("Inventory.Model.sales_booking_details", b =>
                {
                    b.HasOne("Inventory.Model.sales_booking", null)
                        .WithMany("bookingDetails")
                        .HasForeignKey("sales_bookingbookingId");
                });

            modelBuilder.Entity("Inventory.Model.sales_booking", b =>
                {
                    b.Navigation("bookingDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
