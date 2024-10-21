﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CameraServicesPlatform.BackEnd.Domain.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWishlistTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_Members_MemberID",
                table: "Wishlists");

            migrationBuilder.DropIndex(
                name: "IX_Wishlists_MemberID",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "MemberID",
                table: "Wishlists");

            migrationBuilder.AddColumn<string>(
                name: "AccountID",
                table: "Wishlists",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_AccountID",
                table: "Wishlists",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_AspNetUsers_AccountID",
                table: "Wishlists",
                column: "AccountID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_AspNetUsers_AccountID",
                table: "Wishlists");

            migrationBuilder.DropIndex(
                name: "IX_Wishlists_AccountID",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "Wishlists");

            migrationBuilder.AddColumn<Guid>(
                name: "MemberID",
                table: "Wishlists",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_MemberID",
                table: "Wishlists",
                column: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_Members_MemberID",
                table: "Wishlists",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
