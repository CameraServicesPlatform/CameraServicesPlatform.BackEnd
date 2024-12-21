using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CameraServicesPlatform.BackEnd.Domain.Migrations
{
    /// <inheritdoc />
    public partial class addtableSystemAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SystemAdmins",
                columns: table => new
                {
                    SystemAdminID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationMoney = table.Column<double>(type: "float", nullable: true),
                    CancelDurationUnit = table.Column<int>(type: "int", nullable: true),
                    CancelVaule = table.Column<int>(type: "int", nullable: true),
                    CancelAcceptDurationUnit = table.Column<int>(type: "int", nullable: true),
                    CancelAcceptVaule = table.Column<int>(type: "int", nullable: true),
                    ReservationMoneyCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CancelVauleCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CancelAcceptVauleCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemAdmins", x => x.SystemAdminID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemAdmins");
        }
    }
}
