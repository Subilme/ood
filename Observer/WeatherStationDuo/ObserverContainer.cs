namespace WeatherStationDuo
{
    internal class ObserverContainer<T>
    {
        public int Priority { get; set; }
        public IObserver<T> Observer { get; set; }

        public ObserverContainer(int priority, IObserver<T> observer)
        {
            Priority = priority;
            Observer = observer;
        }
    }
}
