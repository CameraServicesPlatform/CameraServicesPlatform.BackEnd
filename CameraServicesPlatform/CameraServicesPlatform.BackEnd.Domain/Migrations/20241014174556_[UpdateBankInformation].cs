//using System;
//using Microsoft.EntityFrameworkCore.Migrations;

//#nullable disable

//namespace CameraServicesPlatform.BackEnd.Domain.Migrations
//{
//    /// <inheritdoc />
//    public partial class UpdateBankInformation : Migration
//    {
//        /// <inheritdoc />
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropForeignKey(
//                name: "FK_BankInformation_Account_AccountID",
//                table: "BankInformation");

//            migrationBuilder.DropIndex(
//                name: "IX_BankInformation_AccountID",
//                table: "BankInformation");

//            migrationBuilder.DropColumn(
//                name: "AccountID",
//                table: "BankInformation");

//            migrationBuilder.AddColumn<string>(
//                name: "AccountID",
//                table: "BankInformation",
//                type: "nvarchar(450)",
//                nullable: false,
//                defaultValue: "");

//            migrationBuilder.CreateIndex(
//                name: "IX_BankInformation_AccountID",
//                table: "BankInformation",
//                column: "AccountID");

//            migrationBuilder.AddForeignKey(
//                name: "FK_BankInformation_AspNetUsers_AccountID",
//                table: "BankInformation",
//                column: "AccountID",
//                principalTable: "AspNetUsers",
//                principalColumn: "Id",
//                onDelete: ReferentialAction.Cascade);
//        }

//        /// <inheritdoc />
//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropForeignKey(
//                name: "FK_BankInformation_AspNetUsers_AccountID",
//                table: "BankInformation");

//            migrationBuilder.DropIndex(
//                name: "IX_BankInformation_AccountID",
//                table: "BankInformation");

//            migrationBuilder.DropColumn(
//                name: "AccountID",
//                table: "BankInformation");

//            migrationBuilder.AddColumn<Guid>(
//                name: "AccountID",
//                table: "BankInformation",
//                type: "uniqueidentifier",
//                nullable: false,
//                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

//            migrationBuilder.CreateIndex(
//                name: "IX_BankInformation_AccountID",
//                table: "BankInformation",
//                column: "AccountID");

//            migrationBuilder.AddForeignKey(
//                name: "FK_BankInformation_Account_AccountID",
//                table: "BankInformation",
//                column: "AccountID",
//                principalTable: "Account",
//                principalColumn: "AccountID",
//                onDelete: ReferentialAction.Cascade);
//        }
//    }
//}
