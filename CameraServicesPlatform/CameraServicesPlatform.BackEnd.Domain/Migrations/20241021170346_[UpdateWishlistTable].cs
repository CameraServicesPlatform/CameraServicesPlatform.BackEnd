//using System;
//using Microsoft.EntityFrameworkCore.Migrations;

//#nullable disable

//namespace CameraServicesPlatform.BackEnd.Domain.Migrations
//{
//    /// <inheritdoc />
//    public partial class UpdateWishlistTable : Migration
//    {
//        /// <inheritdoc />
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
             

//            migrationBuilder.AddColumn<string>(
//                name: "AccountID",
//                table: "Wishlists",
//                type: "nvarchar(450)",
//                nullable: false,
//                defaultValue: "");

//            migrationBuilder.CreateIndex(
//                name: "IX_Wishlists_AccountID",
//                table: "Wishlists",
//                column: "AccountID");

//            migrationBuilder.AddForeignKey(
//                name: "FK_Wishlists_AspNetUsers_AccountID",
//                table: "Wishlists",
//                column: "AccountID",
//                principalTable: "AspNetUsers",
//                principalColumn: "Id",
//                onDelete: ReferentialAction.Cascade);
//        }

//        /// <inheritdoc />
//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropForeignKey(
//                name: "FK_Wishlists_AspNetUsers_AccountID",
//                table: "Wishlists");

//            migrationBuilder.DropIndex(
//                name: "IX_Wishlists_AccountID",
//                table: "Wishlists");

//            migrationBuilder.DropColumn(
//                name: "AccountID",
//                table: "Wishlists");

            
//        }
//    }
//}
