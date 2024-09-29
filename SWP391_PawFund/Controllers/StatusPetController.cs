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

        // GET: api/StatusPet/pet/{petId}
        [HttpGet("pet/{petId}")]
        public ActionResult<IEnumerable<StatusResponseModel>> GetStatusesForPet(int petId)
        {
            var statuses = _statusPetService.GetStatusesForPet(petId);

            if (statuses == null || !statuses.Any())
            {
                return NotFound($"No statuses found for PetId {petId}.");
            }

            var response = statuses.Select(s => new StatusResponseModel
            {
                Id = s.Id,
                Name = s.Name,
                Date = s.Date,
                Disease = s.Disease,
                Vaccine = s.Vaccine,
                PetId = s.Pet?.Id ?? 0,
                PetName = s.Pet?.Name ?? string.Empty
            });

            return Ok(response);
        }

        // GET: api/StatusPet/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusDetailResponseModel>> GetStatusById(int id)
        {
            var status = await _statusPetService.GetStatusByIdAsync(id);
            if (status == null)
            {
                return NotFound($"Status with ID {id} not found.");
            }

            // Đảm bảo rằng Pet được nạp (Eager Loading)
            // Nếu chưa nạp Pet trong service, bạn cần cập nhật service để nạp Pet
            var pet = status.Pet;

            var response = new StatusDetailResponseModel
            {
                Id = status.Id,
                Name = status.Name,
                Date = status.Date,
                Disease = status.Disease,
                Vaccine = status.Vaccine,
                PetId = pet?.Id ?? 0,
                PetName = pet?.Name ?? string.Empty,
                Pet = pet != null ? new PetResponseModel
                {
                    Type = pet.Type,
                    Breed = pet.Breed,
                    Gender = pet.Gender,
                    Age = pet.Age,
                    Size = pet.Size,
                    Color = pet.Color,
                    AdoptionStatus = pet.AdoptionStatus,
                    Image = pet.Image,
                    ShelterID = pet.ShelterID,
                    UserID = pet.UserID
                } : null!
            };

            return Ok(response);
        }

        // POST: api/StatusPet
        [HttpPost]
        public async Task<IActionResult> CreateStatus([FromBody] StatusRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var status = new Status
            {
                Name = request.Name,
                Date = request.Date,
                Disease = request.Disease,
                Vaccine = request.Vaccine,
            };

            await _statusPetService.CreateStatusAsync(status);

            // Lấy lại Status vừa tạo với thông tin Pet đã được nạp
            var createdStatus = await _statusPetService.GetStatusByIdAsync(status.Id);
            if (createdStatus == null)
            {
                return StatusCode(500, "An error occurred while creating the status.");
            }

            var response = new StatusResponseModel
            {
                Id = createdStatus.Id,
                Name = createdStatus.Name,
                Date = createdStatus.Date,
                Disease = createdStatus.Disease,
                Vaccine = createdStatus.Vaccine,
                PetId = createdStatus.Pet?.Id ?? 0,
                PetName = createdStatus.Pet?.Name ?? string.Empty
            };

            return CreatedAtAction(nameof(GetStatusById), new { id = status.Id }, response);
        }

        // PUT: api/StatusPet/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] StatusRequestModel request)
        {
            if (id != request.PetId)
            {
                return BadRequest("Status ID mismatch.");
            }

            var existingStatus = await _statusPetService.GetStatusByIdAsync(id);
            if (existingStatus == null)
            {
                return NotFound($"Status with ID {id} not found.");
            }

            existingStatus.Name = request.Name;
            existingStatus.Date = request.Date;
            existingStatus.Disease = request.Disease;
            existingStatus.Vaccine = request.Vaccine;
            await _statusPetService.UpdateStatusAsync(existingStatus);

            return NoContent();
        }

        // DELETE: api/StatusPet/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            var status = await _statusPetService.GetStatusByIdAsync(id);
            if (status == null)
            {
                return NotFound($"Status with ID {id} not found.");
            }

            await _statusPetService.DeleteStatusAsync(id);
            return NoContent();
        }
    }
}
