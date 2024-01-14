using WeatherStation;

namespace WeatherStationTests
{
    public class PriorityObserverMock : WeatherStation.IObserver<WeatherInfo>
    {
        private int _priority;

        public PriorityObserverMock(int priority)
        {
            _priority = priority;
        }

        public void Update(WeatherInfo data)
        {
            Console.Write(_priority);
        }
    }
}
