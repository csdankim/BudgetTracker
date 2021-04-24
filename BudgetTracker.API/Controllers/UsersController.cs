using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Repositories;

namespace BudgetTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("allusers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();

            if (!users.Any())
            {
                return NotFound("We did not find any user");
            }

            return Ok(users);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetUser")]
        public async Task<IActionResult> GetUserDetails(int id)
        {
            var user = await _userService.GetUserDetails(id);
            if (user == null)
            {
                return NotFound("We did not find any user");
            }
            return Ok(user);
        }

        [HttpPost]
        [Route("createuser")]
        public async Task<IActionResult> CreateUser(UserRequestModel model)
        {
            var user = await _userService.CreateUser(model);
            return Ok(user);
        }

        [HttpPut]
        [Route("updateuser")]
        public async Task<IActionResult> UpdateUser(UserUpdateRequestModel model)
        {
            var updatedUser = await _userService.UpdateUser(model);
            return Ok(updatedUser);
        }

        [HttpDelete]
        [Route("{id:int}", Name = "DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.DeleteUser(id);
            return Ok(user);
        }
    }
}
