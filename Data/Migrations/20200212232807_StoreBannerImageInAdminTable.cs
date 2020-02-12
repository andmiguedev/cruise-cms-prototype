using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CruiseCMSDemo.Data.Migrations
{
    public partial class StoreBannerImageInAdminTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Admin",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Admin");
        }
    }
}
