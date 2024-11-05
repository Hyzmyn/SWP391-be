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
        public async Task<IActionResult> PaymentCallBack()
        {
            var response = _momoService.PaymentExecuteAsync(HttpContext.Request.Query);

            if (response.Success)
            {
                try
                {
                    var savedTransaction = await _momoService.SaveTransactionAsync(response);
                    return Ok(new
                    {
                        Message = "Payment processed and transaction saved successfully.",
                        Transaction = savedTransaction
                    });
                }
                catch (Exception ex)
                {
                    return BadRequest(new { error = "Payment successful, but transaction save failed.", details = ex.Message });
                }
            }

            return BadRequest(new { error = response.Message });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            // Gọi service để xóa thanh toán với id
            var result = await _momoService.DeletePaymentAsync(id);

            if (!result)
            {
                return NotFound(new { message = "Thanh toán không tồn tại hoặc không thể xóa." });
            }
            return NoContent();
        }

    }
}
