using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWP391_PawFund.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize] 
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // GET: api/Notification
        [HttpGet]
        public ActionResult<IEnumerable<NotificationResponseDetail>> GetAllNotifications()
        {
            var notifications = _notificationService.GetAllNotifications();
            return Ok(notifications);
        }

        // GET: api/Notification/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<NotificationResponseDetail>> GetNotificationById(int id)
        {
            try
            {
                var notification = await _notificationService.GetNotificationByIdAsync(id);
                return Ok(notification);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "An error occurred while processing your request." });
            }
        }

        // GET: api/Notification/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<NotificationResponseDetail>>> GetNotificationsByUserId(int userId)
        {
            try
            {
                var notifications = await _notificationService.GetNotificationsByUserIdAsync(userId);
                return Ok(notifications);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "An error occurred while processing your request." });
            }
        }

        // POST: api/Notification
        [HttpPost]
        //[Authorize(Roles = "Admin, User")] 
        public async Task<IActionResult> CreateNotification([FromBody] NotificationRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdNotification = await _notificationService.CreateNotificationAsync(request);
                return CreatedAtAction(nameof(GetNotificationById), new { id = createdNotification.Id }, createdNotification);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "An error occurred while creating Notification." });
            }
        }

        // PUT: api/Notification/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, User")] // Chỉ Admin và User mới được cập nhật Notification
        public async Task<IActionResult> UpdateNotification(int id, [FromBody] NotificationRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedNotification = await _notificationService.UpdateNotificationAsync(id, request);
                return Ok(updatedNotification);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "An error occurred while updating Notification." });
            }
        }

        // DELETE: api/Notification/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] // Chỉ Admin mới được xóa Notification
        public async Task<IActionResult> DeleteNotification(int id)
        {
            try
            {
                await _notificationService.DeleteNotificationAsync(id);
                return Ok(new { message = "Notification has been successfully deleted." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "An error occurred while deleting Notification.." });
            }
        }
    }
}
