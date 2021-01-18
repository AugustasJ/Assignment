using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeAssignmentLibrary.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PersonalId = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agreements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    BaseRateCode = table.Column<string>(nullable: false),
                    Margin = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AgreementDuration = table.Column<int>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agreements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agreements_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "FirstName", "LastName", "PersonalId" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Goras", "Trusevičius", "67812203006" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "FirstName", "LastName", "PersonalId" },
                values: new object[] { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "Dange", "Kulkavičiutė", "78706151287" });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "Id", "AgreementDuration", "Amount", "BaseRateCode", "CustomerId", "Margin" },
                values: new object[] { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), 60, 12000, "VILIBOR3m", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), 1.6m });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "Id", "AgreementDuration", "Amount", "BaseRateCode", "CustomerId", "Margin" },
                values: new object[] { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"), 36, 8000, "VILIBOR1y", new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), 2.2m });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "Id", "AgreementDuration", "Amount", "BaseRateCode", "CustomerId", "Margin" },
                values: new object[] { new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"), 24, 1000, "VILIBOR6m", new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), 1.85m });

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_CustomerId",
                table: "Agreements",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agreements");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
