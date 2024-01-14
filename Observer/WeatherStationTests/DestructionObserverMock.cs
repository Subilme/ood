using WeatherStation;

namespace WeatherStationTests
{
    public class DestructionObserverMock : WeatherStation.IObserver<WeatherInfo>
    {
        private Observable<WeatherInfo> _observable;

        public DestructionObserverMock(Observable<WeatherInfo> observable)
        {
            _observable = observable;
        }

        public void Update(WeatherInfo data)
        {
            _observable.UnregisterObserver(this);

            Console.WriteLine($"Current temp: {data.Temperature}");
            Console.WriteLine($"Current hum: {data.Humidity}");
            Console.WriteLine($"Current pressure: {data.Pressure}");
            Console.WriteLine("----------------");
        }
    }
}
