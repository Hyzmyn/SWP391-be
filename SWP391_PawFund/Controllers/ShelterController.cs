using Microsoft.AspNetCore.Mvc;
using ModelLayer.Entities;
using ServiceLayer.Interfaces;
using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;
using ServiceLayer.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWP391_PawFund.Controllers
{

    [Route("api/Shelter")]
    [ApiController]
    public class ShelterController : ControllerBase
    {
        private readonly IShelterService _shelterService;
        private readonly ILogger<ShelterController> _logger;
        private readonly IDonateService _donateService;

        public ShelterController(IShelterService shelterService, ILogger<ShelterController> logger, IDonateService donateService)
        {
            _shelterService = shelterService;
            _logger = logger;
            _donateService = donateService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShelterResponseModel>>> GetAllShelters()
        {
            var shelters = await _shelterService.GetAllSheltersAsync();
            
            var shelterResponses = shelters.Select(s => new ShelterResponseModel
            {
                Id = s.Id,
                Name = s.Name,
                Location = s.Location,
                PhoneNumber = s.PhoneNumber,
                Capacity = s.Capacity,
                Email = s.Email,
                BankAccount = s.BankAccount,
                Website = s.Website,
                DonationAmount = _donateService.GetTotalDonationByShelter(s.Id),
                Pets = s.Pets?.Select(p => new PetResponseModel
                {
                    PetID = p.Id,
                    ShelterID = p.ShelterID,
                    UserID = p.UserID,
                    Name = p.Name,
                    Type = p.Type,
                    Breed = p.Breed,
                    Gender = p.Gender,
                    Age = p.Age,
                    Size = p.Size,
                    Color = p.Color,
                    Description = p.Description,
                    AdoptionStatus = p.AdoptionStatus,
                    Image = p.Image,
                    Statuses = p.Statuses?.Select(ps => new StatusResponseModel
                    {
                        StatusId = ps.StatusId,
                        Date = ps.Status?.Date ?? default,
                        Disease = ps.Status?.Disease,
                        Vaccine = ps.Status?.Vaccine
                    }).ToList()
                }).ToList(),
                Users = s.Users?.Select(u => new UsersResponseModel
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    Location = u.Location ?? string.Empty,
                    Phone = u.Phone ?? string.Empty,
                    //TotalDonation = u.TotalDonation ?? 0
                    Roles = u.UserRoles?.Select(r => r.Role.Name).ToList() ?? new List<string>()
                }).ToList(),
                Events = s.Events?.Select(e => new EventResponseModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Date = e.Date,
                    Description = e.Description,
                    Location = e.Location
                }).ToList(),
                Donations = s.Donations?.Select(d => new DonationResponseModel
                {
                    Id = d.Id,
                    Amount = d.Amount,
                    Date = d.Date,
                    DonorId = d.DonorId,
                    ShelterId = d.ShelterId,
                }).ToList()
            }).ToList();

            return Ok(shelterResponses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShelterResponseModel>> GetShelterById(int id)
        {
            var shelter = await _shelterService.GetShelterByIdAsync(id);
            if (shelter == null)
            {
                return NotFound(new { message = $"Shelter with ID {id} not found." });
            }

            var shelterResponse = new ShelterResponseModel
            {
                Id = shelter.Id,
                Name = shelter.Name,
                Location = shelter.Location,
                PhoneNumber = shelter.PhoneNumber,
                Capacity = shelter.Capacity,
                Email = shelter.Email,
                BankAccount = shelter.BankAccount,
                Website = shelter.Website,
                DonationAmount = _donateService.GetTotalDonationByShelter(shelter.Id),
                Pets = shelter.Pets?.Select(p => new PetResponseModel
                {
                    PetID = p.Id,
                    ShelterID = p.ShelterID,
                    UserID = p.UserID,
                    Name = p.Name,
                    Type = p.Type,
                    Breed = p.Breed,
                    Gender = p.Gender,
                    Age = p.Age,
                    Size = p.Size,
                    Color = p.Color,
                    Description = p.Description,
                    AdoptionStatus = p.AdoptionStatus,
                    Image = p.Image,
                    Statuses = p.Statuses?.Select(ps => new StatusResponseModel
                    {
                        StatusId = ps.StatusId,
                        Date = ps.Status?.Date ?? default,
                        Disease = ps.Status?.Disease,
                        Vaccine = ps.Status?.Vaccine
                    }).ToList()
                }).ToList(),
                Users = shelter.Users?.Select(u => new UsersResponseModel
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    Location = u.Location ?? string.Empty,
                    Phone = u.Phone ?? string.Empty,
                    //TotalDonation = u.TotalDonation ?? 0
                    Roles = u.UserRoles?.Select(r => r.Role.Name).ToList() ?? new List<string>()
                }).ToList(),
                Events = shelter.Events?.Select(e => new EventResponseModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Date = e.Date,
                    Description = e.Description,
                    Location = e.Location
                }).ToList(),
                Donations = shelter.Donations?.Select(d => new DonationResponseModel
                {
                    Id = d.Id,
                    Amount = d.Amount,
                    Date = d.Date,
                    DonorId = d.DonorId,
                    ShelterId = d.ShelterId,
                    //DonorName = d.User?.Username ?? "Anonymous"
                }).ToList()
                //Còn thiếu Donation,Event nha
            };

            return Ok(shelterResponse);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetShelterByUserID(int userId)
        {
            try
            {
                var shelter = await _shelterService.GetShelterByUserIdAsync(userId);

                if (shelter == null)
                {
                    return NotFound(new { Message = "Shelter not found or user does not have access." });
                }

                var shelterResponse = new ShelterResponseModel
                {
                    Id = shelter.Id,
                    Name = shelter.Name,
                    Location = shelter.Location,
                    PhoneNumber = shelter.PhoneNumber,
                    Capacity = shelter.Capacity,
                    Email = shelter.Email,
                    BankAccount = shelter.BankAccount,
                    Website = shelter.Website,
                    DonationAmount = _donateService.GetTotalDonationByShelter(shelter.Id),
                    Pets = shelter.Pets?.Select(p => new PetResponseModel
                    {
                        PetID = p.Id,
                        ShelterID = p.ShelterID,
                        UserID = p.UserID,
                        Name = p.Name,
                        Type = p.Type,
                        Breed = p.Breed,
                        Gender = p.Gender,
                        Age = p.Age,
                        Size = p.Size,
                        Color = p.Color,
                        Description = p.Description,
                        AdoptionStatus = p.AdoptionStatus,
                        Image = p.Image,
                        Statuses = p.Statuses?.Select(ps => new StatusResponseModel
                        {
                            StatusId = ps.Status.Id,
                            Date=ps.Status.Date,
                            Disease = ps.Status.Disease,
                            Vaccine = ps.Status.Vaccine
                        }).ToList()
                    }).ToList(),
                    Users = shelter.Users?.Select(u => new UsersResponseModel
                    {
                        Id = u.Id,
                        Username = u.Username,
                        Email = u.Email,
                        Phone = u.Phone,
                        Location = u.Location,
                        //TotalDonation = u.TotalDonation ?? 0
                        Roles = u.UserRoles?.Select(r => r.Role.Name).ToList() ?? new List<string>()
                    }).ToList(),
                    Events = shelter.Events?.Select(e => new EventResponseModel
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Description = e.Description,
                        Date = e.Date
                    }).ToList(),
                    Donations = shelter.Donations?.Select(d => new DonationResponseModel
                    {
                        Id = d.Id,
                        Amount = d.Amount,
                        Date = d.Date,
                        DonorId = d.DonorId,
                        ShelterId = d.ShelterId,    
                        //DonorName = d.User?.Username ?? "Anonymous"
                    }).ToList()
                };

                return Ok(shelterResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving the shelter.", Details = ex.Message });
            }
        }
        [HttpPost("Create_Shelter")]
        public async Task<ActionResult<ShelterResponseModel>> CreateShelter([FromForm] ShelterRequestModel shelterRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shelter = new Shelter
            {
                Name = shelterRequest.Name,
                Location = shelterRequest.Location,
                PhoneNumber = shelterRequest.PhoneNumber,
                Capacity = shelterRequest.Capacity,
                Email = shelterRequest.Email,
                BankAccount = shelterRequest.BankAccount,
                Website = shelterRequest.Website,
                DonationAmount = shelterRequest.DonationAmount,
                Pets = new List<Pet>(),
                Users = new List<User>(),
                Donations = new List<Donation>(),
                Events = new List<Event>()
            };

            var createdShelter = await _shelterService.CreateShelterAsync(shelter);

            var shelterResponse = new ShelterResponseModel
            {
                Id = createdShelter.Id,
                Name = createdShelter.Name,
                Location = createdShelter.Location,
                PhoneNumber = createdShelter.PhoneNumber,
                Capacity = createdShelter.Capacity,
                Email = createdShelter.Email,
                BankAccount = createdShelter.BankAccount,
                Website = createdShelter.Website,
                DonationAmount = createdShelter.DonationAmount,
                Pets = new List<PetResponseModel>(),
                Users = new List<UsersResponseModel>(),
                Donations = new List<DonationResponseModel>(),
                Events = new List<EventResponseModel>()
            };

            return CreatedAtAction(nameof(GetShelterById), new { id = shelterResponse.Id }, shelterResponse);
        }


        [HttpPut("Update/{id}")]
        public async Task<ActionResult<ShelterResponseModel>> UpdateShelter(int id, [FromForm] ShelterRequestModel shelterRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingShelter = await _shelterService.GetShelterByIdAsync(id);
            if (existingShelter == null)
            {
                return NotFound(new { message = $"Shelter with ID {id} not found." });
            }

            existingShelter.Name = shelterRequest.Name;
            existingShelter.Location = shelterRequest.Location;
            existingShelter.PhoneNumber = shelterRequest.PhoneNumber;
            existingShelter.Capacity = shelterRequest.Capacity;
            existingShelter.Email = shelterRequest.Email;
            existingShelter.BankAccount = shelterRequest.BankAccount;
            existingShelter.Website = shelterRequest.Website;
            existingShelter.DonationAmount = shelterRequest.DonationAmount;

            var updatedShelter = await _shelterService.UpdateShelterAsync(existingShelter);

            var shelterResponse = new ShelterResponseModel
            {
                Id = updatedShelter.Id,
                Name = updatedShelter.Name,
                Location = updatedShelter.Location,
                PhoneNumber = updatedShelter.PhoneNumber,
                Capacity = updatedShelter.Capacity,
                Email = updatedShelter.Email,
                BankAccount = updatedShelter.BankAccount,
                Website = updatedShelter.Website,
                DonationAmount = _donateService.GetTotalDonationByShelter(updatedShelter.Id),
                Pets = updatedShelter.Pets?.Select(p => new PetResponseModel
                {
                    PetID = p.Id,
                    ShelterID = p.ShelterID,
                    UserID = p.UserID,
                    Name = p.Name,
                    Type = p.Type,
                    Breed = p.Breed,
                    Gender = p.Gender,
                    Age = p.Age,
                    Size = p.Size,
                    Color = p.Color,
                    Description = p.Description,
                    AdoptionStatus = p.AdoptionStatus,
                    Image = p.Image,
                    Statuses = p.Statuses?.Select(ps => new StatusResponseModel
                    {
                        StatusId = ps.StatusId,
                        Date = ps.Status?.Date ?? default,
                        Disease = ps.Status?.Disease,
                        Vaccine = ps.Status?.Vaccine
                    }).ToList()
                }).ToList(),
                Users = updatedShelter.Users?.Select(u => new UsersResponseModel
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    Location = u.Location ?? string.Empty,
                    Phone = u.Phone ?? string.Empty,
                    //TotalDonation = u.TotalDonation ?? 0
                    Roles = u.UserRoles?.Select(r => r.Role.Name).ToList() ?? new List<string>()
                }).ToList(),
                Events = updatedShelter.Events?.Select(e => new EventResponseModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Date = e.Date,
                    Description = e.Description,
                    Location = e.Location
                }).ToList(),
                Donations = updatedShelter.Donations?.Select(d => new DonationResponseModel
                {
                    Id = d.Id,
                    Amount = d.Amount,
                    Date = d.Date,
                    DonorId = d.DonorId,
                    ShelterId = d.ShelterId,
                    //DonorName = d.User?.Username ?? "Anonymous"
                }).ToList()
            };
            return Ok(shelterResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShelter(int id)
        {
            var isDeleted = await _shelterService.DeleteShelterAsync(id);
            if (!isDeleted)
            {
                return NotFound(new { message = $"Shelter with ID {id} not found." });
            }

            return Ok(new { message = "Shelter has been deleted successfully." });
        }

        // API để lấy tổng donation theo ShelterId
        [HttpGet("{shelterId}/total-donation")]
        public IActionResult GetTotalDonationByShelter(int shelterId)
        {
            try
            {
                if (shelterId <= 0)
                {
                    return BadRequest("ShelterId phải lớn hơn 0.");
                }
                var totalDonation = _donateService.GetTotalDonationByShelter(shelterId);

                return Ok(totalDonation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Đã có lỗi xảy ra: {ex.Message}");
            }
        }
    }
}
