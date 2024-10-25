using Microsoft.AspNetCore.Mvc;
using ModelLayer.Entities;
using ServiceLayer.Interfaces;
using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;
using ServiceLayer.Services;

namespace SWP391_PawFund.Controllers
{
	[Route("api/Donate")]
	[ApiController]
	public class DonationController : ControllerBase
	{

		private readonly IDonateService _donateService;
		private readonly IUsersService _usersService;
		private readonly IShelterService _shelterService;
		private readonly ILogger<DonationController> _logger;
		private readonly IVnPayService _vpnPayService;

		public object TempData { get; private set; }
		public DonationController(IDonateService donateService, IUsersService usersService, IShelterService shelterService, IVnPayService vnPayservice, ILogger<DonationController> logger)
		{
			_donateService = donateService;
			_usersService = usersService;
			_shelterService = shelterService;
			_logger = logger;
			_vpnPayService = vnPayservice;
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
				   ShelterId = d.ShelterId,
				   Status = d.Status,
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
			var shelter = await _shelterService.GetShelterByIdAsync(donation.ShelterId);

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
					Capacity = shelter.Capacity,
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
						Capacity = d.Shelter.Capacity,
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
		[HttpPost("CreateDonate")]
		public async Task<IActionResult> CreateDonation([FromForm] DonationCreateRequestModel request)//, string payment = "VnPay")

		{

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			//if (payment == "Thanh toán VNPay")
			//{
			//	var user = await _usersService.GetUserByIdAsync(request.DonorId);
			//	if (user == null)
			//	{
			//		return NotFound(new { message = "Donor not found." });
			//	}

			//	var vnPayModel = new VnPaymentRequestModel
			//	{
			//		Amount = request.Amount,
			//		CreatedDate = DateTime.Now,
			//		Description = $"ID khách hàng:{request.DonorId}, Donate:{request.Amount}",
			//		FullName = user.Username,
			//		OrderId = new Random().Next(1000, 100000)
			//	};

			//	return Redirect(_vpnPayService.CreatePaymentUrl(HttpContext, vnPayModel));
			//}

			try
			{
				var donation = new Donation
				{
					Amount = request.Amount,
					Date = DateTime.UtcNow,
					DonorId = request.DonorId,
					ShelterId = request.ShelterId
				};

				await _donateService.CreateDonationAsync(donation);

				// Lấy thông tin User và Shelter đã được cập nhật
				var donor = await _usersService.GetUserByIdAsync(request.DonorId);
				var shelter = await _shelterService.GetShelterByIdAsync(request.ShelterId);

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
						TotalDonation = donor.TotalDonation ?? 0m
					} : null,
					Shelter = shelter != null ? new ShelterResponseModel
					{
						Id = shelter.Id,
						Name = shelter.Name,
						Location = shelter.Location,
						PhoneNumber = shelter.PhoneNumber,
						Capacity = shelter.Capacity,
						Email = shelter.Email,
						Website = shelter.Website,
						DonationAmount = shelter.DonationAmount ?? 0m
					} : null
				};

				return CreatedAtAction(nameof(GetDonationById), new { id = donation.Id }, response);
			}
			catch (ArgumentException ex)
			{
				_logger.LogError(ex, "Error creating donation: {Message}", ex.Message);
				return BadRequest(new { message = ex.Message });
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Unexpected error creating donation.");
				return StatusCode(500, new { message = "An unexpected error occurred while creating the donation." });
			}
		}


		// Cập nhật donation
		[HttpPut("Update_Donate/{id}")]
		public async Task<IActionResult> UpdateDonation(int id, [FromForm] DonationUpdateRequestModel request)
		{
			var existingDonation = await _donateService.GetDonationsByIdAsync(id);
			if (existingDonation == null)
			{
				return NotFound(new { message = "Donation not found." });
			}

			var donor = await _usersService.GetUserByIdAsync(request.DonorId);
			var shelter = await _shelterService.GetShelterByIdAsync(request.ShelterId);

			if (donor == null)
			{
				return NotFound(new { message = "Donor not found." });
			}

			if (shelter == null)
			{
				return NotFound(new { message = "Shelter not found." });
			}

			existingDonation.Amount = request.Amount;
			existingDonation.Date = DateTime.UtcNow;
			existingDonation.DonorId = request.DonorId;
			existingDonation.ShelterId = request.ShelterId;

			await _donateService.UpdateDonationAsync(existingDonation);
			return Ok(new { message = "Donation has been updated successfully." });
		}



