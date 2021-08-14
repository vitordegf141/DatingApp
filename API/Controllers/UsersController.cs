using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await this._userRepository.GetMembersAsync();
            return Ok(users);
        }

        // api/users/3
        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            //var user = await this._userRepository.GetUserByUserNameAsync(username);
            //await SetMeAsAUser(username, user);

            string dd;
            DateTime time;
            return await this._userRepository.GetMemberAsync(username);

            
        }
        async Task SetMeAsAUser(string username, AppUser user)
            {
                if (username == "vitor")
                {
                    var newphoto = new Photo();
                    newphoto.IsMain = true;
                    newphoto.Url = "https://scontent.fpoa22-1.fna.fbcdn.net/v/t1.6435-9/84986649_2780920798682435_132247132580085760_n.jpg?_nc_cat=101&ccb=1-5&_nc_sid=09cbfe&_nc_eui2=AeFf7Jmz0AUjIqRi5dOYfkcq5dac6nngFBjl1pzqeeAUGLYKs13OIpdRQI-DLld0TEHGc5QuhkUJ0qsFsJ1BLDQq&_nc_ohc=3CjL0nG0C40AX9omA0Q&tn=jySHH2lqv3GOYqUf&_nc_ht=scontent.fpoa22-1.fna&oh=6081352e07ecaa0c923185f1567b8ee7&oe=613F6A7E";
                    newphoto.AppUser = user;
                    newphoto.AppUserId = user.Id;
                    user.Photos = new List<Photo> { newphoto };
                    user.Gender = "male";
                    user.City = "Gravataí";
                    user.Country = "Brazil";
                    user.KnownAs = "Vitor";
                    this._userRepository.Update(user);
                    await this._userRepository.SaveAllAsync();
                }
            }
    }
    
}

//https://scontent.fpoa22-1.fna.fbcdn.net/v/t1.6435-9/84986649_2780920798682435_132247132580085760_n.jpg?_nc_cat=101&ccb=1-5&_nc_sid=09cbfe&_nc_eui2=AeFf7Jmz0AUjIqRi5dOYfkcq5dac6nngFBjl1pzqeeAUGLYKs13OIpdRQI-DLld0TEHGc5QuhkUJ0qsFsJ1BLDQq&_nc_ohc=3CjL0nG0C40AX9omA0Q&tn=jySHH2lqv3GOYqUf&_nc_ht=scontent.fpoa22-1.fna&oh=6081352e07ecaa0c923185f1567b8ee7&oe=613F6A7E