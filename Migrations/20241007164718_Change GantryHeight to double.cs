using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkNow.Migrations
{
    /// <inheritdoc />
    public partial class ChangeGantryHeighttodouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "GantryHeight",
                table: "Carparks",
                type: "float",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "GantryHeight",
                table: "Carparks",
                type: "bit",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
