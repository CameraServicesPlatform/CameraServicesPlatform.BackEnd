/*using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CameraServicesPlatform.BackEnd.Domain.Migrations
{
    /// <inheritdoc />
    public partial class updateComboSupplier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ComboOfSuppliers",
                table: "ComboOfSuppliers");

            migrationBuilder.AddColumn<Guid>(
                name: "ComboOfSupplierId",
                table: "ComboOfSuppliers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComboOfSuppliers",
                table: "ComboOfSuppliers",
                column: "ComboOfSupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboOfSuppliers_ComboId",
                table: "ComboOfSuppliers",
                column: "ComboId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComboOfSuppliers_Combos_ComboId",
                table: "ComboOfSuppliers",
                column: "ComboId",
                principalTable: "Combos",
                principalColumn: "ComboId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComboOfSuppliers_Combos_ComboId",
                table: "ComboOfSuppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComboOfSuppliers",
                table: "ComboOfSuppliers");

            migrationBuilder.DropIndex(
                name: "IX_ComboOfSuppliers_ComboId",
                table: "ComboOfSuppliers");

            migrationBuilder.DropColumn(
                name: "ComboOfSupplierId",
                table: "ComboOfSuppliers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComboOfSuppliers",
                table: "ComboOfSuppliers",
                column: "ComboId");
        }
    }
}
*/