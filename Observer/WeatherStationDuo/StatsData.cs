namespace WeatherStationDuo
{
    public class StatsData
    {
        private double _min = double.MaxValue;
        private double _max = double.MinValue;
        private double _sum = 0;
        private int _count = 0;

        public void Update(double data)
        {
            if (_min > data)
            {
                _min = data;
            }
            if (_max < data)
            {
                _max = data;
            }

            _sum += data;
            _count++;
        }

        public override string ToString()
        {
            return $"Max {_max}, Min {_min}, Average {_sum / _count}";
        }
    }
}
