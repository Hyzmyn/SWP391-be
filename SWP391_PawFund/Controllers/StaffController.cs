using Microsoft.AspNetCore.Mvc;
using ModelLayer.Entities;
using ServiceLayer.Interfaces;
using ServiceLayer.ResponseModels;
using ServiceLayer.Services;

namespace SWP391_PawFund.Controllers
{
    [Route("api/Staff")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IShelterStaffService _shelterStaffService;
        public StaffController(IShelterStaffService shelterStaffService)
        {
            _shelterStaffService = shelterStaffService;
        }

        [HttpGet("Staff/{ShelterId}/Staffs")]
        public ActionResult<IEnumerable<ShelterStaffResponseModel>> GetStaff(int ShelterId)
        {
            if (ShelterId <= 0)
            {
                return BadRequest("Invalid Shelter ID");
            }


            var staff = _shelterStaffService.GetStaffsOfSheler(ShelterId);

            if (staff == null || !staff.Any())
            {
                return NotFound($"No staffs found for ShelterId {ShelterId}.");
            }

            var response = staff.Select(s => new ShelterStaffResponseModel
            {
                ShelterId = ShelterId,
                Staffs = staff.ToList()
            });

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddStaff([FromBody] ShelterStaff staff)
        {
            // Validate the incoming ShelterStaff object
            if (staff == null)
            {
                return BadRequest("Staff cannot be null.");
            }

            if (staff.UserId <= 0 || staff.ShelterId <= 0)
            {
                return BadRequest("Invalid UserId or ShelterId.");
            }

            try
            {
                await _shelterStaffService.AddStaffAsync(staff);
                return Ok("Staff successfully added.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the staff: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveStaff(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid staff ID.");
            }
            try
            {
                await _shelterStaffService.RemoveStaffAsync(id);
                return Ok($"Staff with ID {id} successfully removed.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
