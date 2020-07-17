namespace LoggingKata
{
    public struct Point
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public Point(double _Longi, double _Latti)
        {
            Longitude = _Longi;
            Latitude = _Latti;
        }

    }
}