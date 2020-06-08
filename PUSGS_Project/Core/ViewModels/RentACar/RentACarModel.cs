using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using Core.ViewModels.CarViewModels;

namespace Core.ViewModels.RentACar
{
    public class RentACarModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public ICollection<CarModel> Cars { get; set; }
        public ICollection<Branch> Branches { get; set; }

        public double? AverageRating { get; set; }

        public RentACarModel(Entities.RentACar rentACar)
        {
            Id = rentACar.Id;
            Name = rentACar.Name;
            Address = rentACar.Address;
            Description = rentACar.Description;
            Cars = new HashSet<CarModel>(rentACar.Cars.Select(item => new CarModel(item)));
            Branches = new HashSet<Branch>(rentACar.Branches);
        }
    }
}
