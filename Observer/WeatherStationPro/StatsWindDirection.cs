namespace WeatherStationPro
{
    public class StatsWindDirection
    {
        private double _sinSum = 0;
        private double _cosSum = 0;
        private double _avg = 0;

        public void Update(double data)
        {
            _sinSum += Math.Sin(ParsToRad(data));
            _cosSum += Math.Cos(ParsToRad(data));

            var x = ParseToDegrees(Math.Atan2(_sinSum, _cosSum)) + 360;
            _avg = x % 360;
        }

        public override string ToString()
        {
            return $"Avg direction: {_avg}";
        }

        private double ParsToRad(double degrees)
        {
            return Math.PI * degrees / 180;
        }

        private double ParseToDegrees(double rad)
        {
            return 180 * rad / Math.PI;
        }
    }
}
