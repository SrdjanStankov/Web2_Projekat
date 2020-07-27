namespace Core.Entities
{
    public class Rating
    {
        public long Id { get; set; }
        public double Value { get; set; }
        public string RatingGiverEmail { get; set; }
		public long? CarId { get; set; }
		public long? FlightId { get; set; }
		public long? RentACarId { get; set; }
		public long? AviationCompanyId { get; set; }
	}
}