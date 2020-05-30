using System.Collections.Generic;
using Core.Entities;

namespace Core.ViewModels.RentACar
{
    public class RentACarModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public ICollection<Car> Cars { get; set; }
        public ICollection<Branch> Branches { get; set; }

        public double? AverageRating { get; set; }

        public RentACarModel()
        {
            Cars = new HashSet<Car>();
            Branches = new HashSet<Branch>();
        }

        public RentACarModel(Entities.RentACar rentACar)
        {
            Id = rentACar.Id;
            Name = rentACar.Name;
            Address = rentACar.Address;
            Description = rentACar.Description;
            Cars = new HashSet<Car>(rentACar.Cars);
            Branches = new HashSet<Branch>(rentACar.Branches);
        }
    }
}
