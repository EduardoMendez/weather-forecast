using Microsoft.EntityFrameworkCore.Migrations;
using WeatherForecast;

namespace WeatherForecastAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DayWeathers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(nullable: false),
                    Weather = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayWeathers", x => x.Id);
                });

            InitializeData(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayWeathers");
        }

        private void InitializeData(MigrationBuilder migrationBuilder)
        {
            var galaxy = Galaxy.GetVulcanosFerengisBetasoidesGalaxy();

            var days = new WeatherForecaster(galaxy.Planets, galaxy.Sun).GetDayWeatherForecastForYears(10);

            foreach (var d in days)
            {
                string[] columns = { "Day", "Weather" };
                object[] values = { d.Day, d.Weather.Description };

                migrationBuilder.InsertData("DayWeathers", columns, values);
            }
        }
    }
}
