using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public class Car
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int PassengerNumber { get; set; }

        [NotMapped]
        public ICollection<double> Ratings { get; set; }

        public DateTime? ReservedFrom { get; set; }

        public DateTime? ReservedTo { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double CostPerDay { get; set; }

        public Car()
        {
            Ratings = new List<double>();
        }

        // TODO: BuildDate?
    }
}