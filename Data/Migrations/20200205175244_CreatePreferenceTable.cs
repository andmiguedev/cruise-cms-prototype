using Microsoft.EntityFrameworkCore.Migrations;

namespace CruiseCMSDemo.Data.Migrations
{
    public partial class CreatePreferenceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Preference",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(nullable: false),
                    ItineraryId = table.Column<int>(nullable: false),
                    Cabin = table.Column<string>(nullable: true),
                    Events = table.Column<string>(nullable: true),
                    Tours = table.Column<string>(nullable: true),
                    Excursions = table.Column<string>(nullable: true),
                    Activities = table.Column<string>(nullable: true),
                    MostVisited = table.Column<string>(nullable: true),
                    AmountSpent = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Preference_Itinerary_ItineraryId",
                        column: x => x.ItineraryId,
                        principalTable: "Itinerary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Preference_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Preference_ItineraryId",
                table: "Preference",
                column: "ItineraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Preference_ProfileId",
                table: "Preference",
                column: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Preference");
        }
    }
}
