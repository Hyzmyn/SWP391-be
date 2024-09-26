using Microsoft.AspNetCore.Mvc;
using ModelLayer.Entities;
using ServiceLayer.Interfaces;

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

        // GET: api/Pet
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> GetAllPets()
        {
            var pets = _petService.GetPets();
            return Ok(pets);
        }

        // GET: api/Pet/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetPetById(int id)
        {
            var pet = await _petService.GetPetById(id);
            if (pet == null)
            {
                return NotFound();
            }
            return Ok(pet);
        }

        // POST: api/Pet
        [HttpPost]
        public async Task<IActionResult> CreatePet([FromBody] Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _petService.CreatePetAsync(pet);
            return CreatedAtAction(nameof(GetPetById), new { id = pet.Id }, pet);
        }

        // PUT: api/Pet/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePet(int id, [FromBody] Pet pet)
        {
            if (id != pet.Id)
            {
                return BadRequest("Pet ID mismatch");
            }

            var existingPet = await _petService.GetPetById(id);
            if (existingPet == null)
            {
                return NotFound();
            }

            await _petService.UpdatePetAsync(pet);
            return NoContent();
        }

        // DELETE: api/Pet/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            var pet = await _petService.GetPetById(id);
            if (pet == null)
            {
                return NotFound();
            }

            await _petService.DeletePetAsync(id);
            return NoContent();
        }

        // PATCH: api/Pet/{id}/status
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdatePetStatus(int id, [FromQuery] int newStatus)
        {
            var pet = await _petService.GetPetById(id);
            if (pet == null)
            {
                return NotFound();
            }

            await _petService.UpdatePetStatus(pet, newStatus);
            return NoContent();
        }
    }
}
