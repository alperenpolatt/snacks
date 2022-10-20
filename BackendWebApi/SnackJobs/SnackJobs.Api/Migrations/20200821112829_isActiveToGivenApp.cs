using Microsoft.EntityFrameworkCore.Migrations;

namespace SnackJobs.Api.Migrations
{
    public partial class isActiveToGivenApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "GivenApplications",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "GivenApplications");
        }
    }
}
