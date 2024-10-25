 using Microsoft.AspNetCore.Mvc;
using ModelLayer.Entities;
using ServiceLayer.Interfaces;
using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWP391_PawFund.Controllers
{
    [Route("api/Pet")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;
        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPets()
        {
            var pets = await _petService.GetAllPetsAsync();
            return Ok(pets);
        }

        [HttpGet("ID/{id}")]
        public async Task<IActionResult> GetPetById(int id)
        {
            var pet = await _petService.GetPetByIdAsync(id);
            return Ok(pet);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreatePet([FromForm] PetCreateRequestModel createPetRequest)
        {
            var createdPet = await _petService.CreatePetAsync(createPetRequest);
            return CreatedAtAction(nameof(GetPetById), new { id = createdPet.PetID }, createdPet);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdatePet(int id, [FromForm] PetUpdateRequestModel updatePetRequest)
        {
            var updatedPet = await _petService.UpdatePetAsync(id, updatePetRequest);
            return Ok(updatedPet);
        }

        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            await _petService.DeletePetAsync(id);
            return Ok(new { Message = "Pet deleted successfully." });
        }

        [HttpPost("{petId}/statuses")]
        public async Task<IActionResult> AddStatusToPet(int petId, [FromForm] CreatePetStatusRequest createPetStatusRequest)
        {
            await _petService.AddStatusToPetAsync(petId, createPetStatusRequest);
            return Ok(new { Message = "Status added to pet successfully." });
        }

        [HttpPut("{petId}/statuses/{statusId}")]
        public async Task<IActionResult> UpdatePetStatus(int petId, int statusId, [FromForm] StatusUpdateRequestModel updateStatusRequest)
        {
            await _petService.UpdatePetStatusAsync(petId, statusId, updateStatusRequest);
            return Ok(new { Message = "Pet status updated successfully." });
        }

        [HttpDelete("{petId}/statuses/{statusId}")]
        public async Task<IActionResult> RemoveStatusFromPet(int petId, int statusId)
        {
            await _petService.RemoveStatusFromPetAsync(petId, statusId);
            return Ok(new { Message = "Pet status removed successfully." });
        }

        [HttpPut("UpdateAdoptionStatus/{id}")]
        public async Task<IActionResult> UpdatePetAdoptionStatus(int id, [FromForm] UpdateAdoptionStatusRequest request)
        {
            try
            {
                await _petService.UpdatePetAdoptionStatusAsync(id, request.Status, request.UserId);
                return Ok(new { Message = "Pet adoption status updated successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPut("{petId}/user")]
        public async Task<IActionResult> PutUserID(int petId, [FromForm] int? userId)
        {
            try
            {
                var updatedPet = await _petService.PutUserIDAsync(petId, userId);
                return Ok(updatedPet);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
