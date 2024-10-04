using Microsoft.AspNetCore.Mvc;
using ModelLayer.Entities;
using ServiceLayer.Interfaces;
using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;
using ServiceLayer.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWP391_PawFund.Controllers
{

    [Route("api/Donate")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly IDonateService _donateService;
        private readonly IUsersService _usersService;
        private readonly IShelterService _shelterService;
        public DonationController(IDonateService donateService, IUsersService usersService, IShelterService shelterService)
        {
            _donateService = donateService;
            _usersService = usersService;
            _shelterService = shelterService;
        }


        // Lấy danh sách tất cả các donation
        [HttpGet]
        public ActionResult<IEnumerable<DonationResponseModel>> GetAllDonations()
        {
            var donations = _donateService.GetAllDonations()
               .Select(d => new DonationResponseModel
               {
                   Id = d.Id,
                   Amount = d.Amount,
                   Date = d.Date,
                   DonorId = d.DonorId,
                   DonorName = d.User.Username ?? string.Empty,
                   ShelterId = d.ShelterId,
                   ShelterName = d.Shelter?.Name ?? string.Empty
               });
            //var donations= _donateService.GetAllDonations();
            return Ok(donations);
        }


        // Lấy donation theo Id
        [HttpGet("{id}")]
        public async Task<ActionResult<DonationDetailResponseModel>> GetDonationById(int id)
        {
            var donation = await _donateService.GetDonationsByIdAsync(id);
            if (donation == null)
            {
                return NotFound(new { message = "Donation not found." });
            }

            var donor = await _usersService.GetUserByIdAsync(donation.DonorId);
            var shelter = await _shelterService.GetShelterByID(donation.ShelterId);

            var response = new DonationDetailResponseModel
            {
                Id = donation.Id,
                Amount = donation.Amount,
                Date = donation.Date,
                DonorId = donation.DonorId,
                DonorName = donor?.Username ?? string.Empty,
                ShelterId = donation.ShelterId,
                ShelterName = shelter?.Name ?? string.Empty,
                Donor = donor != null ? new UsersResponseModel
                {
                    Id = donor.Id,
                    Username = donor.Username,
                    Email = donor.Email,
                    Location = donor.Location,
                    Phone = donor.Phone,
                    TotalDonation = (decimal)donor.TotalDonation
                } : null,
                Shelter = shelter != null ? new ShelterResponseModel
                {
                    Id = shelter.Id,
                    Name = shelter.Name,
                    Location = shelter.Location,
                    PhoneNumber = shelter.PhoneNumber,
                    Capacity = shelter.Capaxity,
                    Email = shelter.Email,
                    Website = shelter.Website,
                    DonationAmount = (decimal)shelter.DonationAmount
                } : null
            };

            return Ok(response);
        }
        // Lấy danh sách donations theo DonorId
        [HttpGet("by-donor/{donorId}")]
        public ActionResult<IEnumerable<DonationResponseModel>> GetDonationsByDonorId(int donorId)
        {
            var donations = _donateService.GetDonationsByDonorId(donorId);

            if (donations == null || !donations.Any())
            {
                return NotFound($"No donations found for DonorId {donorId}.");
            }

            var response = donations.Select(d => new DonationResponseModel
            {
                Id = d.Id,
                Amount = d.Amount,
                Date = d.Date,
                DonorId = d.DonorId,
                DonorName = d.User?.Username ?? string.Empty,
                ShelterName = d.Shelter?.Name ?? string.Empty
            });

            return Ok(response);
        }



        // Thêm donation mới
        [HttpPost]
        public async Task<IActionResult> CreateDonation([FromBody] DonationCreateRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var donor = await _usersService.GetUserByIdAsync(request.DonorId);
            var shelter = await _shelterService.GetShelterByID(request.ShelterId);

            if (donor == null)
            {
                return NotFound(new { message = "Donor not found." });
            }

            if (shelter == null)
            {
                return NotFound(new { message = "Shelter not found." });
            }

            var donation = new Donation
            {
                Amount = request.Amount,
                Date = request.Date,
                DonorId = request.DonorId,
                ShelterId = request.ShelterId
            };

            await _donateService.CreateDonationAsync(donation);

            var response = new DonationResponseModel
            {
                Id = donation.Id,
                Amount = donation.Amount,
                Date = donation.Date,
                DonorId = donation.DonorId,
                ShelterId = donation.ShelterId,
                DonorName = donor.Username,
                ShelterName = shelter.Name
            };

            return CreatedAtAction(nameof(GetDonationById), new { id = donation.Id }, response);
        }



        // Cập nhật donation
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDonation(int id, [FromBody] DonationUpdateRequestModel request)
        {
            var existingDonation = await _donateService.GetDonationsByIdAsync(id);
            if (existingDonation == null)
            {
                return NotFound(new { message = "Donation not found." });
            }

            var donor = await _usersService.GetUserByIdAsync(request.DonorId);
            var shelter = await _shelterService.GetShelterByID(request.ShelterId);

            if (donor == null)
            {
                return NotFound(new { message = "Donor not found." });
            }

            if (shelter == null)
            {
                return NotFound(new { message = "Shelter not found." });
            }

            existingDonation.Amount = request.Amount;
            existingDonation.Date = request.Date;
            existingDonation.DonorId = request.DonorId;
            existingDonation.ShelterId = request.ShelterId;

            await _donateService.UpdateDonationAsync(existingDonation);
            return Ok(new { message = "Donation has been updated successfully." });
        }



        // Xóa donation theo Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonation(int id)
        {
            var donation = await _donateService.GetDonationsByIdAsync(id);
            if (donation == null)
            {
                return NotFound(new { message = "Donation not found." });
            }

            await _donateService.DeleteDonationAsync(id);
            return Ok(new { message = "Donation has been deleted successfully." });
        }

        // Lấy tổng donation theo ShelterId
        [HttpGet("shelter/{shelterId}/total")]
        public ActionResult<TotalShelterDonationResponseModel> GetTotalDonationByShelter(int shelterId)
        {
            var totalDonation = _donateService.GetTotalDonationByShelter(shelterId);
            return Ok(new TotalShelterDonationResponseModel
            {
                ShelterId = shelterId,
                TotalDonation = totalDonation
            });
        }

        // Lấy tổng donation theo DonorId (accountId)
        [HttpGet("donor/{donorId}/total")]
        public ActionResult<TotalDonorDonationResponseModel> GetTotalDonationByDonor(int donorId)
        {
            var totalDonation = _donateService.GetTotalDonationByDonor(donorId);
            return Ok(new TotalDonorDonationResponseModel
            {
                DonorId = donorId,
                TotalDonation = totalDonation
            });
        }
    }
}
