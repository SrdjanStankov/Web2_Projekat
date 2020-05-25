namespace Core.Entities
{
    public class Location
    {
        public long Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public string CityName { get; set; } = "";
    }
}