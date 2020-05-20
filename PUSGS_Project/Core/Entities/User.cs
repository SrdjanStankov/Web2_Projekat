using System.Collections.Generic;

namespace Core.Entities
{
    public class User
    {
        public string City { get; set; }
        public string Email { get; set; }
        public ICollection<User> Friends { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool IsSystemAdmin { get; set; }
        public bool IsRentACarAdmin { get; set; }

        public User()
        {
            Friends = new HashSet<User>();
        }
    }
}