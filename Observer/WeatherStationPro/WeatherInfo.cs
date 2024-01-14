namespace WeatherStationPro
{
    public struct WeatherInfo
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Pressure { get; set; }
        public WindInfo Wind { get; set; }
    }
}
