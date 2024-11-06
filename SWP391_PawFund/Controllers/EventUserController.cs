using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Entities;
using ServiceLayer.Interfaces;
using ServiceLayer.RequestModels;

namespace SWP391_PawFund.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EventUsersController : ControllerBase
	{
		private readonly IEventUserService _eventUserService;

		public EventUsersController(IEventUserService eventUserService)
		{
			_eventUserService = eventUserService;
		}

		// GET: api/EventUsers
		[HttpGet]
		[Authorize]
		public async Task<ActionResult<IEnumerable<EventUser>>> GetEventUsers()
		{
			var eventUsers = await _eventUserService.GetEventUsersAsync();
			return Ok(eventUsers);
		}

		// GET: api/EventUsers/{userId}/{eventId}
		[HttpGet("{userId}/{eventId}")]
		[Authorize]
		public async Task<ActionResult<EventUser>> GetEventUser(int userId, int eventId)
		{
			var eventUser = await _eventUserService.GetEventUserByIdAsync(userId, eventId);
			if (eventUser == null)
			{
				return NotFound();
			}
			return Ok(eventUser);
		}

		// POST: api/EventUsers
		[HttpPost]
		public async Task<ActionResult> CreateEventUser([FromBody] EventUserCreateRequestModel eventUserModel)
		{
			try
			{
				var eventUser = new EventUser
				{
					UserId = eventUserModel.UserId,
					EventId = eventUserModel.EventId,
					Status = eventUserModel.Status
				};

				await _eventUserService.CreateEventUserAsync(eventUser);
				return Ok(new { message = "EventUser created successfully." });
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = ex.Message });
			}
		}

		// PUT: api/EventUsers/{userId}/{eventId}
		[HttpPut("{userId}/{eventId}")]
		public async Task<IActionResult> UpdateEventUser(int userId, int eventId, [FromBody] EventUserStatusUpdateRequestModel statusModel)
		{
			try
			{
				var eventUser = await _eventUserService.GetEventUserByIdAsync(userId, eventId);
				if (eventUser == null)
				{
					return NotFound(new { message = "EventUser not found." });
				}

				// Cập nhật mỗi trường Status
				eventUser.Status = statusModel.Status;

				await _eventUserService.UpdateEventUserAsync(eventUser);

				return Ok(new { message = "EventUser status updated successfully." });
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = ex.Message });
			}
		}

		// DELETE: api/EventUsers/{userId}/{eventId}
		[HttpDelete("{userId}/{eventId}")]
		[Authorize]
		public async Task<IActionResult> DeleteEventUser(int userId, int eventId)
		{
			var eventUserExists = await _eventUserService.EventUserExistsAsync(userId, eventId);
			if (!eventUserExists)
			{
				return NotFound();
			}

			await _eventUserService.DeleteEventUserAsync(userId, eventId);
			return NoContent();
		}
	}
}
