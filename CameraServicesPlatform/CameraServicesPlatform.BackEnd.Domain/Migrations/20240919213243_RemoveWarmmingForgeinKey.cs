/*using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CameraServicesPlatform.BackEnd.Domain.Migrations
{
    /// <inheritdoc />
    public partial class RemoveWarmmingForgeinKey : Migration
    {
        /// <inheritdoc /
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_OrderHistory_OrderHistoryID",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Account_Orders_OrderID",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Account_Wishlist_WishlistID",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Contracts_ContractID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderDetails_OrderDetailID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ReturnDetails_ReturnDetailID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Transactions_TransactionID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_RentalPrice_RentalPriceID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_HistoryTransaction_HistoryTransactionID",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Payment_PaymentID",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Products_ProductID",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_SupplierDeliveriesMethod_SupplierDeliveriesMethodID",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_SupplierRequests_SupplierRequestID",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_BankInformation_BankId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Account_AccountID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Orders_OrderID",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "HistoryTransaction");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "RentalPrice");

            migrationBuilder.DropTable(
                name: "SupplierDeliveriesMethod");

            migrationBuilder.DropTable(
                name: "Wishlist");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_BankId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_OrderID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_HistoryTransactionID",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_PaymentID",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_ProductID",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_SupplierDeliveriesMethodID",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_SupplierRequestID",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Products_RentalPriceID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ContractID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderDetailID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ReturnDetailID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TransactionID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderHistory_AccountID",
                table: "OrderHistory");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_Account_OrderHistoryID",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_OrderID",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_WishlistID",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "HistoryTransactionID",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "PaymentID",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "SupplierDeliveriesMethodID",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "SupplierRequestID",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "RentalPriceID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ContractID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ReturnDetailID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TransactionID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderHistoryID",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "WishlistID",
                table: "Account");

            migrationBuilder.AddColumn<Guid>(
                name: "BankInformationBankId",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "ApplicableObject",
                table: "Policies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "OrderDetails",
                table: "OrderHistory",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b21c4d5e-67fg-89hi-01jk-lmnopqrstuv",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "MEMBER", "Member" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c32d5e6f-78gh-90ij-12kl-mnopqrstuv",
                column: "NormalizedName",
                value: "Staff");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BankInformationBankId",
                table: "Transactions",
                column: "BankInformationBankId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_OrderID",
                table: "Transactions",
                column: "OrderID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistory_AccountID",
                table: "OrderHistory",
                column: "AccountID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails",
                column: "OrderID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_BankInformation_BankInformationBankId",
                table: "Transactions",
                column: "BankInformationBankId",
                principalTable: "BankInformation",
                principalColumn: "BankId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Account_AccountID",
                table: "Transactions",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Orders_OrderID",
                table: "Transactions",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_BankInformation_BankInformationBankId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Account_AccountID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Orders_OrderID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_BankInformationBankId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_OrderID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_OrderHistory_AccountID",
                table: "OrderHistory");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "BankInformationBankId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ApplicableObject",
                table: "Policies");

            migrationBuilder.AddColumn<Guid>(
                name: "HistoryTransactionID",
                table: "Suppliers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentID",
                table: "Suppliers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductID",
                table: "Suppliers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierDeliveriesMethodID",
                table: "Suppliers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierRequestID",
                table: "Suppliers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RentalPriceID",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ContractID",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReturnDetailID",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TransactionID",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrderDetails",
                table: "OrderHistory",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderHistoryID",
                table: "Account",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderID",
                table: "Account",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WishlistID",
                table: "Account",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HistoryTransaction",
                columns: table => new
                {
                    HistoryTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TransactionDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryTransaction", x => x.HistoryTransactionId);
                    table.ForeignKey(
                        name: "FK_HistoryTransaction_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SupplierID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PaymentAmount = table.Column<decimal>(nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payment_AspNetUsers_AccountID",
                        column: x => x.AccountID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID");
                    table.ForeignKey(
                        name: "FK_Payment_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RentalPrice",
                columns: table => new
                {
                    RentalPriceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PricePerDay = table.Column<decimal>(nullable: false),
                    PricePerMonth = table.Column<decimal>(nullable: true),
                    PricePerWeek = table.Column<decimal>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalPrice", x => x.RentalPriceID);
                    table.ForeignKey(
                        name: "FK_RentalPrice_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupplierDeliveriesMethod",
                columns: table => new
                {
                    SupplierDeliveriesMethodID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveriesMethodID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierDeliveriesMethod", x => x.SupplierDeliveriesMethodID);
                    table.ForeignKey(
                        name: "FK_SupplierDeliveriesMethod_DeliveriesMethod_DeliveriesMethodID",
                        column: x => x.DeliveriesMethodID,
                        principalTable: "DeliveriesMethod",
                        principalColumn: "DeliveriesMethodID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupplierDeliveriesMethod_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wishlist",
                columns: table => new
                {
                    WishlistID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist", x => x.WishlistID);
                    table.ForeignKey(
                        name: "FK_Wishlist_Account_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wishlist_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b21c4d5e-67fg-89hi-01jk-lmnopqrstuv",
                columns: new[] { "Name", "NormalizedName" },
               values: new object[] { "MEMBER", "MEMBER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c32d5e6f-78gh-90ij-12kl-mnopqrstuv",
                column: "NormalizedName",
                value: "STAFF");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BankId",
                table: "Transactions",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_OrderID",
                table: "Transactions",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_HistoryTransactionID",
                table: "Suppliers",
                column: "HistoryTransactionID");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_PaymentID",
                table: "Suppliers",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_ProductID",
                table: "Suppliers",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_SupplierDeliveriesMethodID",
                table: "Suppliers",
                column: "SupplierDeliveriesMethodID");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_SupplierRequestID",
                table: "Suppliers",
                column: "SupplierRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RentalPriceID",
                table: "Products",
                column: "RentalPriceID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ContractID",
                table: "Orders",
                column: "ContractID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderDetailID",
                table: "Orders",
                column: "OrderDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ReturnDetailID",
                table: "Orders",
                column: "ReturnDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TransactionID",
                table: "Orders",
                column: "TransactionID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistory_AccountID",
                table: "OrderHistory",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Account_OrderHistoryID",
                table: "Account",
                column: "OrderHistoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Account_OrderID",
                table: "Account",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Account_WishlistID",
                table: "Account",
                column: "WishlistID");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryTransaction_SupplierID",
                table: "HistoryTransaction",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_AccountID",
                table: "Payment",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_OrderID",
                table: "Payment",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_SupplierID",
                table: "Payment",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_RentalPrice_ProductID",
                table: "RentalPrice",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierDeliveriesMethod_DeliveriesMethodID",
                table: "SupplierDeliveriesMethod",
                column: "DeliveriesMethodID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierDeliveriesMethod_SupplierID",
                table: "SupplierDeliveriesMethod",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_AccountID",
                table: "Wishlist",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_ProductID",
                table: "Wishlist",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_OrderHistory_OrderHistoryID",
                table: "Account",
                column: "OrderHistoryID",
                principalTable: "OrderHistory",
                principalColumn: "OrderHistoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Orders_OrderID",
                table: "Account",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Wishlist_WishlistID",
                table: "Account",
                column: "WishlistID",
                principalTable: "Wishlist",
                principalColumn: "WishlistID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Contracts_ContractID",
                table: "Orders",
                column: "ContractID",
                principalTable: "Contracts",
                principalColumn: "ContractID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderDetails_OrderDetailID",
                table: "Orders",
                column: "OrderDetailID",
                principalTable: "OrderDetails",
                principalColumn: "OrderDetailsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ReturnDetails_ReturnDetailID",
                table: "Orders",
                column: "ReturnDetailID",
                principalTable: "ReturnDetails",
                principalColumn: "ReturnID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Transactions_TransactionID",
                table: "Orders",
                column: "TransactionID",
                principalTable: "Transactions",
                principalColumn: "TransactionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_RentalPrice_RentalPriceID",
                table: "Products",
                column: "RentalPriceID",
                principalTable: "RentalPrice",
                principalColumn: "RentalPriceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_HistoryTransaction_HistoryTransactionID",
                table: "Suppliers",
                column: "HistoryTransactionID",
                principalTable: "HistoryTransaction",
                principalColumn: "HistoryTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Payment_PaymentID",
                table: "Suppliers",
                column: "PaymentID",
                principalTable: "Payment",
                principalColumn: "PaymentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Products_ProductID",
                table: "Suppliers",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_SupplierDeliveriesMethod_SupplierDeliveriesMethodID",
                table: "Suppliers",
                column: "SupplierDeliveriesMethodID",
                principalTable: "SupplierDeliveriesMethod",
                principalColumn: "SupplierDeliveriesMethodID");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_SupplierRequests_SupplierRequestID",
                table: "Suppliers",
                column: "SupplierRequestID",
                principalTable: "SupplierRequests",
                principalColumn: "SupplierRequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_BankInformation_BankId",
                table: "Transactions",
                column: "BankId",
                principalTable: "BankInformation",
                principalColumn: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Account_AccountID",
                table: "Transactions",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Orders_OrderID",
                table: "Transactions",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID");
        }
    }
}
*/