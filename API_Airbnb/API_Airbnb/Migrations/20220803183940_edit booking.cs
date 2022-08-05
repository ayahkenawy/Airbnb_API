using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Airbnb.Migrations
{
    public partial class editbooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "children_count",
                table: "ar_bookings",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "guests_count",
                table: "ar_bookings",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "rooms_count",
                table: "ar_bookings",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "children_count",
                table: "ar_bookings");

            migrationBuilder.DropColumn(
                name: "guests_count",
                table: "ar_bookings");

            migrationBuilder.DropColumn(
                name: "rooms_count",
                table: "ar_bookings");
        }
    }
}
