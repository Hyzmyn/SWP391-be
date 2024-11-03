using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Entities.Momo;
using ServiceLayer.Interfaces;
using ServiceLayer.RequestModels;

namespace SWP391_PawFund.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class MomoController : ControllerBase
        {
            private readonly IMomoService _momoService;

            public MomoController(IMomoService momoService)
            {
                _momoService = momoService;
            }

            [HttpPost]
            public async Task<IActionResult> CreatePaymentUrl([FromForm] MomoOrderRequest request)
            {
                try
                {
                    var response = await _momoService.CreatePaymentAsync(request);
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { error = ex.Message });
                }
            }


            [HttpGet]
            public IActionResult PaymentCallBack()
            {
                var response = _momoService.PaymentExecuteAsync(HttpContext.Request.Query);
                return Ok(response);
            }
        }
}
