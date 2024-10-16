using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkNow.Migrations
{
    /// <inheritdoc />
    public partial class AddCentralChargetoCarparks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CentralCharge",
                table: "Carparks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CentralCharge",
                table: "Carparks");
        }
    }
}
