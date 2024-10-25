using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SWP391_PawFund.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationsController : ControllerBase
	{
		private readonly INotificationService _notificationService;

		public NotificationsController(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}

		// GET: api/Notifications
		[HttpGet]
		[Authorize]
		public async Task<ActionResult<IEnumerable<NotificationResponseModel>>> GetNotifications()
		{
			try
			{
				var notifications = await _notificationService.GetAllNotificationsAsync();
				return Ok(notifications);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		// GET: api/Notifications/5
		[HttpGet("{id}")]
		[Authorize]
		public async Task<ActionResult<NotificationResponseModel>> GetNotification(int id)
		{
			try
			{
				var notification = await _notificationService.GetNotificationByIdAsync(id);

				if (notification == null)
				{
					return NotFound(new { message = $"Notification with ID {id} not found." });
				}

				return Ok(notification);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// POST: api/Notifications
		[HttpPost]
		[Authorize]
		public async Task<ActionResult> CreateNotification([FromBody] CreateNotificationRequestModel request)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				await _notificationService.CreateNotificationAsync(request);
				return Ok(new { message = "Notification created successfully." });
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// PUT: api/Notifications/5
		[HttpPut("{id}")]
		[Authorize]
		public async Task<IActionResult> UpdateNotification(int id, [FromBody] UpdateNotificationRequestModel request)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				var notification = await _notificationService.GetNotificationByIdAsync(id);
				if (notification == null)
				{
					return NotFound(new { message = $"Notification with ID {id} not found." });
				}

				await _notificationService.UpdateNotificationAsync(id, request);
				return Ok(new { message = "Notification updated successfully." });
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// DELETE: api/Notifications/5
		[HttpDelete("{id}")]
		[Authorize]
		public async Task<IActionResult> DeleteNotification(int id)
		{
			try
			{
				var notification = await _notificationService.GetNotificationByIdAsync(id);
				if (notification == null)
				{
					return NotFound(new { message = $"Notification with ID {id} not found." });
				}

				await _notificationService.DeleteNotificationAsync(id);
				return NoContent();
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = $"Error: {ex.Message}" });
			}
		}
	}
}
