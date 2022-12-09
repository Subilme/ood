using System.Runtime.CompilerServices;

namespace WeatherStation
{
    public abstract class Observable<T> : IObservable<T>
    {
        private List<ObserverContainer<T>> _observers = new();

        public void RegisterObserver(IObserver<T> observer, int priority)
        {
            _observers.Add(new ObserverContainer<T>(priority, observer));
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
            var item = _observers.Find(x => x.Observer == observer);
            if (item != null)
            {
                _observers.Remove(item);
            }
        }

        protected abstract T GetChangedData();
    }
}
