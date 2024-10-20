using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Entities;
using ServiceLayer.Interfaces;
using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWP391_PawFund.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CertificationController : ControllerBase
    {
        private readonly ICertificationService _certificationService;
        private readonly ILogger<CertificationController> _logger;

        public CertificationController(ICertificationService certificationService, ILogger<CertificationController> logger)
        {
            _certificationService = certificationService;
            _logger = logger; // Inject logger
        }

        // GET: api/Certification
        [HttpGet]
        public ActionResult<IEnumerable<CertificationResponseDetail>> GetAllCertificates()
        {
            _logger.LogInformation("GetAllCertificates API called.");

            try
            {
                var certificates = _certificationService.GetAllCertificates();
                _logger.LogInformation("Successfully retrieved all certificates.");
                return Ok(certificates);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all certificates.");
                return StatusCode(500, new { message = "An error occurred while retrieving all certificates." });
            }
        }

        // GET: api/Certification/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CertificationResponseDetail>> GetCertificateById(int id)
        {
            _logger.LogInformation("GetCertificateById API called with ID {Id}.", id);

            try
            {
                var certificate = await _certificationService.GetCertificateByIdAsync(id);
                if (certificate == null)
                {
                    _logger.LogWarning("Certificate with ID {Id} not found.", id);
                    return NotFound(new { message = "Certificate not found." });
                }

                _logger.LogInformation("Successfully retrieved certificate with ID {Id}.", id);
                return Ok(certificate);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Certificate with ID {Id} not found.", id);
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving certificate with ID {Id}.", id);
                return StatusCode(500, new { message = "An error occurred while processing your request." });
            }
        }

        // POST: api/Certification
        [HttpPost]
        [Authorize(Roles = "Admin, ShelterStaff")]
        public async Task<IActionResult> CreateCertificate([FromForm] CertificationRequest request)
        {
            _logger.LogInformation("CreateCertificate API called.");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for CreateCertificate.");
                return BadRequest(ModelState);
            }

            try
            {
                var createdCertification = await _certificationService.CreateCertificateAsync(request);
                _logger.LogInformation("Successfully created certification with ID {Id}.", createdCertification.Id);
                return CreatedAtAction(nameof(GetCertificateById), new { id = createdCertification.Id }, createdCertification);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Unable to create certification, related data not found.");
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating certification.");
                return StatusCode(500, new { message = $"An error occurred while creating the certification: {ex.Message}", details = ex.StackTrace });
            }
        }

        // PUT: api/Certification/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, ShelterStaff")]
        public async Task<IActionResult> UpdateCertificate(int id, [FromForm] CertificationRequest request)
        {
            _logger.LogInformation("UpdateCertificate API called for ID {Id}.", id);

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for UpdateCertificate with ID {Id}.", id);
                return BadRequest(ModelState);
            }

            try
            {
                var updatedCertification = await _certificationService.UpdateCertificateAsync(id, request);
                _logger.LogInformation("Successfully updated certification with ID {Id}.", id);
                return Ok(updatedCertification);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Unable to update certification, ID {Id} not found.", id);
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating certification with ID {Id}.", id);
                return StatusCode(500, new { message = "An error occurred while updating the certification." });
            }
        }

        // DELETE: api/Certification/{id}
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCertificate(int id)
        {
            _logger.LogInformation("DeleteCertificate API called for ID {Id}.", id);

            try
            {
                await _certificationService.DeleteCertificateAsync(id);
                _logger.LogInformation("Successfully deleted certification with ID {Id}.", id);
                return Ok(new { message = "Certification has been deleted successfully." });
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Unable to delete certification, ID {Id} not found.", id);
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting certification with ID {Id}.", id);
                return StatusCode(500, new { message = "An error occurred while deleting the certification." });
            }
        }

        // API trả về chứng nhận theo UserId
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetCertificationByUserID(int userId)
        {
            _logger.LogInformation("GetCertificationByUserID API called for UserID {UserId}.", userId);

            if (userId <= 0)
            {
                _logger.LogWarning("Invalid UserID {UserId} provided.", userId);
                return BadRequest("UserId phải lớn hơn 0.");
            }

            try
            {
                var certifications = await _certificationService.GetCertificationByUserIdAsync(userId);
                if (certifications == null || !certifications.Any())
                {
                    _logger.LogWarning("No certifications found for UserID {UserId}.", userId);
                    return NotFound($"Không tìm thấy CertificateID cho UserID {userId}.");
                }

                _logger.LogInformation("Successfully retrieved certifications for UserID {UserId}.", userId);
                return Ok(certifications);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving certifications for UserID {UserId}.", userId);
                return StatusCode(500, $"Error Sever: {ex.Message}");
            }
        }
    }
}
