using Microsoft.EntityFrameworkCore.Migrations;
using WeatherForecast;
using System.Linq;
using System.Collections.Generic;

namespace WeatherForecastAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(nullable: false),
                    Weather = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.Id);
                });

            InitializeData(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Days");
        }


        private void InitializeData(MigrationBuilder migrationBuilder)
        {
            var ferengi = new Planet("ferengi", 1, Direction.CLOCKWISE, 500);
            var vulcano = new Planet("vulcano", 5, Direction.COUNTERCLOCKWISE, 1000);
            var betasoide = new Planet("betasoide", 3, Direction.CLOCKWISE, 2000);

            var planets = new List<Planet>()
            {
                ferengi, vulcano, betasoide
            };

            var sun = new Point(0, 0);

            var days = new WeatherForecaster(planets, sun).GetDayWeatherForecastForYears(10);

            foreach(var d in days)
            {
                string[] columns = { "Day", "Weather" };
                object[] values = { d.Day, d.Weather.Description };

                migrationBuilder.InsertData("Days", columns, values);
            }
        }
    }
}
