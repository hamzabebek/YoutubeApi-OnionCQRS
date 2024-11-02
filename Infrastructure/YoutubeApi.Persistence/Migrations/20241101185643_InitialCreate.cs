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
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 1, 21, 56, 43, 522, DateTimeKind.Local).AddTicks(4324), false, "Movies, Electronics & Jewelery" },
                    { 2, new DateTime(2024, 11, 1, 21, 56, 43, 522, DateTimeKind.Local).AddTicks(4335), false, "Industrial, Beauty & Outdoors" },
                    { 3, new DateTime(2024, 11, 1, 21, 56, 43, 522, DateTimeKind.Local).AddTicks(4339), false, "Computers" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "ParentId", "Priorty" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 1, 21, 56, 43, 522, DateTimeKind.Local).AddTicks(5355), false, "Elektrik", 0, 1 },
                    { 2, new DateTime(2024, 11, 1, 21, 56, 43, 522, DateTimeKind.Local).AddTicks(5357), false, "Moda", 0, 2 },
                    { 3, new DateTime(2024, 11, 1, 21, 56, 43, 522, DateTimeKind.Local).AddTicks(5358), false, "Bilgisayar", 1, 1 },
                    { 4, new DateTime(2024, 11, 1, 21, 56, 43, 522, DateTimeKind.Local).AddTicks(5359), false, "Bilgisayar", 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 1, 21, 56, 43, 523, DateTimeKind.Local).AddTicks(6085), "Vitae çobanın et explicabo consequatur.\nAdipisci için dağılımı sed ipsum ut lakin nemo değerli.\nRem sıla suscipit numquam ipsa aliquam eum sayfası ipsum praesentium.\nHesap fugit blanditiis lambadaki de et gidecekmiş.\nKoyun vel gitti alias yazın ki eum ea gitti.", false, "Et bundan ut magni sed okuma gül quia dolore alias." },
                    { 2, 3, new DateTime(2024, 11, 1, 21, 56, 43, 523, DateTimeKind.Local).AddTicks(6154), "Doloremque beatae consequuntur.\nUt de incidunt vel explicabo de magni suscipit consequuntur.\nSit kapının orta.\nİçin mutlu yapacakmış koyun.\nMagni sit çarpan.", true, "Sokaklarda vitae çıktılar bahar çarpan consequatur exercitationem." },
                    { 3, 4, new DateTime(2024, 11, 1, 21, 56, 43, 523, DateTimeKind.Local).AddTicks(6258), "İure telefonu non cesurca domates.\nKalemi gördüm koşuyorlar hesap doloremque quia duyulmamış praesentium suscipit alias.\nDicta voluptas beatae.\nOdit et eum cesurca telefonu sokaklarda salladı eaque ama.\nHesap duyulmamış odit dolayı salladı.", false, "Dolayı anlamsız dağılımı patlıcan dicta reprehenderit minima gül." }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CreatedDate", "Description", "Discount", "IsDeleted", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 1, 21, 56, 43, 524, DateTimeKind.Local).AddTicks(7770), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 7.112840709805890m, false, 933.35m, "Intelligent Concrete Ball" },
                    { 2, 3, new DateTime(2024, 11, 1, 21, 56, 43, 524, DateTimeKind.Local).AddTicks(7789), "The Football Is Good For Training And Recreational Purposes", 1.906775606947090m, false, 72.62m, "Handmade Soft Bike" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_CategoryId",
                table: "Details",
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
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
