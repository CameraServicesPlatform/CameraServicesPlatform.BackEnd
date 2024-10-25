using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CameraServicesPlatform.BackEnd.Domain.Migrations
{
    /// <inheritdoc />
    public partial class account : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.AddColumn<Guid>(
               name: "StaffID",
               table: "AspNetUsers",
               type: "uniqueidentifier",
               nullable: true);

            _ = migrationBuilder.AddColumn<Guid>(
                name: "SupplierID",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            _ = migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "086b7a13-79af-4610-851d-204d9d84b865",
                column: "ConcurrencyStamp",
                value: "086b7a13-79af-4610-851d-204d9d84b865");

            _ = migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cf2de31-b0d8-4447-8f2f-c41df905a3a5",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "1cf2de31-b0d8-4447-8f2f-c41df905a3a5", "Admin" });

            _ = migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74bd6d3a-1119-449b-9743-3956d74e7575",
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "74bd6d3a-1119-449b-9743-3956d74e7575", "SUPPLIER" });

            _ = migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e64b36a7-ed67-47d2-b92e-d2f6caa3eda9",
                column: "ConcurrencyStamp",
                value: "e64b36a7-ed67-47d2-b92e-d2f6caa3eda9");

            _ = migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StaffID",
                table: "AspNetUsers",
                column: "StaffID");

            _ = migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SupplierID",
                table: "AspNetUsers",
                column: "SupplierID");

            _ = migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Staffs_StaffID",
                table: "AspNetUsers",
                column: "StaffID",
                principalTable: "Staffs",
                principalColumn: "StaffID");

            _ = migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Suppliers_SupplierID",
                table: "AspNetUsers",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "SupplierID");
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Check if the foreign key exists before trying to drop it
            migrationBuilder.Sql(@"
        IF EXISTS (
            SELECT * 
            FROM sys.foreign_keys 
            WHERE name = 'FK_AspNetUsers_Staffs_StaffID')
        BEGIN
            ALTER TABLE [AspNetUsers] DROP CONSTRAINT [FK_AspNetUsers_Staffs_StaffID];
        END
    ");

            migrationBuilder.Sql(@"
        IF EXISTS (
            SELECT * 
            FROM sys.foreign_keys 
            WHERE name = 'FK_AspNetUsers_Suppliers_SupplierID')
        BEGIN
            ALTER TABLE [AspNetUsers] DROP CONSTRAINT [FK_AspNetUsers_Suppliers_SupplierID];
        END
    ");

            migrationBuilder.DropIndex(name: "IX_AspNetUsers_StaffID", table: "AspNetUsers");
            migrationBuilder.DropIndex(name: "IX_AspNetUsers_SupplierID", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "StaffID", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "SupplierID", table: "AspNetUsers");
        }
    }
}
