using Microsoft.AspNetCore.Mvc;
using ModelLayer.Entities;
using ServiceLayer.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWP391_PawFund.Controllers
{

    [Route("api/Donate")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly IDonateService _donateService;

        public DonationController(IDonateService donateService)
        {
            _donateService = donateService;
        }

        // Lấy danh sách tất cả các donation
        [HttpGet]
        public ActionResult<IEnumerable<Donation>> GetAllDonations()
        {
            var donations = _donateService.GetAllDonations();
            return Ok(donations);
        }

        // Lấy donation theo Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Donation>> GetDonationById(int id)
        {
            var donation = await _donateService.GetDonationById(id);
            if (donation == null)
            {
                return NotFound();
            }
            return Ok(donation);
        }

        // Thêm donation mới
        [HttpPost]
        public async Task<IActionResult> CreateDonation([FromBody] Donation donation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _donateService.CreateDonationAsync(donation);
            return CreatedAtAction(nameof(GetDonationById), new { id = donation.Id }, donation);
        }

        // Cập nhật donation
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDonation(int id, [FromBody] Donation donation)
        {
            if (id != donation.Id)
            {
                return BadRequest("Donation ID mismatch");
            }

            var existingDonation = await _donateService.GetDonationById(id);
            if (existingDonation == null)
            {
                return NotFound();
            }

            await _donateService.UpdateDonationAsync(donation);
            return NoContent();
        }

        // Xóa donation theo Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonation(int id)
        {
            var donation = await _donateService.GetDonationById(id);
            if (donation == null)
            {
                return NotFound();
            }

            await _donateService.DeleteDonationAsync(id);
            return NoContent();
        }

        // Lấy tổng donation theo ShelterId
        [HttpGet("shelter/{shelterId}/total")]
        public ActionResult<decimal> GetTotalDonationByShelter(int shelterId)
        {
            var totalDonation = _donateService.GetTotalDonationByShelter(shelterId);
            return Ok(totalDonation);
        }

        // Lấy tổng donation theo DonorId (accountId)
        [HttpGet("donor/{donorId}/total")]
        public ActionResult<decimal> GetTotalDonationByDonor(int donorId)
        {
            var totalDonation = _donateService.GetTotalDonationByDonor(donorId);
            return Ok(totalDonation);
        }
    }
}
