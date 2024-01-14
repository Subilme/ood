using Xunit;
using WeatherStationDuo;

namespace WeatherStationDuoTests
{
    public class WeatherStationDuoTests
    {
        [Fact]
        public void ObserverGetNotifiedByTwoDifferentObservable()
        {
            WeatherData inWeather = new WeatherData();
            WeatherData outWeather = new WeatherData();
            StatsDisplay display = new StatsDisplay(inWeather, outWeather);
            inWeather.RegisterObserver(display, 1);
            outWeather.RegisterObserver(display, 1);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            inWeather.SetMeasurements(16, 0.6, 754);
            outWeather.SetMeasurements(10, 0.3, 760);
            string expected = "Temperature: Max 16, Min 16, Average 16\r\n" +
                "Humidity: Max 0,6, Min 0,6, Average 0,6\r\n" +
                "Pressure: Max 754, Min 754, Average 754\r\n" +
                "Temperature: Max 10, Min 10, Average 10\r\nHumidity: Max 0,3, Min 0,3, Average 0,3\r\n" +
                "Pressure: Max 760, Min 760, Average 760\r\n";

            Assert.Equal(expected, writer.ToString());

            inWeather.SetMeasurements(12, 0.5, 783);
            outWeather.SetMeasurements(4, 0.1, 739);
            expected += "Temperature: Max 16, Min 12, Average 14\r\n" +
                "Humidity: Max 0,6, Min 0,5, Average 0,55\r\n" +
                "Pressure: Max 783, Min 754, Average 768,5\r\n" +
                "Temperature: Max 10, Min 4, Average 7\r\n" +
                "Humidity: Max 0,3, Min 0,1, Average 0,2\r\n" +
                "Pressure: Max 760, Min 739, Average 749,5\r\n";

            Assert.Equal(expected, writer.ToString());
        }
    }
}
