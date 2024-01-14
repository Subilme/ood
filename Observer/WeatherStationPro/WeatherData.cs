namespace WeatherStationPro
{
    public class WeatherData : Observable<WeatherInfo>
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Pressure { get; set; }
        public WindInfo Wind { get; set; } = new WindInfo();

        public void SetMeasurements(double temp, double hum, double pressure, double direction, double speed)
        {
            Temperature = temp;
            Humidity = hum;
            Pressure = pressure;
            Wind.Direction = direction;
            Wind.Speed = speed;

            NotifyObservers();
        }

        protected override WeatherInfo GetChangedData()
        {
            return new WeatherInfo() { Temperature = this.Temperature, Humidity = this.Humidity,
                Pressure = this.Pressure, Wind = this.Wind };
        }
    }
}
