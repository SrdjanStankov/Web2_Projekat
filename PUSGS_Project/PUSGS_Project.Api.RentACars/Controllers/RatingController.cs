﻿using System.Threading.Tasks;
using Core.Interfaces.Repositories;
using Core.ViewModels.Rating;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PUSGS_Project.Api.RentACars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ApiController
    {
        private readonly IRatingRepository ratingRepository;
        public RatingController(IUserRepository userRepository, IRatingRepository ratingRepository) : base(userRepository)
        {
            this.ratingRepository = ratingRepository;
        }

        // POST api/<RatingController>
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<object> Post([FromBody] RatingModel value)
        {
            var user = await GetLoginUserAsync();

            if (user is Core.Entities.User)
            {
                await ratingRepository.AddAsync(value);
                return Ok();
            }
            else
            {
                return Forbid();
            }
        }
    }
}
