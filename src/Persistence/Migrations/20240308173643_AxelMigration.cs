using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AxelMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false),
                    StoreProductProductId = table.Column<Guid>(type: "TEXT", nullable: true),
                    StoreProductStoreId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoreProduct",
                columns: table => new
                {
                    StoreId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreProduct", x => new { x.ProductId, x.StoreId });
                    table.ForeignKey(
                        name: "FK_StoreProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreProduct_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { new Guid("817460e9-a1a2-47a4-a9f6-b0afa5c3ebd9"), "Av. El Uruguay 452", "Tienda de Electrodomesticos" },
                    { new Guid("c2f51688-1c31-4ef2-a380-692d89bfd1f3"), "Av. El Paso 100", "Tienda de Burguers" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_StoreProductProductId_StoreProductStoreId",
                table: "Products",
                columns: new[] { "StoreProductProductId", "StoreProductStoreId" });

            migrationBuilder.CreateIndex(
                name: "IX_StoreProduct_StoreId",
                table: "StoreProduct",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_StoreProduct_StoreProductProductId_StoreProductStoreId",
                table: "Products",
                columns: new[] { "StoreProductProductId", "StoreProductStoreId" },
                principalTable: "StoreProduct",
                principalColumns: new[] { "ProductId", "StoreId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_StoreProduct_StoreProductProductId_StoreProductStoreId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "StoreProduct");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
