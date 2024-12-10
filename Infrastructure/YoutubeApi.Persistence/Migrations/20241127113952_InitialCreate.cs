using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YoutubeApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priorty = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 27, 14, 39, 51, 868, DateTimeKind.Local).AddTicks(654), false, "Automotive" },
                    { 2, new DateTime(2024, 11, 27, 14, 39, 51, 868, DateTimeKind.Local).AddTicks(3605), false, "Sports & Beauty" },
                    { 3, new DateTime(2024, 11, 27, 14, 39, 51, 868, DateTimeKind.Local).AddTicks(3659), false, "Music" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "ParentId", "Priorty" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 27, 14, 39, 51, 869, DateTimeKind.Local).AddTicks(2665), false, "Elektrik", 0, 1 },
                    { 2, new DateTime(2024, 11, 27, 14, 39, 51, 869, DateTimeKind.Local).AddTicks(2668), false, "Moda", 0, 2 },
                    { 3, new DateTime(2024, 11, 27, 14, 39, 51, 869, DateTimeKind.Local).AddTicks(2670), false, "Bilgisayar", 1, 1 },
                    { 4, new DateTime(2024, 11, 27, 14, 39, 51, 869, DateTimeKind.Local).AddTicks(2672), false, "Bilgisayar", 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 27, 14, 39, 51, 883, DateTimeKind.Local).AddTicks(6734), "Bundan beatae şafak totam ve.\nYaptı quia dicta ab architecto enim kutusu.\nSıla reprehenderit anlamsız filmini teldeki voluptas öyle consequatur iusto.\nRatione sequi amet aspernatur vitae voluptatum.\nSayfası çakıl gitti ut.", false, "Odio patlıcan velit gülüyorum nesciunt." },
                    { 2, 3, new DateTime(2024, 11, 27, 14, 39, 51, 883, DateTimeKind.Local).AddTicks(6914), "Değirmeni dağılımı de consequatur sinema sit fugit çarpan ışık.\nSıla accusantium kalemi ut çıktılar qui sed bilgiyasayarı.\nAdresini sıradanlıktan voluptatem camisi voluptatem dergi ipsum.\nAlias anlamsız ona odit aliquam ki et quia sequi layıkıyla.\nGöze biber dicta ipsa voluptatem quis explicabo.", true, "Enim sequi aperiam tv fugit incidunt explicabo." },
                    { 3, 4, new DateTime(2024, 11, 27, 14, 39, 51, 883, DateTimeKind.Local).AddTicks(7006), "Ut minima illo aliquid beğendim bahar.\nVoluptatem çakıl ratione camisi non fugit.\nOdio esse laudantium ullam voluptate voluptatem kalemi laboriosam.\nVoluptas yazın modi exercitationem incidunt cesurca bilgiyasayarı sed.\nArchitecto ve türemiş enim odio camisi bundan domates.", false, "İncidunt ab ullam filmini." }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CreatedDate", "Description", "Discount", "IsDeleted", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 27, 14, 39, 51, 894, DateTimeKind.Local).AddTicks(8677), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 3.905406324244810m, false, 545.29m, "Gorgeous Fresh Tuna" },
                    { 2, 3, new DateTime(2024, 11, 27, 14, 39, 51, 894, DateTimeKind.Local).AddTicks(8765), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 0.09220333024784640m, false, 183.27m, "Refined Granite Fish" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Details_CategoryId",
                table: "Details",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
