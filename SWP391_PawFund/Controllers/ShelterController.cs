using Microsoft.AspNetCore.Mvc;
using ModelLayer.Entities;
using ServiceLayer.Interfaces;
using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWP391_PawFund.Controllers
{

    [Route("api/Shelter")]
    [ApiController]
    public class ShelterController : ControllerBase
    {
        private readonly IShelterService _shelterService;
        private readonly ILogger<ShelterController> _logger;

        public ShelterController(IShelterService shelterService, ILogger<ShelterController> logger)
        {
            _shelterService = shelterService;
            _logger = logger;
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
                Capaxity = s.Capaxity,
                Email = s.Email,
                Website = s.Website,
                DonationAmount = s.DonationAmount,
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
                        StatusId = ps.StatusId, // Giả sử StatusId tương ứng với Status.Id
                        //Date = ps.Status?.Date ?? default,
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
                }).ToList()
                // Còn thiếu Donation, Event nha 
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
                Capaxity = shelter.Capaxity,
                Email = shelter.Email,
                Website = shelter.Website,
                DonationAmount = shelter.DonationAmount,
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
                        //Date = ps.Status?.Date ?? default,
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
                    Capaxity = shelter.Capaxity,
                    Email = shelter.Email,
                    Website = shelter.Website,
                    DonationAmount = shelter.DonationAmount,
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
                            Disease=ps.Status.Disease,
                            Vaccine=ps.Status.Vaccine
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
                    }).ToList(),
                    Events = shelter.Events?.Select(e => new EventResponseModel
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Description = e.Description,
                        Date = e.Date
                    }).ToList(),
                    //Donations = shelter.Donations?.Select(d => new DonationResponseModel
                    //{
                    //    Id = d.Id,
                    //    Amount = d.Amount,
                    //    DonorName = d.DonorName
                    //}).ToList()
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
                Capaxity = shelterRequest.Capaxity,
                Email = shelterRequest.Email,
                Website = shelterRequest.Website,
                DonationAmount = shelterRequest.DonationAmount,
                Pets = new List<Pet>(), 
                Users = new List<User>(), 
                Donations= new List<Donation>(),
                Events=new List<Event>()
            };

            var createdShelter = await _shelterService.CreateShelterAsync(shelter);

            var shelterResponse = new ShelterResponseModel
            {
                Id = createdShelter.Id,
                Name = createdShelter.Name,
                Location = createdShelter.Location,
                PhoneNumber = createdShelter.PhoneNumber,
                Capaxity = createdShelter.Capaxity,
                Email = createdShelter.Email,
                Website = createdShelter.Website,
                DonationAmount = createdShelter.DonationAmount,
                Pets = new List<PetResponseModel>(), 
                Users = new List<UsersResponseModel>() ,
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
            existingShelter.Capaxity = shelterRequest.Capaxity;
            existingShelter.Email = shelterRequest.Email;
            existingShelter.Website = shelterRequest.Website;
            existingShelter.DonationAmount = shelterRequest.DonationAmount;

            var updatedShelter = await _shelterService.UpdateShelterAsync(existingShelter);

            var shelterResponse = new ShelterResponseModel
            {
                Id = updatedShelter.Id,
                Name = updatedShelter.Name,
                Location = updatedShelter.Location,
                PhoneNumber = updatedShelter.PhoneNumber,
                Capaxity = updatedShelter.Capaxity,
                Email = updatedShelter.Email,
                Website = updatedShelter.Website,
                DonationAmount = updatedShelter.DonationAmount,
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
                        //Date = ps.Status?.Date ?? default,
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
                }).ToList()
                //Còn Donation với Event t chưa thêm nha
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
    }
}
