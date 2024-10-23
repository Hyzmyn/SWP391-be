using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Logging;
using ModelLayer.Entities;
using ServiceLayer.Interfaces;
using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWP391_PawFund.Controllers
{
    [Route("api/Form")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IAdoptionRegistrationFormService _adoptionFormService;
        //private readonly IShelterService _shelterService;
        //private readonly IUsersService _usersService;
        private readonly IPetService _petService;
        private readonly IAuthServices _authServices;
        private readonly IFileUploadService _fileUploadService;
        private readonly ILogger<FormController> _logger;

        public FormController(
            IAdoptionRegistrationFormService adoptionFormService,
            IUsersService usersService,
            IShelterService shelterService,
            IPetService petService,
            IAuthServices authServices,
            IFileUploadService fileUploadService,
            ILogger<FormController> logger)
        {
            _adoptionFormService = adoptionFormService;
            //_usersService = usersService;
            //_shelterService = shelterService;
            _petService = petService;
            _authServices = authServices;
            _fileUploadService = fileUploadService;
            _logger = logger;
        }


        // GET: api/AdoptionRegistrationForm
        [HttpGet]

        public ActionResult<IEnumerable<AdoptionRegistrationFormResponse>> GetAllForms()
        {
            try
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
                    PetId = form.PetId,
                    Status = form.Status,
                    Shelter = form.Pet != null && form.Pet.Shelter != null ? form.Pet.Shelter.Name : "N/A"
                }).ToList();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<AdoptionRegistrationFormResponse>> GetFormDetailById(int id)
        {
            try
            {
                var form = await _adoptionFormService.GetAdoptionFormByIdAsync(id);
                if (form == null)
                {
                    return NotFound(new { message = "Form not found." });
                }

                //var adopter = await _usersService.GetUserByIdAsync(form.AdopterId);
                //var pet = await _petService.GetPetById(form.PetId);
                //var shelterStaff = await _usersService.GetUserByIdAsync((int)form.ShelterStaffId);
                //var shelter = pet != null ? await _shelterService.GetShelterByID(pet.ShelterID) : null;

                var response = new AdoptionRegistrationFormResponse
                {
                    Id = form.Id,
                    SocialAccount = form.SocialAccount,
                    IncomeAmount = form.IncomeAmount,
                    IdentificationImage = form.IdentificationImage,
                    IdentificationImageBackSide = form.IdentificationImageBackSide,
                    AdopterId = form.AdopterId,
                    ShelterStaffId = form.ShelterStaffId,
                    PetId = form.PetId,
                    Status = form.Status
                };

                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex, "Error in GetFormDetailById with id: {Id}", id);
                return StatusCode(500, new { message = "An error occurred while processing your request." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error in GetFormDetailById with id: {Id}", id);
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }


        // POST: api/AdoptionRegistrationForm
        [HttpPost]

        public async Task<IActionResult> CreateForm([FromForm] FormCreateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await _adoptionFormService.FormExistsAsync(request.PetId))
                {
                    return StatusCode(500, new { message = "Pet is pending for Affirmation" });
                }

                var identificationImageUrl = await _fileUploadService.UploadFileAsync(request.IdentificationImage);
                var identificationImageBackSideUrl = await _fileUploadService.UploadFileAsync(request.IdentificationImageBackSide);

                var form = new AdoptionRegistrationForm
                {
                    SocialAccount = request.SocialAccount,
                    IncomeAmount = request.IncomeAmount,
                    IdentificationImage = identificationImageUrl,
                    IdentificationImageBackSide = identificationImageBackSideUrl,
                    AdopterId = request.AdopterId,
                    PetId = request.PetId,
                    Status = null
                };

                await _adoptionFormService.CreateAdoptionFormAsync(form);

                var response = new AdoptionRegistrationFormResponse
                {
                    Id = form.Id,
                    SocialAccount = form.SocialAccount,
                    IncomeAmount = form.IncomeAmount,
                    IdentificationImage = form.IdentificationImage,
                    IdentificationImageBackSide = form.IdentificationImageBackSide,
                    AdopterId = form.AdopterId,
                    PetId = form.PetId
                };

                return CreatedAtAction(nameof(GetFormDetailById), new { id = form.Id }, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex });
            }
        }

        // PUT: api/AdoptionRegistrationForm/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateForm(int id, [FromForm] FormUpdateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var form = await _adoptionFormService.GetAdoptionFormByIdAsync(id);



                if (form == null)
                {
                    return NotFound(new { message = "Form not found." });
                }

                if (request.IdentificationImage != null)
                {
                    form.IdentificationImage = await _fileUploadService.UploadFileAsync(request.IdentificationImage);
                }

                if (request.IdentificationImageBackSide != null)
                {
                    form.IdentificationImageBackSide = await _fileUploadService.UploadFileAsync(request.IdentificationImageBackSide);
                }

                if (request.SocialAccount != null)
                {
                    form.SocialAccount = request.SocialAccount;
                }

                if (request.IncomeAmount.HasValue)
                {
                    form.IncomeAmount = (decimal)request.IncomeAmount;
                }

                if (request.AdopterId.HasValue)
                {
                    form.AdopterId = request.AdopterId.Value;
                }

                if (request.ShelterStaffId.HasValue)
                {
                    form.ShelterStaffId = request.ShelterStaffId.Value;
                }

                if (request.PetId.HasValue)
                {
                    if (await _adoptionFormService.FormExistsAsync((int)request.PetId))
                    {
                        return StatusCode(500, new { message = "Pet already exist in a pending form" });
                    }
                    form.PetId = request.PetId.Value;
                }

                if (request.Status.HasValue)
                {
                    if ((bool)request.Status)
                    {
                        var otherForms = await _adoptionFormService.GetFormsByPetId(form.PetId);
                        if (otherForms != null)
                        {
                            foreach (var otherForm in otherForms)
                            {
                                otherForm.Status = false;
                            }
                        }
                        await _petService.UpdatePetAdoptionStatusAsync(form.PetId, 2, form.AdopterId); // Adopted
                    }
                    else
                    {
                        await _petService.UpdatePetAdoptionStatusAsync(form.PetId, 1, null);
                    }
                    form.Status = request.Status;

                }

                await _adoptionFormService.UpdateAdoptionFormAsync(form);

                return Ok(new { message = "Form has been updated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex });
            }

        }

        // DELETE: api/AdoptionRegistrationForm/{id}
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteForm(int id)
        {
            try
            {
                var form = await _adoptionFormService.GetAdoptionFormByIdAsync(id);
                if (form == null)
                {
                    return NotFound(new { message = "Form not found." });
                }

                await _adoptionFormService.DeleteAdoptionFormAsync(id);
                return Ok(new { message = "Form has been deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex });
            }
        }
    }

}
