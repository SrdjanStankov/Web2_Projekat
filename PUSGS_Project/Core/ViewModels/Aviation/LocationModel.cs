using Core.Entities;

namespace Core.ViewModels.Aviation
{
    public class LocationModel
    {
        public long Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public LocationModel()
        {
        }

        public LocationModel(Location location)
        {
            Id = location.Id;
            X = location.X;
            Y = location.Y;
        }
    }
}