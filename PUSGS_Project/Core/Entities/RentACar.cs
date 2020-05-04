using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public class RentACar
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public ICollection<Car> Cars { get; set; }

        [NotMapped]
        public ICollection<string> Branches { get; set; }

        [NotMapped]
        public ICollection<double> Ratings { get; set; }

        public RentACar()
        {
            Cars = new HashSet<Car>();
            Branches = new HashSet<string>();
            Ratings = new List<double>();
        }
    }
}