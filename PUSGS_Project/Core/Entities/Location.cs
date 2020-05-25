namespace Core.Entities
{
    public class Location
    {
        public long Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public string CityName { get; set; } = "";

        public Location()
        {
        }

        public Location(string cityName, double? x, double? y)
        {
            CityName = cityName;
            X = x ?? 44.786568;
            Y = y ?? 20.448921;
        }
    }
}