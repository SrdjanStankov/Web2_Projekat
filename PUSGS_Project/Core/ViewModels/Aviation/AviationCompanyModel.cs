using Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Core.ViewModels.Aviation
{
    public class AviationCompanyModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public LocationModel Address { get; set; }

        public ICollection<FlightModel> Flights { get; set; }
        public ICollection<RatingModel> Ratings { get; set; }

        public AviationCompanyModel()
        {
        }

        public AviationCompanyModel(AviationCompany aviation)
        {
            Id = aviation.Id;
            Name = aviation.Name;
            Description = aviation.Description;
            Address = new LocationModel(aviation.Address);
            Flights = aviation.Flights.Select(f => new FlightModel(f)).ToList();
            Ratings = aviation.Ratings.Select(r => new RatingModel(r)).ToList();
        }
    }
}