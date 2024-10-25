﻿//using Microsoft.EntityFrameworkCore.Migrations;

//#nullable disable

//namespace CameraServicesPlatform.BackEnd.Domain.Migrations
//{
//    /// <inheritdoc />
//    public partial class UpdateBankingInformatinTable : Migration
//    {
//        /// <inheritdoc />
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropForeignKey(
//                name: "FK_BankInformation_AspNetUsers_AccountID",
//                table: "BankInformation");

//            migrationBuilder.AlterColumn<string>(
//                name: "AccountID",
//                table: "BankInformation",
//                type: "nvarchar(450)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "nvarchar(450)",
//                oldNullable: true);

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

//            migrationBuilder.AlterColumn<string>(
//                name: "AccountID",
//                table: "BankInformation",
//                type: "nvarchar(450)",
//                nullable: true,
//                oldClrType: typeof(string),
//                oldType: "nvarchar(450)");

//            migrationBuilder.AddForeignKey(
//                name: "FK_BankInformation_AspNetUsers_AccountID",
//                table: "BankInformation",
//                column: "AccountID",
//                principalTable: "AspNetUsers",
//                principalColumn: "Id");
//        }
//    }
//}
