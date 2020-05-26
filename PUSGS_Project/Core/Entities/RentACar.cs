using System.Collections.Generic;

namespace Core.Entities
{
    public class RentACar
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public ICollection<Car> Cars { get; set; }
        public ICollection<Branch> Branches { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public RentACar()
        {
            Cars = new HashSet<Car>();
            Branches = new HashSet<Branch>();
            Ratings = new HashSet<Rating>();
        }
    }
}