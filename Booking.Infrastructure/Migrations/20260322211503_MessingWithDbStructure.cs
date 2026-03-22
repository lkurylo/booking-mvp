using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MessingWithDbStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScheduledTime",
                table: "Barbers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Barbers");

            migrationBuilder.RenameColumn(
                name: "ScheduledTime",
                table: "Appointments",
                newName: "ScheduledTimeStart");

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Appointments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduledTimeEnd",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "CustomerEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    PriceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BarberEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceEntity_Barbers_BarberEntityId",
                        column: x => x.BarberEntityId,
                        principalTable: "Barbers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Barbers",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("4f624835-a45d-4de7-a986-7f319b77ea34"), "Jan Kowalski" });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_BarberId",
                table: "Appointments",
                column: "BarberId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CustomerId",
                table: "Appointments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ServiceId",
                table: "Appointments",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceEntity_BarberEntityId",
                table: "ServiceEntity",
                column: "BarberEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Barbers_BarberId",
                table: "Appointments",
                column: "BarberId",
                principalTable: "Barbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_CustomerEntity_CustomerId",
                table: "Appointments",
                column: "CustomerId",
                principalTable: "CustomerEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_ServiceEntity_ServiceId",
                table: "Appointments",
                column: "ServiceId",
                principalTable: "ServiceEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Barbers_BarberId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_CustomerEntity_CustomerId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_ServiceEntity_ServiceId",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "CustomerEntity");

            migrationBuilder.DropTable(
                name: "ServiceEntity");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_BarberId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_CustomerId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ServiceId",
                table: "Appointments");

            migrationBuilder.DeleteData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("4f624835-a45d-4de7-a986-7f319b77ea34"));

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ScheduledTimeEnd",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "ScheduledTimeStart",
                table: "Appointments",
                newName: "ScheduledTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduledTime",
                table: "Barbers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Barbers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
