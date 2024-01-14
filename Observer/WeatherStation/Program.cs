namespace WeatherStation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();

            Display display = new Display();
            weatherData.RegisterObserver(display, 2);

            StatsDisplay statsDisplay = new StatsDisplay();
            weatherData.RegisterObserver(statsDisplay, 1);

            weatherData.SetMeasurements(3, 0.7, 760);

            weatherData.UnregisterObserver(statsDisplay);

            weatherData.SetMeasurements(10, 0.8, 761);
        }
    }
}