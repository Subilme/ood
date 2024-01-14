namespace WeatherStationDuo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WeatherData inWeather = new WeatherData();
            WeatherData outWeather = new WeatherData();

            StatsDisplay display = new StatsDisplay(inWeather, outWeather);
            inWeather.RegisterObserver(display, 1);
            outWeather.RegisterObserver(display, 1);

            inWeather.SetMeasurements(16, 0.6, 754);
            Console.WriteLine();
            outWeather.SetMeasurements(10, 0.3, 760);
            Console.WriteLine();
            inWeather.SetMeasurements(12, 0.5, 783);
            Console.WriteLine();
            outWeather.SetMeasurements(4, 0.1, 739);
        }
    }
}