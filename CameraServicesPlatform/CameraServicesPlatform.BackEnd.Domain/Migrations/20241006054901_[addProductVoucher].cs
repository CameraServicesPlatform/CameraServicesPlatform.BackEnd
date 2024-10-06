using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CameraServicesPlatform.BackEnd.Domain.Migrations
{
    /// <inheritdoc />
    public partial class addProductVoucher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountType",
                table: "Vourchers");

            migrationBuilder.DropColumn(
                name: "MaxUsageLimit",
                table: "Vourchers");

            migrationBuilder.DropColumn(
                name: "MinOrderAmount",
                table: "Vourchers");

            migrationBuilder.DropColumn(
                name: "UsagePerCustomer",
                table: "Vourchers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiscountType",
                table: "Vourchers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxUsageLimit",
                table: "Vourchers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MinOrderAmount",
                table: "Vourchers",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsagePerCustomer",
                table: "Vourchers",
                type: "int",
                nullable: true);
        }
    }
}
