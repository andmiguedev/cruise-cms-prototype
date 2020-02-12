using Microsoft.EntityFrameworkCore.Migrations;

namespace CruiseCMSDemo.Data.Migrations
{
    public partial class AddCompleteNameForPersonnel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Personnel");

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Personnel",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Fleet",
                table: "Personnel",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Personnel",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Personnel",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MiddleInitials",
                table: "Personnel",
                maxLength: 2,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Personnel");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Personnel");

            migrationBuilder.DropColumn(
                name: "MiddleInitials",
                table: "Personnel");

            migrationBuilder.AlterColumn<double>(
                name: "Salary",
                table: "Personnel",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "Fleet",
                table: "Personnel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Personnel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
