/*using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CameraServicesPlatform.BackEnd.Domain.Migrations
{
    /// <inheritdoc />
    public partial class updateOrderDetailPeriodRental : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentalPeriod",
                table: "OrderDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodRental",
                table: "OrderDetails",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeriodRental",
                table: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "RentalPeriod",
                table: "OrderDetails",
                type: "int",
                nullable: true);
        }
    }
}
*/