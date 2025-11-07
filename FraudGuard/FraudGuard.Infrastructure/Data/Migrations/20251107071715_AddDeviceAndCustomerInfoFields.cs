using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FraudGuard.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDeviceAndCustomerInfoFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Customer",
                table: "Transactions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "Transactions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "Transactions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeviceLocation",
                table: "Transactions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Customer",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "DeviceLocation",
                table: "Transactions");
        }
    }
}
