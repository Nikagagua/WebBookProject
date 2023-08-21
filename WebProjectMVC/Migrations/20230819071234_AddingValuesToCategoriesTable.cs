using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProjectMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddingValuesToCategoriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories (CategoryId, Name, DisplayOrder) VALUES (NEWID(), 'Action', 1)");
            migrationBuilder.Sql("INSERT INTO Categories (CategoryId, Name, DisplayOrder) VALUES (NEWID(), 'SciFi', 2)");
            migrationBuilder.Sql("INSERT INTO Categories (CategoryId, Name, DisplayOrder) VALUES (NEWID(), 'History', 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
