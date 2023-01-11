using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace hcgraph.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemNumber = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: true),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderNumber = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<long>(type: "INTEGER", nullable: false),
                    ItemId = table.Column<long>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "RowId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "RowId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "RowId", "ItemNumber", "LastModified", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "Y_123", new DateTime(2023, 1, 11, 16, 45, 54, 850, DateTimeKind.Utc).AddTicks(4170), "Yeti Tumbler", 39.99m },
                    { 2L, "AF_234", new DateTime(2023, 1, 11, 16, 45, 54, 850, DateTimeKind.Utc).AddTicks(4180), "Air Fryer", 138.95m }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "RowId", "LastModified", "OrderDate", "OrderNumber" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 1, 11, 16, 45, 54, 850, DateTimeKind.Utc).AddTicks(3270), new DateTime(2023, 1, 11, 16, 45, 54, 850, DateTimeKind.Utc).AddTicks(3280), "Order_1" },
                    { 2L, new DateTime(2023, 1, 11, 16, 45, 54, 850, DateTimeKind.Utc).AddTicks(3280), new DateTime(2023, 1, 11, 16, 45, 54, 850, DateTimeKind.Utc).AddTicks(3280), "Order_2" }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "RowId", "ItemId", "LastModified", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2023, 1, 11, 16, 45, 54, 850, DateTimeKind.Utc).AddTicks(3770), 1L, 3 },
                    { 2L, 2L, new DateTime(2023, 1, 11, 16, 45, 54, 850, DateTimeKind.Utc).AddTicks(3780), 2L, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ItemId",
                table: "OrderItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
