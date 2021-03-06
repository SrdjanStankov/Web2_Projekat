﻿using Core.Entities;

namespace Core.ViewModels.Aviation
{
    public class LocationModel
    {
        public long Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public string CityName { get; set; }

        public LocationModel()
        {
        }

        public LocationModel(Location location)
        {
            if (location == null)
                return;

            Id = location.Id;
            X = location.X;
            Y = location.Y;
            CityName = location.CityName;
        }

        public Location ToLocation()
        {
            return new Location { Id = Id, X = X, Y = Y, CityName = CityName };
        }
    }
}