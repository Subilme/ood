﻿namespace WeatherStationDuo
{
    public interface IObserver<T>
    {
        public void Update(T data);
    }
}
