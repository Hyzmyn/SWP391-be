﻿using Microsoft.AspNetCore.Mvc;
using ModelLayer.Entities;
using ServiceLayer.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWP391_PawFund.Controllers
{

    [Route("api/Shelter")]
    [ApiController]
    public class ShelterController : ControllerBase
    {
        private readonly IShelterService _shelterService;
        private readonly ILogger<ShelterController> _logger;

        public ShelterController(IShelterService shelterService, ILogger<ShelterController> logger)
        {
            _shelterService = shelterService;
            _logger = logger;
        }

        // GET: api/Shelter
        [HttpGet]
        public ActionResult<IEnumerable<Shelter>> GetAllShelters()
        {
            var shelters = _shelterService.GetShelter();
            return Ok(shelters);
        }

        // GET: api/Shelter/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Shelter>> GetShelterById(int id)
        {
            var shelter = await _shelterService.GetShelterByID(id);
            if (shelter == null)
            {
                return NotFound(new { message = "Shelter not found." });
            }
            return Ok(shelter);
        }

        // POST: api/Shelter
        [HttpPost("Create_Shelter")]
        public async Task<IActionResult> CreateShelter([FromForm] Shelter shelter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _shelterService.CreateShelter(shelter);
            return CreatedAtAction(nameof(GetShelterById), new { id = shelter.Id }, shelter);
        }

        // PUT: api/Shelter/{id}
        [HttpPut("Update_Shelter/{id}")]
        public async Task<IActionResult> UpdateShelter(int id, [FromForm] Shelter shelter)
        {
            if (id != shelter.Id)
            {
                return BadRequest("Shelter ID mismatch");
            }

            var existingShelter = await _shelterService.GetShelterByID(id);
            if (existingShelter == null)
            {
                return NotFound(new { message = "Shelter not found." });
            }

            await _shelterService.UpdateShelter(shelter);
            return Ok(new { message = "Shelter have been Updated successfully." });
        }

        // DELETE: api/Shelter/{id}
        [HttpDelete("Remove_Shelter/{id}")]
        public async Task<IActionResult> DeleteShelter(int id)
        {
            var shelter = await _shelterService.GetShelterByID(id);
            if (shelter == null)
            {
                return NotFound(new { message = "Shelter not found." });
            }

            await _shelterService.DeleteShelter(id);
            return Ok(new { message = "Shelter have been Deleted successfully." });
        }
        // Endpoint mới: GET api/Shelter/ByStaff/{userId}
        [HttpGet("ByStaff/{userId}")]
        public async Task<IActionResult> GetShelterByStaffId(int userId)
        {
            try
            {
                var shelterDto = await _shelterService.GetShelterByUserIDAsync(userId);
                if (shelterDto == null)
                {
                    return BadRequest(new { message = "User is not a ShelterStaff or no shelter associated." });
                }
                return Ok(shelterDto);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "GetShelterByStaffId: {Message}", ex.Message);
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting shelter by staff ID.");
                return StatusCode(500, new { message = "An error occurred while processing your request." });
            }
        }
    }
}
