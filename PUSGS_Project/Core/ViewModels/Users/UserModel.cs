using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.ViewModels.Users
{
    public class UserModel
    {
        public string City { get; set; }
        public string Email { get; set; }

        /**
         * List of userId's - this is to avoid infinite recursion error when mapping object returned by User.Include(u=>Friends) to JSON         */
        public ICollection<string> Friends { get; set; } = new HashSet<string>();

        public string LastName { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        // Note: Password is ommited - should not be viewed by front end in Get response

        public UserModel()
        {
        }

        public UserModel(User user)
        {
            City = user.City;
            Email = user.Email;
            LastName = user.LastName;
            Name = user.Name;
            Phone = user.Phone;

            Friends = user.Friends.Select(f => f.Email).ToHashSet();
        }
    }
}