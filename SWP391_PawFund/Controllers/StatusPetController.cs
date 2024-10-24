using Microsoft.AspNetCore.Mvc;
using ModelLayer.Entities;
using ServiceLayer.Interfaces;
using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;

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

        [HttpGet]
        public async Task<IActionResult> GetAllStatus()
        {
            var statuses = await _statusPetService.GetAllStatusAsync();
            return Ok(statuses);
        }
        // GET: api/Status/pet/5
        [HttpGet("pet/{petId}")]
        public async Task<IActionResult> GetStatusesForPet(int petId)
        {
            var statuses = await _statusPetService.GetStatusesForPetAsync(petId);
            return Ok(statuses);
        }

        // GET: api/Status/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStatusById(int id)
        {
            var status = await _statusPetService.GetStatusByIdAsync(id);
            return Ok(status);
        }

        // POST: api/Status
        [HttpPost]
        public async Task<IActionResult> CreateStatus([FromForm] StatusCreateRequest createStatusRequest)
        {
            var createdStatus = await _statusPetService.CreateStatusAsync(createStatusRequest);
            return CreatedAtAction(nameof(GetStatusById), new { id = createdStatus.StatusId }, createdStatus);
        }

        // PUT: api/Status/3
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] StatusUpdateRequestModel updateStatusRequest)
        {
            var updatedStatus = await _statusPetService.UpdateStatusAsync(id, updateStatusRequest);
            return Ok(updatedStatus);
        }

        // DELETE: api/Status/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            await _statusPetService.DeleteStatusAsync(id);
            return NoContent();
        }
    }
}
