using Core.Entities;
using System.Linq;

namespace Core.ViewModels.CarViewModels
{
	public class CarModel
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public int PassengerNumber { get; set; }
		public string Type { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }
		public double CostPerDay { get; set; }
		public int BuildDate { get; set; }
		public bool IsReserved { get; set; }
		public double AverageRating { get; set; }

		public CarModel(Car car)
		{
			Id = car.Id;
			Name = car.Name;
			PassengerNumber = car.PassengerNumber;
			Type = car.Type;
			Brand = car.Brand;
			Model = car.Model;
			CostPerDay = car.CostPerDay;
			BuildDate = car.BuildDate;
			IsReserved = car.IsReserved;
			AverageRating = car.Ratings.DefaultIfEmpty(new Entities.Rating()).Average(item => item.Value);
		}
	}
}
