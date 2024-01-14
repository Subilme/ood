namespace WeatherStationDuo
{
    public class StatsDisplay : IObserver<WeatherInfo>
    {
        private readonly WeatherData _observableIn;
        private readonly WeatherData _observableOut;

        private Stats _inStats;
        private Stats _outStats;

        public StatsDisplay(WeatherData observableIn, WeatherData observableOut)
        {
            _observableIn = observableIn;
            _observableOut = observableOut;
            _inStats = new Stats();
            _outStats = new Stats();
        }

        public void Update(WeatherInfo data, IObservable<WeatherInfo> observable)
        {
            if (observable.Equals(_observableIn))
            {
                _inStats.Update(data);
                _inStats.ToString();
            }
            else if (observable.Equals(_observableOut))
            {
                _outStats.Update(data);
                _outStats.ToString();
            }
        }
    }
}
