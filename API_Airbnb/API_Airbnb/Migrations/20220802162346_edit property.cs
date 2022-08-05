using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Airbnb.Migrations
{
    public partial class editproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "ar_properties",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "ar_properties");
        }
    }
}
