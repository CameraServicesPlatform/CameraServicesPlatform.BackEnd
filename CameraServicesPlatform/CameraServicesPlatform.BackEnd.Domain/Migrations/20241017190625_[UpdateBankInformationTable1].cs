using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CameraServicesPlatform.BackEnd.Domain.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBankInformationTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankInformation_Members_MemberId",
                table: "BankInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_ContractTemplates_ContractTemplateId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_BankInformation_MemberId",
                table: "BankInformation");

            migrationBuilder.DropColumn(
                name: "ContractTemplateId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "BankInformation");

            migrationBuilder.AddColumn<string>(
                name: "AccountID",
                table: "BankInformation",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BackOfCitizenIdentificationCard",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrontOfCitizenIdentificationCard",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankInformation_AccountID",
                table: "BankInformation",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_BankInformation_AspNetUsers_AccountID",
                table: "BankInformation",
                column: "AccountID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractTemplates_Members_MemberID",
                table: "ContractTemplates",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankInformation_AspNetUsers_AccountID",
                table: "BankInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractTemplates_Members_MemberID",
                table: "ContractTemplates");

            migrationBuilder.DropIndex(
                name: "IX_BankInformation_AccountID",
                table: "BankInformation");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "BankInformation");

            migrationBuilder.DropColumn(
                name: "BackOfCitizenIdentificationCard",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FrontOfCitizenIdentificationCard",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "ContractTemplateId",
                table: "Contracts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MemberId",
                table: "BankInformation",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_BankInformation_MemberId",
                table: "BankInformation",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankInformation_Members_MemberId",
                table: "BankInformation",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_ContractTemplates_ContractTemplateId",
                table: "Contracts",
                column: "ContractTemplateId",
                principalTable: "ContractTemplates",
                principalColumn: "ContractTemplateId");
        }
    }
}
