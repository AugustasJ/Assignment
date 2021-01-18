using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeAssignmentLibrary.API.Migrations
{
    public partial class AddColumnAgreementNewBaseRateCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NewBaseRateCode",
                table: "Agreements",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewBaseRateCode",
                table: "Agreements");
        }
    }
}
