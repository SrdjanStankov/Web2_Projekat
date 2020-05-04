namespace Core.Entities
{
    public class Rating
    {
        public long Id { get; set; }
        public User RatingGiver { get; set; }
        public double Value { get; set; }
    }
}