using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Airbnb.Migrations
{
    public partial class Editlength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "longitude",
                table: "ar_properties",
                type: "nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "latitude",
                table: "ar_properties",
                type: "nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "longitude",
                table: "ar_properties",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "latitude",
                table: "ar_properties",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldNullable: true);
        }
    }
}
