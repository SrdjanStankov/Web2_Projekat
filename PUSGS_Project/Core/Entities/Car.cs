using System.Collections.Generic;

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

		public Car()
        {
            Ratings = new HashSet<Rating>();
        }
    }
}