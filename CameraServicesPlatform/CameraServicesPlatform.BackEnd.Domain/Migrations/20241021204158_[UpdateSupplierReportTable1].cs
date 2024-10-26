/*using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CameraServicesPlatform.BackEnd.Domain.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSupplierReportTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupplierReports_AspNetUsers_HandledByAccountId",
                table: "SupplierReports");

            migrationBuilder.DropIndex(
                name: "IX_SupplierReports_HandledByAccountId",
                table: "SupplierReports");

            migrationBuilder.DropColumn(
                name: "HandledByAccountId",
                table: "SupplierReports");

            migrationBuilder.RenameColumn(
                name: "HandledBy",
                table: "SupplierReports",
                newName: "StaffID");

            migrationBuilder.AddColumn<Guid>(
                name: "MemberID",
                table: "SupplierReports",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SupplierReports_MemberID",
                table: "SupplierReports",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierReports_StaffID",
                table: "SupplierReports",
                column: "StaffID");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierReports_Members_MemberID",
                table: "SupplierReports",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierReports_Staffs_StaffID",
                table: "SupplierReports",
                column: "StaffID",
                principalTable: "Staffs",
                principalColumn: "StaffID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupplierReports_Members_MemberID",
                table: "SupplierReports");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierReports_Staffs_StaffID",
                table: "SupplierReports");

            migrationBuilder.DropIndex(
                name: "IX_SupplierReports_MemberID",
                table: "SupplierReports");

            migrationBuilder.DropIndex(
                name: "IX_SupplierReports_StaffID",
                table: "SupplierReports");

            migrationBuilder.DropColumn(
                name: "MemberID",
                table: "SupplierReports");

            migrationBuilder.RenameColumn(
                name: "StaffID",
                table: "SupplierReports",
                newName: "HandledBy");

            migrationBuilder.AddColumn<string>(
                name: "HandledByAccountId",
                table: "SupplierReports",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierReports_HandledByAccountId",
                table: "SupplierReports",
                column: "HandledByAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierReports_AspNetUsers_HandledByAccountId",
                table: "SupplierReports",
                column: "HandledByAccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
*/