namespace WeatherStationPro
{
    public class StatsDisplay : IObserver<WeatherInfo>
    {
        private StatsData _temperature;
        private StatsData _humidity;
        private StatsData _pressure;
        private StatsData _windSpeed;
        private StatsWindDirection _windDirection;

        public StatsDisplay()
        {
            _temperature = new StatsData();
            _humidity = new StatsData();
            _pressure = new StatsData();
            _windSpeed = new StatsData();
            _windDirection = new StatsWindDirection();
        }

        public void Update(WeatherInfo data)
        {
            _temperature.Update(data.Temperature);
            _humidity.Update(data.Humidity);
            _pressure.Update(data.Pressure);
            _windSpeed.Update(data.Wind.Speed);
            _windDirection.Update(data.Wind.Direction);

            Console.WriteLine($"Temperature: {_temperature.ToString()}");
            Console.WriteLine($"Humidity: {_humidity.ToString()}");
            Console.WriteLine($"Pressure: {_pressure.ToString()}");
            Console.WriteLine($"Wind: speed: {_windSpeed.ToString()}, {_windDirection.ToString()}");
            Console.WriteLine("----------------");
        }
    }
}
