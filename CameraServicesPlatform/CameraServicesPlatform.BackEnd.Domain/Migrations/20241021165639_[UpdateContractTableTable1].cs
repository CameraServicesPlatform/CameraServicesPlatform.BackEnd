using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CameraServicesPlatform.BackEnd.Domain.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContractTableTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractTemplates_Members_MemberID",
                table: "ContractTemplates");

            migrationBuilder.DropIndex(
                name: "IX_ContractTemplates_MemberID",
                table: "ContractTemplates");

            migrationBuilder.DropColumn(
                name: "MemberID",
                table: "ContractTemplates");

            migrationBuilder.AddColumn<string>(
                name: "AccountID",
                table: "ContractTemplates",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTemplates_AccountID",
                table: "ContractTemplates",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractTemplates_AspNetUsers_AccountID",
                table: "ContractTemplates",
                column: "AccountID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractTemplates_AspNetUsers_AccountID",
                table: "ContractTemplates");

            migrationBuilder.DropIndex(
                name: "IX_ContractTemplates_AccountID",
                table: "ContractTemplates");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "ContractTemplates");

            migrationBuilder.AddColumn<Guid>(
                name: "MemberID",
                table: "ContractTemplates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ContractTemplates_MemberID",
                table: "ContractTemplates",
                column: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractTemplates_Members_MemberID",
                table: "ContractTemplates",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
