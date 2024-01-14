namespace WeatherStationDuo
{
    public interface IObserver<T>
    {
        public void Update(T data, IObservable<T> observable);
    }
}
