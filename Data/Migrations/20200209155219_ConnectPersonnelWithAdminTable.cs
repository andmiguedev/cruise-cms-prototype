using Microsoft.EntityFrameworkCore.Migrations;

namespace CruiseCMSDemo.Data.Migrations
{
    public partial class ConnectPersonnelWithAdminTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Administrator");

            migrationBuilder.AddColumn<int>(
                name: "PersonnelId",
                table: "Administrator",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_PersonnelId",
                table: "Administrator",
                column: "PersonnelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Administrator_Personnel_PersonnelId",
                table: "Administrator",
                column: "PersonnelId",
                principalTable: "Personnel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administrator_Personnel_PersonnelId",
                table: "Administrator");

            migrationBuilder.DropIndex(
                name: "IX_Administrator_PersonnelId",
                table: "Administrator");

            migrationBuilder.DropColumn(
                name: "PersonnelId",
                table: "Administrator");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Administrator",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
