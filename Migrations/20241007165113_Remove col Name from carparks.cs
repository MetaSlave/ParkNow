using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkNow.Migrations
{
    /// <inheritdoc />
    public partial class RemovecolNamefromcarparks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Carparks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Carparks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
