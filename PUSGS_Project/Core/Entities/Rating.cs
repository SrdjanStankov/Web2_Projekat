namespace Core.Entities
{
    public class Rating
    {
        public long Id { get; set; }
        public double Value { get; set; }
        public User RatingGiver { get; set; }
		public Car Car { get; set; }
		public Flight Flight { get; set; }
		public RentACar RentACar { get; set; }
		public AviationCompany AviationCompany { get; set; }
	}
}