		// Xóa donation theo Id
		[HttpDelete("Delete_Donate/{id}")]
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
		private bool IsValidId(int id)
		{
			return id > 0;
		}
		[HttpGet("Shelter/{shelterId}/Total")]
		public ActionResult<TotalShelterDonationResponseModel> GetTotalDonationByShelter(int shelterId)
		{
			if (!IsValidId(shelterId))
			{
				return BadRequest(new { message = "Invalid Shelter ID." });
			}

			var totalDonation = _donateService.GetTotalDonationByShelter(shelterId);

			if (totalDonation == null)
			{
				return NotFound(new { message = "Shelter not found or no donations available." });
			}

			return Ok(new TotalShelterDonationResponseModel
			{
				ShelterId = shelterId,
				TotalDonation = totalDonation
			});
		}

		// Lấy tổng donation theo DonorId (accountId)
		[HttpGet("Donor/{donorId}/Total")]
		public ActionResult<TotalDonorDonationResponseModel> GetTotalDonationByDonor(int donorId)
		{
			if (!IsValidId(donorId))
			{
				return BadRequest(new { message = "Invalid Donor ID." });
			}

			var totalDonation = _donateService.GetTotalDonationByDonor(donorId);

			if (totalDonation == null)
			{
				return NotFound(new { message = "Donor not found or no donations available." });
			}

			return Ok(new TotalDonorDonationResponseModel
			{
				DonorId = donorId,
				TotalDonation = totalDonation
			});
		}

		[HttpPut("{id}/status")]
		public async Task<IActionResult> UpdateDonationStatus(int id, [FromBody] UpdateDonationStatusRequest request)
		{
			try
			{
				var donation = await _donateService.GetDonationsByIdAsync(id);
				if (donation == null)
				{
					return NotFound(new { message = "Donation not found." });
				}

				await _donateService.UpdateDonationStatusAsync(id, request.Status);
				return Ok(new { message = "Donation status updated successfully." });
			}
			catch (ArgumentException ex)
			{
				_logger.LogError(ex, "Error updating donation status: {Message}", ex.Message);
				return BadRequest(new { message = ex.Message });
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Unexpected error updating donation status.");
				return StatusCode(500, new { message = "An unexpected error occurred while updating the donation status." });
			}
		}
		//[HttpPost("vnpay")]
		//public IActionResult PaymentCalls()
		//{
		//    var payload = new VnPaymentRequestModel
		//    {
		//        OrderId = 112,
		//        FullName = "Nguyen Binh",
		//        Description = "Ung ho cho meo",
		//        Amount = 11000,
		//        CreatedDate = DateTime.UtcNow.AddHours(7)

		//    };
		//    var url = _vpnPayService.CreatePaymentUrl(HttpContext, payload);
		//    return Ok(url);
		//}




		private static int currentOrderId = 1;

		[HttpPost("vnpay")]
		public IActionResult PaymentCalls([FromBody] VnPaymentRequestModel requestModel)
		{
			// Tăng OrderId mỗi khi có người mới
			currentOrderId += 1;

			// Khởi tạo payload với các giá trị từ requestModel
			var payload = new VnPaymentRequestModel
			{
				//OrderId = currentOrderId, 
				FullName = requestModel.FullName,
				Description = requestModel.Description,
				Amount = requestModel.Amount,
				CreatedDate = DateTime.UtcNow.AddHours(7), // Đặt thời gian hiện tại (UTC+7)
				 UserId = requestModel.UserId  // Include UserId in payload

			};

			// Tạo URL thanh toán
			var url = _vpnPayService.CreatePaymentUrl(HttpContext, payload);

			// Trả về link thanh toán
			return Ok(url);
		}




		[HttpGet("vnpay/api")]
		public async Task<IActionResult> PaymentCallBack()
		{
			var response = _vpnPayService.PaymentExecute(Request.Query);

			if (response == null || response.VnPayResponseCode != "00")
			{
				return StatusCode(500, new { message = $"Lỗi thanh toán VNPay: {response?.VnPayResponseCode ?? "unknown error"}" });
			}

			try
			{
				// Get user by ID
				var user = await _usersService.GetUserByIdAsync(response.UserId);
				if (user != null)
				{
					// Update wallet balance
					user.wallet = (user.wallet ?? 0) + response.Amount;
					await _usersService.UpdateUserAsync(user);

					return Ok(new
					{
						response,
						newWalletBalance = user.wallet
					});
				}

				return NotFound(new { message = $"User not found: {response.UserId}" });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = $"Error updating wallet: {ex.Message}" });
			}
		}
		}
	}

