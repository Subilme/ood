using WeatherStation;
using Xunit;

namespace WeatherStationTests
{
    public class ProrityTests
    {
        [Fact]
        public void CheckObserversPriority()
        {
            WeatherData weatherData = new WeatherData();

            PriorityObserverMock first = new PriorityObserverMock(1);
            PriorityObserverMock second = new PriorityObserverMock(2);
            PriorityObserverMock third = new PriorityObserverMock(3);

            weatherData.RegisterObserver(first, 3);
            weatherData.RegisterObserver(second, 1);
            weatherData.RegisterObserver(third, 2);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            weatherData.SetMeasurements(0, 0, 760);

            Assert.Equal("231", writer.ToString());
        }
    }
}
