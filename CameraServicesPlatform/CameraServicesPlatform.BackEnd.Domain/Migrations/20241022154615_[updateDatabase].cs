//using Microsoft.EntityFrameworkCore.Migrations;

//#nullable disable

//namespace CameraServicesPlatform.BackEnd.Domain.Migrations
//{
//    /// <inheritdoc />
//    public partial class updateDatabase : Migration
//    {
//        /// <inheritdoc />
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.AddColumn<bool>(
//                name: "status",
//                table: "Vourchers",
//                type: "bit",
//                nullable: false,
//                defaultValue: false);

//            migrationBuilder.AddColumn<bool>(
//                name: "status",
//                table: "Suppliers",
//                type: "bit",
//                nullable: false,
//                defaultValue: false);

//            migrationBuilder.AddColumn<bool>(
//                name: "status",
//                table: "Staffs",
//                type: "bit",
//                nullable: false,
//                defaultValue: false);

//            migrationBuilder.AddColumn<bool>(
//                name: "status",
//                table: "ReturnDetails",
//                type: "bit",
//                nullable: false,
//                defaultValue: false);

//            migrationBuilder.AddColumn<bool>(
//                name: "status",
//                table: "ProductVouchers",
//                type: "bit",
//                nullable: false,
//                defaultValue: false);

//            migrationBuilder.AddColumn<bool>(
//                name: "StatusCategory",
//                table: "Categories",
//                type: "bit",
//                nullable: false,
//                defaultValue: false);
//        }

//        /// <inheritdoc />
//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropColumn(
//                name: "status",
//                table: "Vourchers");

//            migrationBuilder.DropColumn(
//                name: "status",
//                table: "Suppliers");

//            migrationBuilder.DropColumn(
//                name: "status",
//                table: "Staffs");

//            migrationBuilder.DropColumn(
//                name: "status",
//                table: "ReturnDetails");

//            migrationBuilder.DropColumn(
//                name: "status",
//                table: "ProductVouchers");

//            migrationBuilder.DropColumn(
//                name: "StatusCategory",
//                table: "Categories");
//        }
//    }
//}
