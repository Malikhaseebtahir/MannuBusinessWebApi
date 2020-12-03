using Microsoft.EntityFrameworkCore.Migrations;

namespace MannuBusinessWebApi.Migrations
{
    public partial class PopulatingProvincesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Provinces (Name, CountryId) VALUES ('Punjab', (SELECT Id FROM Countries Where Name = 'Pakistan'))");
            migrationBuilder.Sql("INSERT INTO Provinces (Name, CountryId) VALUES ('Sindh', (SELECT Id FROM Countries Where Name = 'Pakistan'))");
            migrationBuilder.Sql("INSERT INTO Provinces (Name, CountryId) VALUES ('Balochistan', (SELECT Id FROM Countries Where Name = 'Pakistan'))");
            migrationBuilder.Sql("INSERT INTO Provinces (Name, CountryId) VALUES ('Khyber Pakhtunkhwa', (SELECT Id FROM Countries Where Name = 'Pakistan'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE * FROM Provinces WHERE Name IN ('Punjab', 'Sindh', 'Balochistan', 'Khyber Pakhtunkhwa'");
        }
    }
}
