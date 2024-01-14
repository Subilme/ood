namespace WeatherStation
{
    public class StatsDisplay : IObserver<WeatherInfo>
    {
        private StatsData _temperature;
        private StatsData _humidity;
        private StatsData _pressure;

        public StatsDisplay()
        {
            _temperature = new StatsData();
            _humidity = new StatsData();
            _pressure = new StatsData();
        }

        public void Update(WeatherInfo data)
        {
            _temperature.Update(data.Temperature);
            _humidity.Update(data.Humidity);
            _pressure.Update(data.Pressure);

            Console.WriteLine($"Temperature: {_temperature.ToString()}");
            Console.WriteLine($"Humidity: {_humidity.ToString()}");
            Console.WriteLine($"Pressure: {_pressure.ToString()}");
            Console.WriteLine("----------------");
        }
    }
}
