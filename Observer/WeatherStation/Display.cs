namespace WeatherStation
{
    public class Display : IObserver<WeatherInfo>
    {
        public void Update(WeatherInfo data)
        {
            Console.WriteLine($"Current temp: {data.Temperature}");
            Console.WriteLine($"Current hum: {data.Humidity}");
            Console.WriteLine($"Current pressure: {data.Pressure}");
            Console.WriteLine("----------------");
        }
    }
}
