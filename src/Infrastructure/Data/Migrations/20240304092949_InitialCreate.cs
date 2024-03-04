using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductBrands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ProductTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductBrandId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductBrands_ProductBrandId",
                        column: x => x.ProductBrandId,
                        principalTable: "ProductBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductBrands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5f71a742-c0ab-4a86-8754-8328ef4f37f4"), "Brand 2" },
                    { new Guid("794a5bf3-db1f-4d4a-86e7-1021dbb8f667"), "Brand 1" },
                    { new Guid("9b8544ac-99fb-4201-acd4-b6c25c9c1918"), "Brand 3" }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("690a87fe-1e04-470a-a11b-50807f73f5ba"), "Type 3" },
                    { new Guid("dc1cc068-6c14-4cb2-9b3d-858953d41e59"), "Type 1" },
                    { new Guid("e29b5399-d2d0-4889-bdbc-1a74b2f06aaf"), "Type 2" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "ProductBrandId", "ProductTypeId" },
                values: new object[,]
                {
                    { new Guid("24afe402-5f06-482f-920b-f9533f069052"), "Description 6", "Product 6", 18.99m, new Guid("9b8544ac-99fb-4201-acd4-b6c25c9c1918"), new Guid("e29b5399-d2d0-4889-bdbc-1a74b2f06aaf") },
                    { new Guid("271b2797-251f-42ba-8465-035bcb7353ce"), "Description 10", "Product 10", 35.99m, new Guid("5f71a742-c0ab-4a86-8754-8328ef4f37f4"), new Guid("e29b5399-d2d0-4889-bdbc-1a74b2f06aaf") },
                    { new Guid("63cd83fb-da73-4880-b90f-2ba32d24ab04"), "Описание продукта 2", "Product 2", 20.99m, new Guid("794a5bf3-db1f-4d4a-86e7-1021dbb8f667"), new Guid("dc1cc068-6c14-4cb2-9b3d-858953d41e59") },
                    { new Guid("838c781f-6650-44fb-a84f-8cbac2047363"), "Description 1", "Product 1", 10.99m, new Guid("794a5bf3-db1f-4d4a-86e7-1021dbb8f667"), new Guid("dc1cc068-6c14-4cb2-9b3d-858953d41e59") },
                    { new Guid("8789b1be-f690-41a0-808e-95b09f74e3c7"), "Description 3", "Product 3", 15.49m, new Guid("5f71a742-c0ab-4a86-8754-8328ef4f37f4"), new Guid("dc1cc068-6c14-4cb2-9b3d-858953d41e59") },
                    { new Guid("970ee704-1d3c-457e-aa47-d70b1529868f"), "Description 8", "Product 8", 12.99m, new Guid("9b8544ac-99fb-4201-acd4-b6c25c9c1918"), new Guid("690a87fe-1e04-470a-a11b-50807f73f5ba") },
                    { new Guid("a01420ff-9e62-41cd-8513-3ffcb76f6c66"), "Description 7", "Product 7", 22.49m, new Guid("9b8544ac-99fb-4201-acd4-b6c25c9c1918"), new Guid("690a87fe-1e04-470a-a11b-50807f73f5ba") },
                    { new Guid("c4d5984c-2d8d-4a75-b38a-635beaa30517"), "Description 5", "Product 5", 25.99m, new Guid("9b8544ac-99fb-4201-acd4-b6c25c9c1918"), new Guid("dc1cc068-6c14-4cb2-9b3d-858953d41e59") },
                    { new Guid("cf2d4065-81a6-48fe-9b8b-0c6ae56c2b80"), "Description 9", "Product 9", 28.99m, new Guid("5f71a742-c0ab-4a86-8754-8328ef4f37f4"), new Guid("690a87fe-1e04-470a-a11b-50807f73f5ba") },
                    { new Guid("e64b9097-62a0-40cd-bebd-6b677419d577"), "Description 4", "Product 4", 30.99m, new Guid("5f71a742-c0ab-4a86-8754-8328ef4f37f4"), new Guid("e29b5399-d2d0-4889-bdbc-1a74b2f06aaf") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductBrandId",
                table: "Products",
                column: "ProductBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductBrands");

            migrationBuilder.DropTable(
                name: "ProductTypes");
        }
    }
}
