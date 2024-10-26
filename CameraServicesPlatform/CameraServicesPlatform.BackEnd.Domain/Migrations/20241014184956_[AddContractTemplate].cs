using System;
using Microsoft.EntityFrameworkCore.Migrations;

//#nullable disable

//namespace CameraServicesPlatform.BackEnd.Domain.Migrations
//{
//    /// <inheritdoc />
//    public partial class AddContractTemplate : Migration
//    {
//        /// <inheritdoc />
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.CreateTable(
//                name: "ContractTemplates",
//                columns: table => new
//                {
//                    ContractTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
//                    TemplateName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
//                    ContractTerms = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    TemplateDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    PenaltyPolicy = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
//                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
//                    AccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_ContractTemplates", x => x.ContractTemplateId);
//                    table.ForeignKey(
//                        name: "FK_ContractTemplates_Account_AccountID",
//                        column: x => x.AccountID,
//                        principalTable: "Account",
//                        principalColumn: "AccountID",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateIndex(
//                name: "IX_ContractTemplates_AccountID",
//                table: "ContractTemplates",
//                column: "AccountID");
//        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractTemplates");
        }
    }
}
