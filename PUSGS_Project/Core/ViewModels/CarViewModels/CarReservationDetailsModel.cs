using System;
using System.Collections.Generic;
using Core.Entities;

namespace Core.ViewModels.CarViewModels
{
    public class CarReservationDetailsModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int PassengerNumber { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public DateTime? ReservedFrom { get; set; }
        public DateTime? ReservedTo { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double CostPerDay { get; set; }
        public int BuildDate { get; set; }
        public double AverageRating { get; set; }
        public double CostForRange { get; set; }

        public CarReservationDetailsModel()
        {
            Ratings = new HashSet<Rating>();
        }

        public CarReservationDetailsModel(Car car)
        {
            Id = car.Id;
            Name = car.Name;
            PassengerNumber = car.PassengerNumber;
            Ratings = new HashSet<Rating>(car.Ratings);
            ReservedFrom = car.ReservedFrom;
            ReservedTo = car.ReservedTo;
            Type = car.Type;
            Brand = car.Brand;
            Model = car.Model;
            CostPerDay = car.CostPerDay;
            BuildDate = car.BuildDate;
        }
    }
}
