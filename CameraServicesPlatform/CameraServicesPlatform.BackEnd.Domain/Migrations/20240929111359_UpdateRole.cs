using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CameraServicesPlatform.BackEnd.Domain.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a12b3c4d-56ef-78gh-90ij-klmnopqrstuv");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b21c4d5e-67fg-89hi-01jk-lmnopqrstuv");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c32d5e6f-78gh-90ij-12kl-mnopqrstuv");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d43e6f7g-89hi-01jk-23lm-nopqrstuv");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "086b7a13-79af-4610-851d-204d9d84b865", null, "STAFF", "Staff" },
                    { "1cf2de31-b0d8-4447-8f2f-c41df905a3a5", null, "ADMIN", "ADMIN" },
                    { "74bd6d3a-1119-449b-9743-3956d74e7575", null, "Supplier", "Supplier" },
                    { "e64b36a7-ed67-47d2-b92e-d2f6caa3eda9", null, "MEMBER", "Member" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "086b7a13-79af-4610-851d-204d9d84b865");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cf2de31-b0d8-4447-8f2f-c41df905a3a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74bd6d3a-1119-449b-9743-3956d74e7575");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e64b36a7-ed67-47d2-b92e-d2f6caa3eda9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a12b3c4d-56ef-78gh-90ij-klmnopqrstuv", null, "ADMIN", "ADMIN" },
                    { "b21c4d5e-67fg-89hi-01jk-lmnopqrstuv", null, "MEMBER", "Member" },
                    { "c32d5e6f-78gh-90ij-12kl-mnopqrstuv", null, "STAFF", "Staff" },
                    { "d43e6f7g-89hi-01jk-23lm-nopqrstuv", null, "Supplier", "Supplier" }
                });
        }
    }
}
