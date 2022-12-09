using WeatherStation;
using Xunit;

namespace WeatherStationTests
{
    public class DestructionObserverTest
    {
        [Fact]
        public void DestructObserverWhileUpdate_ThrowsNoException()
        {
            WeatherData weatherData = new WeatherData();
            DestructionObserver observer = new DestructionObserver(weatherData);
            StatsDisplay statsDisplay = new StatsDisplay();

            weatherData.RegisterObserver(observer, 1);
            weatherData.RegisterObserver(statsDisplay, 2);
            weatherData.SetMeasurements(0, 0, 760);

            Assert.True(true);
        }
    }
}
