using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MoreBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 7, "Alex Historian", 3, "Delve into the past and discover the fascinating stories that shaped our world.", "HIST9876543", "", 55.0, 50.0, 40.0, 45.0, "Discovering History" },
                    { 8, "Sophie Enigma", 2, "Embark on a journey of magic and wonder. Join our heroes as they unravel the secrets of the mystical realm.", "MYST1234567", "", 45.0, 40.0, 30.0, 35.0, "Mystical Adventures" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
