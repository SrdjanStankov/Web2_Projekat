using Core.Entities;

namespace Core.ViewModels.Aviation
{
    public class RatingModel
    {
        public long Id { get; set; }
        public string RatingGiverId { get; set; }
        public double Value { get; set; } = 0;

        public RatingModel()
        {
        }

        public RatingModel(Entities.Rating rating)
        {
            if (rating == null)
                return;

            Id = rating.Id;
            Value = rating.Value;
            RatingGiverId = rating.RatingGiver?.Email;
        }
    }
}