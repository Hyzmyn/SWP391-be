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
    public class CertificationController : ControllerBase
    {
        private readonly ICertificationService _certificationService;

        public CertificationController(ICertificationService certificationService)
        {
            _certificationService = certificationService;
        }

        // GET: api/Certification
        [HttpGet]
        public ActionResult<IEnumerable<CertificationResponseDetail>> GetAllCertificates()
        {
            var certificates = _certificationService.GetAllCertificate();

            var response = certificates.Select(c => new CertificationResponseDetail
            {
                Id = c.Id,
                Image = c.Image,
                Description = c.Desciption,
                Date = c.Date,
                ShelterStaffId = c.UserId,
                PetId = c.PetId,
                ShelterStaff = c.User != null ? new UserDetailResponse
                {
                    Id = c.User.Id,
                    Username = c.User.Username,
                    Email = c.User.Email,
                    Location = c.User.Location,
                    Phone = c.User.Phone,
                    TotalDonation = (decimal)c.User.TotalDonation,
                } : null!,
                Pet = c.Pet != null ? new PetDetailResponse
                {
                    Id = c.Pet.Id,
                    Name = c.Pet.Name,
                    Type = c.Pet.Type,
                    Breed = c.Pet.Breed,
                    Gender = c.Pet.Gender,
                    Age = (int)c.Pet.Age,
                    Size = c.Pet.Size,
                    Color = c.Pet.Color,
                    AdoptionStatus = c.Pet.AdoptionStatus,
                    Image = c.Pet.Image,
                    ShelterID = c.Pet.ShelterID,
                    UserID = (int)c.Pet.UserID,
                    Description = c.Pet.Description,
                    StatusId = (int)c.Pet.StatusId,
                    ShelterName = c.Pet.Shelter?.Name,
                } : null!
            });

            return Ok(response);
        }

        // GET: api/Certification/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CertificationResponseDetail>> GetCertificateById(int id)
        {
            var certificate = await _certificationService.GetCertificateByIdAsync(id);
            if (certificate == null)
            {
                return NotFound(new { message = "Certificate not found." });
            }

            var response = new CertificationResponseDetail
            {
                Id = certificate.Id,
                Image = certificate.Image,
                Description = certificate.Desciption,
                Date = certificate.Date,
                ShelterStaffId = certificate.UserId,
                PetId = certificate.PetId,
                ShelterStaff = certificate.User != null ? new UserDetailResponse
                {
                    Id = certificate.User.Id,
                    Username = certificate.User.Username,
                    Email = certificate.User.Email,
                    Location = certificate.User.Location,
                    Phone = certificate.User.Phone,
                    TotalDonation = (decimal)certificate.User.TotalDonation,
                } : null!,
                Pet = certificate.Pet != null ? new PetDetailResponse
                {
                    Id = certificate.Pet.Id,
                    Name = certificate.Pet.Name,
                    Type = certificate.Pet.Type,
                    Breed = certificate.Pet.Breed,
                    Gender = certificate.Pet.Gender,
                    Age = (int)certificate.Pet.Age,
                    Size = certificate.Pet.Size,
                    Color = certificate.Pet.Color,
                    AdoptionStatus = certificate.Pet.AdoptionStatus,
                    Image = certificate.Pet.Image,
                    ShelterID = certificate.Pet.ShelterID,
                    UserID = (int)certificate.Pet.UserID,
                    Description = certificate.Pet.Description,
                    StatusId = (int)certificate.Pet.StatusId,
                    ShelterName = certificate.Pet.Shelter?.Name,
                } : null!
            };

            return Ok(response);
        }

        // POST: api/Certification
        [HttpPost]
        public async Task<IActionResult> CreateCertificate([FromBody] CertificationRequest request)
        {
            var certification = new Certification
            {
                Image = request.Image,
                Desciption = request.Description,
                Date = request.Date,
                UserId = request.ShelterStaffId,
                PetId = request.PetId
            };

            await _certificationService.CreateCertificate(certification);

            // Fetch the created certification with related data
            var createdCertification = await _certificationService.GetCertificateByIdAsync(certification.Id);

            var response = new CertificationResponseDetail
            {
                Id = createdCertification.Id,
                Image = createdCertification.Image,
                Description = createdCertification.Desciption,
                Date = createdCertification.Date,
                ShelterStaffId = createdCertification.UserId,
                PetId = createdCertification.PetId,
                ShelterStaff = createdCertification.User != null ? new UserDetailResponse
                {
                    Id = createdCertification.User.Id,
                    Username = createdCertification.User.Username,
                    Email = createdCertification.User.Email,
                    Location = createdCertification.User.Location,
                    Phone = createdCertification.User.Phone,
                    TotalDonation = (decimal)createdCertification.User.TotalDonation,
                } : null!,
                Pet = createdCertification.Pet != null ? new PetDetailResponse
                {
                    Id = createdCertification.Pet.Id,
                    Name = createdCertification.Pet.Name,
                    Type = createdCertification.Pet.Type,
                    Breed = createdCertification.Pet.Breed,
                    Gender = createdCertification.Pet.Gender,
                    Age = (int)createdCertification.Pet.Age,
                    Size = createdCertification.Pet.Size,
                    Color = createdCertification.Pet.Color,
                    AdoptionStatus = createdCertification.Pet.AdoptionStatus,
                    Image = createdCertification.Pet.Image,
                    ShelterID = createdCertification.Pet.ShelterID,
                    UserID = (int)createdCertification.Pet.UserID,
                    Description = createdCertification.Pet.Description,
                    StatusId = (int)createdCertification.Pet.StatusId,
                    ShelterName = createdCertification.Pet.Shelter?.Name,
                } : null!
            };

            return CreatedAtAction(nameof(GetCertificateById), new { id = certification.Id }, response);
        }

        // PUT: api/Certification/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCertificate(int id, [FromBody] CertificationRequest request)
        {
            var certification = await _certificationService.GetCertificateByIdAsync(id);
            if (certification == null)
            {
                return NotFound(new { message = "Certificate not found." });
            }

            certification.Image = request.Image;
            certification.Desciption = request.Description;
            certification.Date = request.Date;
            certification.UserId = request.ShelterStaffId;
            certification.PetId = request.PetId;

            await _certificationService.UpdateCertificate(certification);

            return Ok(new { message = "Certificate has been updated successfully." });
        }

        // DELETE: api/Certification/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificate(int id)
        {
            var certification = await _certificationService.GetCertificateByIdAsync(id);
            if (certification == null)
            {
                return NotFound(new { message = "Certificate not found." });
            }

            await _certificationService.DeleteCertificateAsync(id);
            return Ok(new { message = "Certificate has been deleted successfully." });
        }
    }

}
