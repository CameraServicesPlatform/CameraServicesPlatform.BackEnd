using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CameraServicesPlatform.BackEnd.Domain.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProdcutReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductReports_AspNetUsers_HandledById",
                table: "ProductReports");

            migrationBuilder.RenameColumn(
                name: "HandledById",
                table: "ProductReports",
                newName: "Account");

            migrationBuilder.RenameIndex(
                name: "IX_ProductReports_HandledById",
                table: "ProductReports",
                newName: "IX_ProductReports_Account");

            migrationBuilder.AlterColumn<string>(
                name: "AccountID",
                table: "ProductReports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReports_AspNetUsers_Account",
                table: "ProductReports",
                column: "Account",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductReports_AspNetUsers_Account",
                table: "ProductReports");

            migrationBuilder.RenameColumn(
                name: "Account",
                table: "ProductReports",
                newName: "HandledById");

            migrationBuilder.RenameIndex(
                name: "IX_ProductReports_Account",
                table: "ProductReports",
                newName: "IX_ProductReports_HandledById");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountID",
                table: "ProductReports",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReports_AspNetUsers_HandledById",
                table: "ProductReports",
                column: "HandledById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
