using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModels.Rating
{
	public class RatingModel
	{
		public long Id { get; set; }
		public double Value { get; set; }
		public string UserId { get; set; }
		public long CarId { get; set; }
	}
}
