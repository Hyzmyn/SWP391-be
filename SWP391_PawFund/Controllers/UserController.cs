using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Entities;
using RepositoryLayer.Models;
using RepositoryLayer.Utils;
using ServiceLayer.Interfaces;
using ServiceLayer.RequestModels;

namespace SWP391_PawFund.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _userService;
        private readonly IAuthServices _authService;

        public UsersController(IUsersService userService, IAuthServices authServices)
        {
            _userService = userService;
            _authService = authServices;

        }

        // GET: api/Users
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<UserViewModel>> GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }


        // GET: api/Users/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("GetUserProfile/{id}")]
        [Authorize]
        public async Task<ActionResult<User>> GetUserProfile(int id)
        {
            try
            {
                var user = await _userService.GetUserProfile(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutUser(int id, UserUpdateRequestModel userModel)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound(new { message = "User ID not found." });
                }

                user.Location = userModel.Location;
                user.Phone = userModel.Phone;
                user.Username = userModel.Username;

                await _userService.UpdateUserAsync(user);

                return Ok(new { message = "User updated successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdatePassword")]
        [Authorize]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordRequestModel request)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(request.UserId);
                if (user == null)
                {
                    return NotFound(new { message = "User ID not found." });
                }
                if (PasswordTools.VerifyPassword(request.OldPassword, user.Password) == false)
                {
                    return BadRequest(new { message = "Password is uncorrect." });
                }

                string hashedPass = PasswordTools.HashPassword(request.NewPassword);

                user.Password = hashedPass;

                await _userService.UpdateUserAsync(user);

                return Ok(new { message = "User Password updated successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST: api/Users
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<User>> PostUser(UserCreateRequestModel userModel)
        {
            // Map properties from userModel to create a new user entity
            var user = new User
            {
                //Field = userModel.Field,
                Username = userModel.Username,
                Password = userModel.Password,
                Email = userModel.Email,
                Location = userModel.Location,
                Phone = userModel.Phone,
                Status = userModel.Status
            };

            await _userService.CreateUserAsync(user);
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userService.DeleteUserAsync(id);
            return NoContent();
        }


        private async Task<bool> UserExists(int id)
        {
            return await _userService.UserExistsAsync(id);
        }
    }
}
