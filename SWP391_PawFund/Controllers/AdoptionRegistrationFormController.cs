using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ModelLayer.Entities;
using ServiceLayer.Interfaces;
using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWP391_PawFund.Controllers
{
    [Route("api/AdoptionRegistrationForm")]
    [ApiController]
    public class AdoptionRegistrationFormController : ControllerBase
    {
        private readonly IAdoptionRegistrationFormService _adoptionFormService;
        private readonly IShelterService _shelterService;
        private readonly IUsersService _usersService;
        private readonly IPetService _petService;
        private readonly IAuthServices _authServices;
        private readonly IFileUploadService _fileUploadService;

        public AdoptionRegistrationFormController(
            IAdoptionRegistrationFormService adoptionFormService, 
            IUsersService usersService, 
            IShelterService shelterService, 
            IPetService petService, 
            IAuthServices authServices, 
            IFileUploadService fileUploadService)
        {
            _adoptionFormService = adoptionFormService;
            _usersService = usersService;
            _shelterService = shelterService;
            _petService = petService;
            _authServices = authServices;
            _fileUploadService = fileUploadService;
        }

        // GET: api/AdoptionRegistrationForm
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<AdoptionRegistrationFormResponse>> GetAllForms()
        {
            var forms = _adoptionFormService.GetAllAdoptionForms();
            var response = forms.Select(form => new AdoptionRegistrationFormResponse
            {
                Id = form.Id,
                SocialAccount = form.SocialAccount,
                IncomeAmount = form.IncomeAmount,
                IdentificationImage = form.IdentificationImage,
                IdentificationImageBackSide = form.IdentificationImageBackSide,
                AdopterId = form.AdopterId,
                ShelterStaffId = form.ShelterStaffId,
                PetId = form.PetId
            }).ToList();

            return Ok(response);
        }

        // GET: api/AdoptionRegistrationForm/{id}/detail
        [HttpGet("{id}/detail")]
        [Authorize]
        public async Task<ActionResult<AdoptionRegistrationFormDetailResponse>> GetFormDetailById(int id)
        {
            var form = await _adoptionFormService.GetAdoptionFormByIdAsync(id);
            if (form == null)
            {
                return NotFound(new { message = "Form not found." });
            }

            var adopter = await _usersService.GetUserByIdAsync(form.AdopterId);
            var pet = await _petService.GetPetById(form.PetId);
            var shelterStaff = await _usersService.GetUserByIdAsync(form.ShelterStaffId);
            var shelter = await _shelterService.GetShelterByID(pet.ShelterID);

            var response = new AdoptionRegistrationFormDetailResponse
            {
                Id = form.Id,
                SocialAccount = form.SocialAccount,
                IncomeAmount = form.IncomeAmount,
                IdentificationImage = form.IdentificationImage, 
                IdentificationImageBackSide = form.IdentificationImageBackSide,
                Status = form.Status,
                Adopter = adopter != null ? new UsersResponseModel
                {
                    Id = adopter.Id,
                    Username = adopter.Username,
                    Email = adopter.Email,
                    Phone = adopter.Phone,
                    Location = adopter.Location,
                    TotalDonation = (decimal)adopter.TotalDonation
                } : null,
                Pet = pet != null ? new PetDetailResponse
                {
                    Id = pet.Id,
                    Name = pet.Name,
                    Type = pet.Type,
                    Breed = pet.Breed,
                    Gender = pet.Gender,
                    Age = (int)pet.Age,
                    Size = pet.Size,
                    Color = pet.Color,
                    Description = pet.Description,
                    AdoptionStatus = pet.AdoptionStatus,
                    Image = pet.Image,
                    ShelterName = shelter?.Name, 
                    UserName = adopter?.Username
                } : null,
                ShelterStaff = shelterStaff != null ? new UsersResponseModel
                {
                    Id = shelterStaff.Id,
                    Username = shelterStaff.Username,
                    Email = shelterStaff.Email,
                    Phone = shelterStaff.Phone,
                    Location = shelterStaff.Location
                } : null
            };

            return Ok(response);
        }

        // POST: api/AdoptionRegistrationForm
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateForm([FromForm] AdoptionRegistrationFormRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Upload images to Firebase and get URLs
            var identificationImageUrl = await _fileUploadService.UploadFileAsync(request.IdentificationImage);
            var identificationImageBackSideUrl = await _fileUploadService.UploadFileAsync(request.IdentificationImageBackSide);

            var form = new AdoptionRegistrationForm
            {
                SocialAccount = request.SocialAccount,
                IncomeAmount = request.IncomeAmount,
                IdentificationImage = identificationImageUrl, // Store the image URLs
                IdentificationImageBackSide = identificationImageBackSideUrl,
                AdopterId = request.AdopterId,
                ShelterStaffId = request.ShelterStaffId,
                PetId = request.PetId
            };

            await _adoptionFormService.CreateAdoptionFormAsync(form);
            return CreatedAtAction(nameof(GetFormDetailById), new { id = form.Id }, form);
        }

        // PUT: api/AdoptionRegistrationForm/{id}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateForm(int id, [FromBody] AdoptionRegistrationFormRequest request)
        {
            if (id != request.AdopterId)
            {
                return BadRequest("Form ID mismatch");
            }

            var existingForm = await _adoptionFormService.GetAdoptionFormByIdAsync(id);
            if (existingForm == null)
            {
                return NotFound(new { message = "Form not found." });
            }

            var identificationImageUrl = await _fileUploadService.UploadFileAsync(request.IdentificationImage);
            var identificationImageBackSideUrl = await _fileUploadService.UploadFileAsync(request.IdentificationImageBackSide);

            existingForm.SocialAccount = request.SocialAccount;
            existingForm.IncomeAmount = request.IncomeAmount;
            existingForm.IdentificationImage = identificationImageUrl;
            existingForm.IdentificationImageBackSide = identificationImageBackSideUrl;
            existingForm.AdopterId = request.AdopterId;
            existingForm.ShelterStaffId = request.ShelterStaffId;
            existingForm.PetId = request.PetId;

            await _adoptionFormService.UpdateAdoptionFormAsync(existingForm);
            return Ok(new { message = "Form has been updated successfully." });
        }

        // DELETE: api/AdoptionRegistrationForm/{id}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteForm(int id)
        {
            var form = await _adoptionFormService.GetAdoptionFormByIdAsync(id);
            if (form == null)
            {
                return NotFound(new { message = "Form not found." });
            }

            await _adoptionFormService.DeleteAdoptionFormAsync(id);
            return Ok(new { message = "Form has been deleted successfully." });
        }
    }

}
