using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public class AviationCompany
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Location Address { get; set; }
        public string Description { get; set; }
        public ICollection<Flight> Flights { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public AviationCompany()
        {
            Flights = new HashSet<Flight>();
            Ratings = new HashSet<Rating>();
        }
    }
}