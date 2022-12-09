namespace WeatherStation
{
    public class DestructionObserver : IObserver<WeatherInfo>
    {
        private Observable<WeatherInfo> _observable;

        public DestructionObserver(Observable<WeatherInfo> observable)
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
