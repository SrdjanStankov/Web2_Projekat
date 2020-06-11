using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class User
    {
        public string City { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool IsVerified { get; set; }
        public bool IsSystemAdmin { get; set; }
        public bool IsRentACarAdmin { get; set; }

        public double Points { get; set; }

        public bool RequirePasswordChange { get; set; }

        [NotMapped]
        public ICollection<User> Friends { get; set; }

        public ICollection<FlightTicket> Tickets { get; set; }

        public User()
        {
            Friends = new HashSet<User>();
            Tickets = new HashSet<FlightTicket>();
        }
    }
}