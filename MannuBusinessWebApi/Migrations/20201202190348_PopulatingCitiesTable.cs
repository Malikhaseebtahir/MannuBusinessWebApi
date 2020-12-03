using Microsoft.EntityFrameworkCore.Migrations;

namespace MannuBusinessWebApi.Migrations
{
    public partial class PopulatingCitiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Cities (Name, ProvinceId) VALUES ('Multan', (SELECT Id FROM Provinces WHERE Name = 'Punjab'))");
            migrationBuilder.Sql("INSERT INTO Cities (Name, ProvinceId) VALUES ('Lahore', (SELECT Id FROM Provinces WHERE Name = 'Punjab'))");
            migrationBuilder.Sql("INSERT INTO Cities (Name, ProvinceId) VALUES ('Karachi', (SELECT Id FROM Provinces WHERE Name = 'Sindh'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE * FROM Cities WHERE Name IN ('Multan', 'Lahore', 'Karachi'");
        }
    }
}
