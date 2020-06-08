using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Core.Entities
{
	public class Car
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
        public ICollection<Rating> Ratings { get; set; }
        [NotMapped]
		public double AverageRating { get => Ratings.DefaultIfEmpty(new Rating()).Average(item => item.Value); }

		public Car()
        {
            Ratings = new HashSet<Rating>();
        }
    }
}