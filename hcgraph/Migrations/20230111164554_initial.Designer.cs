// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hcgraph.Domain.Models;

#nullable disable

namespace hcgraph.Migrations
{
    [DbContext(typeof(SampleDbContext))]
    [Migration("20230111164554_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("hcgraph.Domain.Models.Item", b =>
                {
                    b.Property<long>("RowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ItemNumber")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("RowId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            RowId = 1L,
                            ItemNumber = "Y_123",
                            LastModified = new DateTime(2023, 1, 11, 16, 45, 54, 850, DateTimeKind.Utc).AddTicks(4170),
                            Name = "Yeti Tumbler",
                            Price = 39.99m
                        },
                        new
                        {
                            RowId = 2L,
                            ItemNumber = "AF_234",
                            LastModified = new DateTime(2023, 1, 11, 16, 45, 54, 850, DateTimeKind.Utc).AddTicks(4180),
                            Name = "Air Fryer",
                            Price = 138.95m
                        });
                });

            modelBuilder.Entity("hcgraph.Domain.Models.Order", b =>
                {
                    b.Property<long>("RowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.HasKey("RowId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            RowId = 1L,
                            LastModified = new DateTime(2023, 1, 11, 16, 45, 54, 850, DateTimeKind.Utc).AddTicks(3270),
                            OrderDate = new DateTime(2023, 1, 11, 16, 45, 54, 850, DateTimeKind.Utc).AddTicks(3280),
                            OrderNumber = "Order_1"
                        },
                        new
                        {
                            RowId = 2L,
                            LastModified = new DateTime(2023, 1, 11, 16, 45, 54, 850, DateTimeKind.Utc).AddTicks(3280),
                            OrderDate = new DateTime(2023, 1, 11, 16, 45, 54, 850, DateTimeKind.Utc).AddTicks(3280),
                            OrderNumber = "Order_2"
                        });
                });

            modelBuilder.Entity("hcgraph.Domain.Models.OrderItem", b =>
                {
                    b.Property<long>("RowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("ItemId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<long>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("RowId");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            RowId = 1L,
                            ItemId = 1L,
                            LastModified = new DateTime(2023, 1, 11, 16, 45, 54, 850, DateTimeKind.Utc).AddTicks(3770),
                            OrderId = 1L,
                            Quantity = 3
                        },
                        new
                        {
                            RowId = 2L,
                            ItemId = 2L,
                            LastModified = new DateTime(2023, 1, 11, 16, 45, 54, 850, DateTimeKind.Utc).AddTicks(3780),
                            OrderId = 2L,
                            Quantity = 7
                        });
                });

            modelBuilder.Entity("hcgraph.Domain.Models.OrderItem", b =>
                {
                    b.HasOne("hcgraph.Domain.Models.Item", "Item")
                        .WithMany("OrderItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hcgraph.Domain.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("hcgraph.Domain.Models.Item", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("hcgraph.Domain.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
