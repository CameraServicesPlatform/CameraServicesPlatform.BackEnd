using System;
using Microsoft.EntityFrameworkCore.Migrations;

//namespace CameraServicesPlatform.BackEnd.Domain.Migrations
//{
//    public partial class UpdateContractTableTable1 : Migration
//    {
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            // Check for the column existence
//            var columnCheckSql = @"
//                IF NOT EXISTS (
//                    SELECT 1 
//                    FROM INFORMATION_SCHEMA.COLUMNS 
//                    WHERE TABLE_NAME = 'ContractTemplates' 
//                    AND COLUMN_NAME = 'AccountID'
//                ) 
//                BEGIN
//                    ALTER TABLE [ContractTemplates] 
//                    ADD [AccountID] NVARCHAR(450) NOT NULL DEFAULT N'';
//                END";
//            migrationBuilder.Sql(columnCheckSql);

//            // Check for the index existence
//            var indexCheckSql = @"
//                IF NOT EXISTS (
//                    SELECT 1 
//                    FROM sys.indexes 
//                    WHERE name = 'IX_ContractTemplates_AccountID' 
//                    AND object_id = OBJECT_ID('ContractTemplates')
//                ) 
//                BEGIN
//                    CREATE INDEX [IX_ContractTemplates_AccountID] 
//                    ON [ContractTemplates] ([AccountID]);
//                END";
//            migrationBuilder.Sql(indexCheckSql);

//            // Foreign key constraint for AccountID to AspNetUsers table
//            migrationBuilder.AddForeignKey(
//                name: "FK_ContractTemplates_AspNetUsers_AccountID",
//                table: "ContractTemplates",
//                column: "AccountID",
//                principalTable: "AspNetUsers",
//                principalColumn: "Id",
//                onDelete: ReferentialAction.Cascade);
//        }

//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropForeignKey(
//                name: "FK_ContractTemplates_AspNetUsers_AccountID",
//                table: "ContractTemplates");

//            migrationBuilder.DropIndex(
//                name: "IX_ContractTemplates_AccountID",
//                table: "ContractTemplates");

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
