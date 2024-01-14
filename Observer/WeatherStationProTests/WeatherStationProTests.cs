using Xunit;
using WeatherStationPro;

namespace WeatherStationProTests
{
    public class WeatherStationProTests
    {
        [Fact]
        public void Observer()
        {
            WeatherData weatherData = new WeatherData();
            StatsDisplay display = new StatsDisplay();
            weatherData.RegisterObserver(display, 1);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            weatherData.SetMeasurements(3, 0.7, 760, 180, 2);
            string expected = "Temperature: Max 3, Min 3, Average 3\r\n" +
                "Humidity: Max 0,7, Min 0,7, Average 0,7\r\n" +
                "Pressure: Max 760, Min 760, Average 760\r\n" +
                "Wind: speed: Max 2, Min 2, Average 2, Avg direction: 180\r\n" +
                "----------------\r\n";

            Assert.Equal(expected, writer.ToString());

            weatherData.SetMeasurements(10, 0.24, 7511, 90, 9);
            expected += "Temperature: Max 10, Min 3, Average 6,5\r\n" +
                "Humidity: Max 0,7, Min 0,24, Average 0,47\r\n" +
                "Pressure: Max 7511, Min 760, Average 4135,5\r\n" +
                "Wind: speed: Max 9, Min 2, Average 5,5, Avg direction: 135\r\n" +
                "----------------\r\n";

            Assert.Equal(expected, writer.ToString());
        }
    }
}
