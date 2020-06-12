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

        public double AverageRating { get; set; }

        public AviationCompanyModel()
        {
        }

        public AviationCompanyModel(AviationCompany aviation)
        {
            if (aviation == null)
                return;

            Id = aviation.Id;
            Name = aviation.Name;
            Description = aviation.Description;
            Address = new LocationModel(aviation.Address);
            Flights = aviation.Flights.Select(f => new FlightModel(f)).ToList();

            AverageRating = Flights.Where(f => f.AverageRating > 0).Select(f => f.AverageRating).DefaultIfEmpty().Average();
        }
    }
}