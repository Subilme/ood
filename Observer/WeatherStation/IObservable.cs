namespace WeatherStation
{
    public interface IObservable<T>
    {
        public void RegisterObserver(IObserver<T> observer, int priority);
        public void NotifyObservers();
        public void UnregisterObserver(IObserver<T> observer);
    }
}
