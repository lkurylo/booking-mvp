using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Barbers",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("a47ac10b-58cc-4372-a567-0e02b2c3d479"), "Łukasz" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[] { new Guid("c47ac10b-58cc-4372-a567-0e02b2c3d479"), "none@example.com", "John Doe" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Comments", "DurationMinutes", "Name", "PriceAmount" },
                values: new object[] { new Guid("b47ac10b-58cc-4372-a567-0e02b2c3d479"), null, 20, "Beard Trim", 110m });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "BarberId", "Comments", "CustomerId", "ScheduledTimeEnd", "ScheduledTimeStart", "ServiceId", "Status" },
                values: new object[] { new Guid("d47ac10b-58cc-4372-a567-0e02b2c3d479"), new Guid("a47ac10b-58cc-4372-a567-0e02b2c3d479"), "First appointment", new Guid("c47ac10b-58cc-4372-a567-0e02b2c3d479"), new DateTime(2026, 3, 23, 11, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 23, 11, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b47ac10b-58cc-4372-a567-0e02b2c3d479"), 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("d47ac10b-58cc-4372-a567-0e02b2c3d479"));

            migrationBuilder.DeleteData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("a47ac10b-58cc-4372-a567-0e02b2c3d479"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("c47ac10b-58cc-4372-a567-0e02b2c3d479"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("b47ac10b-58cc-4372-a567-0e02b2c3d479"));
        }
    }
}
