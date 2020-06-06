using System;

namespace Core.Entities
{
	public class CarReservation
	{
		public long Id { get; set; }
		public DateTime? From { get; set; }
		public DateTime? To { get; set; }
		public double Discount { get; set; }
		public DateTime? DateCreated { get; set; }

		public long ReservedCarId { get; set; }
		public Car ReservedCar { get; set; }

		public string OwnerEmail { get; set; }
		public User Owner { get; set; }

	}
}
