using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CruiseCMSDemo.Data.Migrations
{
    public partial class RemoveImagePathInAdminTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Admin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Admin",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
