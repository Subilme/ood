namespace WeatherStationDuo
{
    public class Stats
    {
        private StatsData _temperature = new StatsData();
        private StatsData _humidity = new StatsData();
        private StatsData _pressure = new StatsData();

        public void Update(WeatherInfo data)
        {
            _temperature.Update(data.Temperature);
            _humidity.Update(data.Humidity);
            _pressure.Update(data.Pressure);
        }

        public new void ToString()
        {
            Console.WriteLine($"Temperature: {_temperature.ToString()}");
            Console.WriteLine($"Humidity: {_humidity.ToString()}");
            Console.WriteLine($"Pressure: {_pressure.ToString()}");
        }
    }
}
