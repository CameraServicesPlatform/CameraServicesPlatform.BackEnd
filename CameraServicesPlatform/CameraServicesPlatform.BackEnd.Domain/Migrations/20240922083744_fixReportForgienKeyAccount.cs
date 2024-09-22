using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CameraServicesPlatform.BackEnd.Domain.Migrations
{
    /// <inheritdoc />
    public partial class fixReportForgienKeyAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AspNetUsers_AccountId1",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_AccountId1",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "AccountId1",
                table: "Reports");

            migrationBuilder.AlterColumn<string>(
                name: "AccountId",
                table: "Reports",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_AccountId",
                table: "Reports",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_AspNetUsers_AccountId",
                table: "Reports",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AspNetUsers_AccountId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_AccountId",
                table: "Reports");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "Reports",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountId1",
                table: "Reports",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_AccountId1",
                table: "Reports",
                column: "AccountId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_AspNetUsers_AccountId1",
                table: "Reports",
                column: "AccountId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
