using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CameraServicesPlatform.BackEnd.Domain.Migrations
{
    /// <inheritdoc />
    public partial class UpdatetableDeliverriMethodaddOrderID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderID",
                table: "DeliveriesMethod",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveriesMethod_OrderID",
                table: "DeliveriesMethod",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveriesMethod_Orders_OrderID",
                table: "DeliveriesMethod",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveriesMethod_Orders_OrderID",
                table: "DeliveriesMethod");

            migrationBuilder.DropIndex(
                name: "IX_DeliveriesMethod_OrderID",
                table: "DeliveriesMethod");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "DeliveriesMethod");
        }
    }
}
