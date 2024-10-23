using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkNow.Migrations
{
    /// <inheritdoc />
    public partial class AddedScheduledtobookingsenum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Voucher_VoucherId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_Users_UserId",
                table: "Voucher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Voucher",
                table: "Voucher");

            migrationBuilder.RenameTable(
                name: "Voucher",
                newName: "Vouchers");

            migrationBuilder.RenameIndex(
                name: "IX_Voucher_UserId",
                table: "Vouchers",
                newName: "IX_Vouchers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vouchers",
                table: "Vouchers",
                column: "VoucherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Vouchers_VoucherId",
                table: "Payments",
                column: "VoucherId",
                principalTable: "Vouchers",
                principalColumn: "VoucherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vouchers_Users_UserId",
                table: "Vouchers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Vouchers_VoucherId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Vouchers_Users_UserId",
                table: "Vouchers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vouchers",
                table: "Vouchers");

            migrationBuilder.RenameTable(
                name: "Vouchers",
                newName: "Voucher");

            migrationBuilder.RenameIndex(
                name: "IX_Vouchers_UserId",
                table: "Voucher",
                newName: "IX_Voucher_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Voucher",
                table: "Voucher",
                column: "VoucherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Voucher_VoucherId",
                table: "Payments",
                column: "VoucherId",
                principalTable: "Voucher",
                principalColumn: "VoucherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_Users_UserId",
                table: "Voucher",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
