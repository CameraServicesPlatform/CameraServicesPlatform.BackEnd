//using System;
//using Microsoft.EntityFrameworkCore.Migrations;

//#nullable disable

//namespace CameraServicesPlatform.BackEnd.Domain.Migrations
//{
//    /// <inheritdoc />
//    public partial class removemember : Migration
//    {
//        /// <inheritdoc />
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropForeignKey(
//                name: "FK_SupplierReports_Account_AccountID",
//                table: "SupplierReports");

//            migrationBuilder.DropForeignKey(
//                name: "FK_Suppliers_Vourchers_VourcherID",
//                table: "Suppliers");

           

//            migrationBuilder.DropForeignKey(
//                name: "FK_Transactions_Account_AccountID",
//                table: "Transactions");

            
//            migrationBuilder.DropTable(
//                name: "OrderHistory");

//            migrationBuilder.DropTable(
//                name: "Account");

            
//            migrationBuilder.DropIndex(
//                name: "IX_Transactions_AccountID",
//                table: "Transactions");

//            migrationBuilder.DropIndex(
//                name: "IX_Suppliers_VourcherID",
//                table: "Suppliers");

//            migrationBuilder.DropIndex(
//                name: "IX_SupplierReports_AccountID",
//                table: "SupplierReports");

//            migrationBuilder.DropColumn(
//                name: "BankId",
//                table: "Transactions");

            
//            migrationBuilder.DropColumn(
//                name: "AccountID",
//                table: "Transactions");

//            migrationBuilder.DropColumn(
//                name: "AccountID",
//                table: "SupplierReports");

//            migrationBuilder.RenameColumn(
//                name: "status",
//                table: "Suppliers",
//                newName: "IsDisable");

//            migrationBuilder.RenameColumn(
//                name: "status",
//                table: "Staffs",
//                newName: "IsDisable");

//            migrationBuilder.RenameColumn(
//                name: "status",
//                table: "ReturnDetails",
//                newName: "IsDisable");

//            migrationBuilder.RenameColumn(
//                name: "status",
//                table: "ProductVouchers",
//                newName: "IsDisable");

//            migrationBuilder.AddColumn<bool>(
//                name: "IsDisable",
//                table: "Wishlists",
//                type: "bit",
//                nullable: false,
//                defaultValue: false);

//            migrationBuilder.AddColumn<string>(
//                name: "AccountID",
//                table: "Transactions",
//                type: "nvarchar(450)",
//                nullable: false,
//                defaultValue: "");

//            migrationBuilder.AddColumn<string>(
//                name: "AccountID",
//                table: "SupplierReports",
//                type: "nvarchar(450)",
//                nullable: true);

//            migrationBuilder.AddColumn<bool>(
//                name: "IsDisable",
//                table: "Ratings",
//                type: "bit",
//                nullable: false,
//                defaultValue: false);

//            migrationBuilder.AddColumn<bool>(
//                name: "IsDisable",
//                table: "Policies",
//                type: "bit",
//                nullable: false,
//                defaultValue: false);

//            migrationBuilder.AddColumn<string>(
//                name: "AccountHolder",
//                table: "AspNetUsers",
//                type: "nvarchar(max)",
//                nullable: false,
//                defaultValue: "");

//            migrationBuilder.AddColumn<string>(
//                name: "AccountNumber",
//                table: "AspNetUsers",
//                type: "nvarchar(max)",
//                nullable: false,
//                defaultValue: "");

//            migrationBuilder.AddColumn<string>(
//                name: "BankName",
//                table: "AspNetUsers",
//                type: "nvarchar(max)",
//                nullable: false,
//                defaultValue: "");

//            migrationBuilder.CreateIndex(
//                name: "IX_Transactions_AccountID",
//                table: "Transactions",
//                column: "AccountID");

//            migrationBuilder.CreateIndex(
//                name: "IX_SupplierReports_AccountID",
//                table: "SupplierReports",
//                column: "AccountID");

//            migrationBuilder.AddForeignKey(
//                name: "FK_SupplierReports_AspNetUsers_AccountID",
//                table: "SupplierReports",
//                column: "AccountID",
//                principalTable: "AspNetUsers",
//                principalColumn: "Id");

//            migrationBuilder.AddForeignKey(
//                name: "FK_Transactions_AspNetUsers_AccountID",
//                table: "Transactions",
//                column: "AccountID",
//                principalTable: "AspNetUsers",
//                principalColumn: "Id",
//                onDelete: ReferentialAction.Cascade);
//        }

//        /// <inheritdoc />
//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropForeignKey(
//                name: "FK_SupplierReports_AspNetUsers_AccountID",
//                table: "SupplierReports");

//            migrationBuilder.DropForeignKey(
//                name: "FK_Transactions_AspNetUsers_AccountID",
//                table: "Transactions");

//            migrationBuilder.DropIndex(
//                name: "IX_Transactions_AccountID",
//                table: "Transactions");

//            migrationBuilder.DropIndex(
//                name: "IX_SupplierReports_AccountID",
//                table: "SupplierReports");

//            migrationBuilder.DropColumn(
//                name: "IsDisable",
//                table: "Wishlists");

//            migrationBuilder.DropColumn(
//                name: "AccountID",
//                table: "Transactions");

//            migrationBuilder.DropColumn(
//                name: "AccountID",
//                table: "SupplierReports");

//            migrationBuilder.DropColumn(
//                name: "IsDisable",
//                table: "Ratings");

//            migrationBuilder.DropColumn(
//                name: "IsDisable",
//                table: "Policies");

//            migrationBuilder.DropColumn(
//                name: "AccountHolder",
//                table: "AspNetUsers");

//            migrationBuilder.DropColumn(
//                name: "AccountNumber",
//                table: "AspNetUsers");

//            migrationBuilder.DropColumn(
//                name: "BankName",
//                table: "AspNetUsers");

//            migrationBuilder.RenameColumn(
//                name: "IsDisable",
//                table: "Suppliers",
//                newName: "status");

//            migrationBuilder.RenameColumn(
//                name: "IsDisable",
//                table: "Staffs",
//                newName: "status");

//            migrationBuilder.RenameColumn(
//                name: "IsDisable",
//                table: "ReturnDetails",
//                newName: "status");

//            migrationBuilder.RenameColumn(
//                name: "IsDisable",
//                table: "ProductVouchers",
//                newName: "status");

//            migrationBuilder.AddColumn<Guid>(
//                name: "BankId",
//                table: "Transactions",
//                type: "uniqueidentifier",
//                nullable: false,
//                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
             
//            migrationBuilder.AddColumn<Guid>(
//                name: "AccountID",
//                table: "Transactions",
//                type: "uniqueidentifier",
//                nullable: false,
//                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

//            migrationBuilder.AddColumn<Guid>(
//                name: "AccountID",
//                table: "SupplierReports",
//                type: "uniqueidentifier",
//                nullable: false,
//                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

           
//            migrationBuilder.CreateTable(
//                name: "Account",
//                columns: table => new
//                {
//                    AccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
//                     Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
//                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    Gender = table.Column<int>(type: "int", nullable: false),
//                    Hobby = table.Column<int>(type: "int", nullable: true),
//                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    IsActive = table.Column<bool>(type: "bit", nullable: false),
//                    IsAdult = table.Column<bool>(type: "bit", nullable: false),
//                    IsVerfiedPhoneNumber = table.Column<bool>(type: "bit", nullable: true),
//                    IsVerifiedEmail = table.Column<bool>(type: "bit", nullable: true),
//                    Job = table.Column<int>(type: "int", nullable: true),
//                    JoinedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
//                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    Money = table.Column<double>(type: "float", nullable: false),
//                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    VerficationCodeEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    VerficationCodePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Account", x => x.AccountID);
//                    table.ForeignKey(
//                        name: "FK_Account_AspNetUsers_AccountID",
//                        column: x => x.AccountID,
//                        principalTable: "AspNetUsers",
//                        principalColumn: "Id");
//                });

//            migrationBuilder.CreateTable(
//                name: "OrderHistory",
//                columns: table => new
//                {
//                    OrderHistoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
//                    AccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
//                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
//                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
//                    OrderDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    OrderStatus = table.Column<int>(type: "int", nullable: false),
//                    TotalAmount = table.Column<double>(type: "float", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_OrderHistory", x => x.OrderHistoryID);
//                    table.ForeignKey(
//                        name: "FK_OrderHistory_Account_AccountID",
//                        column: x => x.AccountID,
//                        principalTable: "Account",
//                        principalColumn: "AccountID",
//                        onDelete: ReferentialAction.Cascade);
//                    table.ForeignKey(
//                        name: "FK_OrderHistory_Orders_OrderID",
//                        column: x => x.OrderID,
//                        principalTable: "Orders",
//                        principalColumn: "OrderID",
//                        onDelete: ReferentialAction.Cascade);
//                });

            

//            migrationBuilder.CreateIndex(
//                name: "IX_Transactions_AccountID",
//                table: "Transactions",
//                column: "AccountID");

//            migrationBuilder.CreateIndex(
//                name: "IX_Suppliers_VourcherID",
//                table: "Suppliers",
//                column: "VourcherID");

//            migrationBuilder.CreateIndex(
//                name: "IX_SupplierReports_AccountID",
//                table: "SupplierReports",
//                column: "AccountID");

        

//            migrationBuilder.CreateIndex(
//                name: "IX_Account_AccountID",
//                table: "Account",
//                column: "AccountID");

//            migrationBuilder.CreateIndex(
//                name: "IX_OrderHistory_AccountID",
//                table: "OrderHistory",
//                column: "AccountID",
//                unique: true);

//            migrationBuilder.CreateIndex(
//                name: "IX_OrderHistory_OrderID",
//                table: "OrderHistory",
//                column: "OrderID");

//            migrationBuilder.AddForeignKey(
//                name: "FK_SupplierReports_Account_AccountID",
//                table: "SupplierReports",
//                column: "AccountID",
//                principalTable: "Account",
//                principalColumn: "AccountID",
//                onDelete: ReferentialAction.Cascade);

//            migrationBuilder.AddForeignKey(
//                name: "FK_Suppliers_Vourchers_VourcherID",
//                table: "Suppliers",
//                column: "VourcherID",
//                principalTable: "Vourchers",
//                principalColumn: "VourcherID");

          

//            migrationBuilder.AddForeignKey(
//                name: "FK_Transactions_Account_AccountID",
//                table: "Transactions",
//                column: "AccountID",
//                principalTable: "Account",
//                principalColumn: "AccountID",
//                onDelete: ReferentialAction.Cascade);
//        }
//    }
//}
