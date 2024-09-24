using Microsoft.AspNetCore.Mvc;
using ModelLayer.Entities;
using ServiceLayer.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWP391_PawFund.Controllers
{
    [Route("api/StatusPet")]
    [ApiController]
    public class StatusPetController : ControllerBase
    {
        private readonly IStatusPetService _statusPetService;

        public StatusPetController(IStatusPetService statusPetService)
        {
            _statusPetService = statusPetService;
        }

        // GET: api/StatusPet/pet/{petId}
        [HttpGet("pet/{petId}")]
        public ActionResult<IEnumerable<Status>> GetStatusesForPet(int petId)
        {
            var statuses = _statusPetService.GetStatusesForPet(petId);
            return Ok(statuses);
        }

        // GET: api/StatusPet/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Status>> GetStatusById(int id)
        {
            var status = await _statusPetService.GetStatusByIdAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return Ok(status);
        }

        // POST: api/StatusPet
        [HttpPost]
        public async Task<IActionResult> CreateStatus([FromBody] Status status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _statusPetService.CreateStatusAsync(status);
            return CreatedAtAction(nameof(GetStatusById), new { id = status.Id }, status);
        }

        // PUT: api/StatusPet/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] Status status)
        {
            if (id != status.Id)
            {
                return BadRequest("Status ID mismatch");
            }

            var existingStatus = await _statusPetService.GetStatusByIdAsync(id);
            if (existingStatus == null)
            {
                return NotFound();
            }

            await _statusPetService.UpdateStatusAsync(status);
            return NoContent();
        }

        // DELETE: api/StatusPet/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            var status = await _statusPetService.GetStatusByIdAsync(id);
            if (status == null)
            {
                return NotFound();
            }

            await _statusPetService.DeleteStatusAsync(id);
            return NoContent();
        }
    }
}
