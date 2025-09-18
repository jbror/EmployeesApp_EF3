using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewSeedDataCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "TobaksLivs Stockholm" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
