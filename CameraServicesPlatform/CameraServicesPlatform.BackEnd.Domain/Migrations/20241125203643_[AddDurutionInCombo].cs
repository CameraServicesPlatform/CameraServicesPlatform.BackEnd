using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CameraServicesPlatform.BackEnd.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddDurutionInCombo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DurationCombo",
                table: "Combos",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationCombo",
                table: "Combos");
        }
    }
}
