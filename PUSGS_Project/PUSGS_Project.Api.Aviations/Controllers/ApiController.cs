using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Enumerations;
using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace PUSGS_Project.Api.Aviations.Controllers
{
    public class ApiController : Controller
    {
        protected readonly IUserRepository userRepository;

        public ApiController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Gets user from database based on JWT token that is sent via request
        /// </summary>
        /// <returns>
        /// User from database or null if not exist 
        /// </returns>
        public async Task<User> GetLoginUserAsync()
        {
            User user = null;
            var userEmail = User.Claims.FirstOrDefault(item => item.Type == AppConsts.CLAIM_TOKEN_KEY)?.Value;
            if (!string.IsNullOrEmpty(userEmail) || !string.IsNullOrWhiteSpace(userEmail))
            {
                user = await userRepository.GetUserByEmailAsync(userEmail);
            }

            return user;
        }
    }
}
