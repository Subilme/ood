namespace WeatherStationPro
{
    public abstract class Observable<T> : IObservable<T>
    {
        private List<ObserverContainer<T>> _observers = new();

        public void RegisterObserver(IObserver<T> observer, int priority)
        {
            var item = _observers.FirstOrDefault(x => x.Observer == observer);

            if (item != null)
            {
                item.Priority = priority;
            }
            else
            {
                _observers.Add(new ObserverContainer<T>(priority, observer));
            }

            _observers.Sort((x, y) => x.Priority.CompareTo(y.Priority));
        }

        public void NotifyObservers()
        {
            var copy = _observers.Take(_observers.Count).ToList();

            T data = GetChangedData();
            foreach (var observer in copy)
            {
                var temp = _observers.Find(item => item == observer);
                if (temp != null)
                {
                    temp.Observer.Update(data);
                }
            }
        }

        public void UnregisterObserver(IObserver<T> observer)
        {
            int index = _observers.FindIndex(x => x.Observer == observer);
            if (index != -1)
            {
                _observers.RemoveAt(index);
            }
        }

        protected abstract T GetChangedData();
    }
}
