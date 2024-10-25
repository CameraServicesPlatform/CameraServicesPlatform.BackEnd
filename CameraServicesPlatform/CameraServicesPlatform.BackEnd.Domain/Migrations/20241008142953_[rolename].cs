using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CameraServicesPlatform.BackEnd.Domain.Migrations
{
    /// <inheritdoc />
    public partial class rolename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "086b7a13-79af-4610-851d-204d9d84b865",
                column: "NormalizedName",
                value: "staff");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cf2de31-b0d8-4447-8f2f-c41df905a3a5",
                column: "NormalizedName",
                value: "admin");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74bd6d3a-1119-449b-9743-3956d74e7575",
                column: "NormalizedName",
                value: "supplier");

         migrationBuilder.UpdateData(
        table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e64b36a7-ed67-47d2-b92e-d2f6caa3eda9",
                column: "NormalizedName",
                value: "member");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "086b7a13-79af-4610-851d-204d9d84b865",
                column: "NormalizedName",
                value: "Staff");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cf2de31-b0d8-4447-8f2f-c41df905a3a5",
                column: "NormalizedName",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74bd6d3a-1119-449b-9743-3956d74e7575",
                column: "NormalizedName",
                value: "Supplier");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e64b36a7-ed67-47d2-b92e-d2f6caa3eda9",
                column: "NormalizedName",
                value: "Member");
        }
    }
}
