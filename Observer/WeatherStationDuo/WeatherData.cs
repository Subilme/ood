namespace WeatherStationDuo
{
    public class WeatherData : Observable<WeatherInfo>
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Pressure { get; set; }

        public void SetMeasurements(double temp, double hum, double pressure)
        {
            Temperature = temp;
            Humidity = hum;
            Pressure = pressure;

            NotifyObservers();
        }

        protected override WeatherInfo GetChangedData()
        {
            return new WeatherInfo() { Temperature = this.Temperature, Humidity = this.Humidity, Pressure = this.Pressure };
        }
    }
}
