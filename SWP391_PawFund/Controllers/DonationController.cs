using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ModelLayer.Entities;
using ServiceLayer.Interfaces;
using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;
using ServiceLayer.Services;
using System.Drawing;

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
        private readonly IVnPayService _vpnPayService;

        public object TempData { get; private set; }

        public DonationController(IDonateService donateService, IUsersService usersService, IShelterService shelterService, IVnPayService vnPayservice, IVnPayService vpnPayService)
        {
            _donateService = donateService;
            _usersService = usersService;
            _shelterService = shelterService;
            _vpnPayService = vpnPayService;
        }


        // Lấy danh sách tất cả các donation
        [HttpGet]
        public ActionResult<IEnumerable<DonationResponseModel>> GetAllDonations()
        {
            var donations = _donateService.GetAllDonations()
               .Select(d => new DonationDetailResponseModel
               {
                   Id = d.Id,
                   Amount = d.Amount,
                   Date = d.Date,
                   DonorId = d.DonorId,
                   ShelterId = d.ShelterId,
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
                ShelterId = donation.ShelterId,
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
        public async Task<ActionResult<IEnumerable<DonationDetailResponseModel>>> GetAllDonationsByDonorId(int donorId)
        {
            try
            {
                var donations = await _donateService.GetDonationsByDonorId(donorId);

                if (donations == null)
                {
                    return NotFound(new { message = $"No donations found for DonorId {donorId}." });
                }

                var response = donations.Select(d => new DonationDetailResponseModel
                {
                    Id = d.Id,
                    Amount = d.Amount,
                    Date = d.Date,
                    DonorId = d.DonorId,
                    ShelterId = d.ShelterId,
                    Donor = d.User != null ? new UsersResponseModel
                    {
                        Id = d.User.Id,
                        Username = d.User.Username,
                        Email = d.User.Email,
                        Location = d.User.Location,
                        Phone = d.User.Phone,
                        TotalDonation = (decimal)d.User.TotalDonation
                    } : null,
                    Shelter = d.Shelter != null ? new ShelterResponseModel
                    {
                        Id = d.Shelter.Id,
                        Name = d.Shelter.Name,
                        Location = d.Shelter.Location,
                        PhoneNumber = d.Shelter.PhoneNumber,
                        Capacity = d.Shelter.Capaxity,
                        Email = d.Shelter.Email,
                        Website = d.Shelter.Website,
                        DonationAmount = (decimal)d.Shelter.DonationAmount
                    } : null
                });

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "An error occurred while processing your request." });
            }
        }



        // Thêm donation mới
        [HttpPost]
        public async Task<IActionResult> CreateDonation([FromBody] DonationCreateRequestModel request, string payment = "VnPay")
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (payment == "Thanh toán VNPay")
            {
                var user = await _usersService.GetUserByIdAsync(request.DonorId);
                if (user == null)
                {
                    return NotFound(new { message = "Donor not found." });
                }

                var vnPayModel = new VnPaymentRequestModel
                {
                    Amount = request.Amount,
                    CreatedDate = DateTime.Now,
                    Description = $"ID khách hàng:{request.DonorId}, Donate:{request.Amount}",
                    FullName = user.Username,
                    OrderId = new Random().Next(1000, 100000)
                };

                return Redirect(_vpnPayService.CreatePaymentUrl(HttpContext, vnPayModel));
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

            var response = new DonationDetailResponseModel
            {
                Id = donation.Id,
                Amount = donation.Amount,
                Date = donation.Date,
                DonorId = donation.DonorId,
                ShelterId = donation.ShelterId,
                Donor = new UsersResponseModel
                {
                    Id = donor.Id,
                    Username = donor.Username,
                    Email = donor.Email,
                    Location = donor.Location,
                    Phone = donor.Phone,
                    TotalDonation = (decimal)donor.TotalDonation
                },
                Shelter = new ShelterResponseModel
                {
                    Id = shelter.Id,
                    Name = shelter.Name,
                    Location = shelter.Location,
                    PhoneNumber = shelter.PhoneNumber,
                    Capacity = shelter.Capaxity,
                    Email = shelter.Email,
                    Website = shelter.Website,
                    DonationAmount = (decimal)shelter.DonationAmount
                }
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


		[HttpPost("vnpay")]
		public IActionResult PaymentCalls()
		{
            var payload = new VnPaymentRequestModel
            {
                OrderId = 112,
                FullName = "Nguyen Binh",
                Description = "Demo",
                Amount = 1100000,
				CreatedDate = DateTime.UtcNow.AddHours(7)

		};
            var url = _vpnPayService.CreatePaymentUrl(HttpContext, payload);
			return Ok(url);
		}
		[HttpGet("vnpay/api")]
		//[Authorize]
        public IActionResult PaymentCallBack()
        {
            var response = _vpnPayService.PaymentExecute(Request.Query);
            if (response == null || response?.VnPayResponseCode != "00")
            {
                return StatusCode(500, new { message = $"Lỗi thanh toán VNPay: {response?.VnPayResponseCode ?? "unknown error"}" });
            }

            return Ok(response);
        }
    }
}
