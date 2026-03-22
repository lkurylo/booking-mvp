using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddManyToManyRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_CustomerEntity_CustomerId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_ServiceEntity_ServiceId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceEntity_Barbers_BarberEntityId",
                table: "ServiceEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceEntity",
                table: "ServiceEntity");

            migrationBuilder.DropIndex(
                name: "IX_ServiceEntity_BarberEntityId",
                table: "ServiceEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerEntity",
                table: "CustomerEntity");

            migrationBuilder.DropColumn(
                name: "BarberEntityId",
                table: "ServiceEntity");

            migrationBuilder.RenameTable(
                name: "ServiceEntity",
                newName: "Services");

            migrationBuilder.RenameTable(
                name: "CustomerEntity",
                newName: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Services",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BarberServices",
                columns: table => new
                {
                    BarbersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecializationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarberServices", x => new { x.BarbersId, x.SpecializationsId });
                    table.ForeignKey(
                        name: "FK_BarberServices_Barbers_BarbersId",
                        column: x => x.BarbersId,
                        principalTable: "Barbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarberServices_Services_SpecializationsId",
                        column: x => x.SpecializationsId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BarberServices_SpecializationsId",
                table: "BarberServices",
                column: "SpecializationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Customers_CustomerId",
                table: "Appointments",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Services_ServiceId",
                table: "Appointments",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Customers_CustomerId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Services_ServiceId",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "BarberServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "ServiceEntity");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "CustomerEntity");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ServiceEntity",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<Guid>(
                name: "BarberEntityId",
                table: "ServiceEntity",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceEntity",
                table: "ServiceEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerEntity",
                table: "CustomerEntity",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceEntity_BarberEntityId",
                table: "ServiceEntity",
                column: "BarberEntityId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceEntity_Barbers_BarberEntityId",
                table: "ServiceEntity",
                column: "BarberEntityId",
                principalTable: "Barbers",
                principalColumn: "Id");
        }
    }
}
