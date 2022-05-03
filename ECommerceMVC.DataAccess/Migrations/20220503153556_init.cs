using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceMVC.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Phone" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Computer" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Tablet" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "Discount", "ImageURL", "IsActive", "Name", "Price", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 1, null, "Awasome", 0.02, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/apple/thumb/113155-2_large.jpg", true, "iPhone 11", 7000.0, null },
                    { 2, 1, null, "Cool", 0.02, "https://productimages.hepsiburada.net/s/44/550/10769576230962.jpg/format:webp", true, "Samsung", 7000.0, null },
                    { 3, 1, null, "Chang Ching Chong", 0.02, "https://productimages.hepsiburada.net/s/198/550/110000168630735.jpg/format:webp", true, "Xiomi", 7000.0, null },
                    { 4, 2, null, "Interesting", 0.089999999999999997, "https://productimages.hepsiburada.net/s/44/222-222/10817626898482.jpg/format:webp", true, "MacBook Pro1", 20000.0, null },
                    { 5, 2, null, "Ghost", 0.02, "https://productimages.hepsiburada.net/s/203/550/110000176911589.jpg/format:webp", true, "Casper", 7000.0, null },
                    { 6, 2, null, "Canavar", 0.02, "https://productimages.hepsiburada.net/s/108/550/110000052006351.jpg/format:webp", true, "Monster", 7000.0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
