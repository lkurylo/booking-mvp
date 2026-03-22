using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixDbStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("4f624835-a45d-4de7-a986-7f319b77ea34"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Barbers",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("4f624835-a45d-4de7-a986-7f319b77ea34"), "Jan Kowalski" });
        }
    }
}
