using Microsoft.AspNetCore.Mvc;
using ModelLayer.Entities;
using ServiceLayer.Interfaces;
using ServiceLayer.RequestModels;
using ServiceLayer.Services;
using Twilio.AspNet.Common;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWP391_PawFund.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {

        private readonly ISMSService _smsService;

        public SmsController(ISMSService smsService)
        {
            _smsService = smsService;
        }

        [HttpPost]
        [ActionName("SendSMS")]  
        public async Task<IActionResult> SendSms([FromBody] SMSRequest request)
        {
            if (string.IsNullOrEmpty(request.To) || string.IsNullOrEmpty(request.Message))
            {
                return BadRequest("Cần cung cấp số điện thoại người nhận và nội dung tin nhắn.");
            }

            try
            {
                var result = await _smsService.SendAsync(request.Message, request.To);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi gửi SMS: {ex.Message}");
            }
        }
    }
}
