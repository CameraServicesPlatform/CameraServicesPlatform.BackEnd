using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CameraServicesPlatform.BackEnd.Domain.Migrations
{
    /// <inheritdoc />
    public partial class updateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveriesMethod_DeliveriesMethodID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveriesMethodID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveriesMethodID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryMethod",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "DeliveriesMethod",
                table: "Orders",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveriesMethod",
                table: "Orders");

            migrationBuilder.AddColumn<Guid>(
                name: "DeliveriesMethodID",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryMethod",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveriesMethodID",
                table: "Orders",
                column: "DeliveriesMethodID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveriesMethod_DeliveriesMethodID",
                table: "Orders",
                column: "DeliveriesMethodID",
                principalTable: "DeliveriesMethod",
                principalColumn: "DeliveriesMethodID");
        }
    }
}
