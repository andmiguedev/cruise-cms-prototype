using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CruiseCMSDemo.Data.Migrations
{
    public partial class AddGeneralDestinationFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destination",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Region = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: false),
                    Motto = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Population = table.Column<string>(nullable: true),
                    Picture = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destination", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Destination");
        }
    }
}
