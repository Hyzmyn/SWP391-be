﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Entities;
using RepositoryLayer.Models;
using RepositoryLayer.Utils;
using ServiceLayer.Interfaces;
using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;
using ServiceLayer.Services;
using Twilio.Http;

namespace SWP391_PawFund.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _userService;
        private readonly IAuthServices _authService;
        private readonly IUserRoleService _userRoleService;
        private readonly IFileUploadService _fileUploadService;

        public UsersController(IUsersService userService, IAuthServices authServices, IUserRoleService userRoleService, IFileUploadService fileUploadService)
        {
            _userService = userService;
            _authService = authServices;
            _userRoleService = userRoleService;
            _fileUploadService = fileUploadService;
        }

        // GET: api/Users
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<DetailUserViewModel>>> GetUsers()
        {
            try
            {
                var users = await _userService.GetUsersAsync();  // Get users asynchronously

                var userViewModels = new List<DetailUserViewModel>();

                foreach (var user in users)
                {
                    // Fetch roles for each user
                    var roles = await _userRoleService.GetRolesOfUserAsync(user.Id);

                    // Create a UserViewModel with roles
                    var userViewModel = new DetailUserViewModel
                    {
                        Id = user.Id,
                        Username = user.Username,
                        Email = user.Email,
                        Password = user.Password,
                        Phone = user.Phone,
                        Location = user.Location,
                        Token = user.Token,
                        TotalDonation = user.TotalDonation,
                        Image = user.Image,
                        Roles = roles.ToList()
                    };

                    userViewModels.Add(userViewModel);
                }

                return Ok(userViewModels);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        // GET: api/Users/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
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
        public async Task<IActionResult> UserUpdate(int id, [FromForm] UserUpdateRequestModel userModel)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound(new { message = "User ID not found." });
                }

                // Update only if the value is provided (non-null or default)
                if (userModel.Image != null && userModel.Image.Length > 0)
                {
                    string userImage = await _fileUploadService.UploadFileAsync(userModel.Image);
                    user.Image = userImage;
                }
                if (!string.IsNullOrWhiteSpace(userModel.Location))
                {
                    user.Location = userModel.Location;
                }
                if (!string.IsNullOrWhiteSpace(userModel.Phone))
                {
                    user.Phone = userModel.Phone;
                }
                if (!string.IsNullOrWhiteSpace(userModel.Username))
                {
                    user.Username = userModel.Username;
                }

                // Update ShelterId if it's not 0 (assuming 0 is a default value)
                if (userModel.ShelterId != 0)
                {
                    user.ShelterId = userModel.ShelterId;
                }

                // For Status, since it's a bool, we assume it's always provided. If you want it to be optional, change it to `bool?` in the model.
                user.Status = userModel.Status;

                // Update roles if provided
                if (userModel.RoleIds != null && userModel.RoleIds.Any())
                {
                    await _userRoleService.UpdateRolesAsync(id, userModel.RoleIds);
                }

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
        public async Task<ActionResult<User>> CreateUser([FromForm] UserCreateRequestModel userModel)
        {
            string userImage = null;

            if (userModel.Image != null) 
            {
                userImage = await _fileUploadService.UploadFileAsync(userModel.Image);
            }

            var user = new User
            {
                Username = userModel.Username,
                Password = userModel.Password,
                Email = userModel.Email,
                Image = userImage,
                Location = userModel.Location,
                Phone = userModel.Phone,
                ShelterId = userModel.ShelterId,
                Status = userModel.Status
            };

            // Save the user
            await _userService.CreateUserAsync(user);

            // Add roles to the user
            if (userModel.RoleIds.Any())
            {
                foreach (var roleId in userModel.RoleIds)
                {
                    var userRole = new UserRole
                    {
                        UserId = user.Id,
                        RoleId = roleId
                    };
                    await _userRoleService.AddRoleAsync(userRole);
                }
            }

            return Ok(new { message = "User created successfully." });
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
    }
}
