using Microsoft.AspNetCore.Mvc;
using ModelLayer.Entities;
using ServiceLayer.Interfaces;
using ServiceLayer.ResponseModels;
using ServiceLayer.Services;

namespace SWP391_PawFund.Controllers
{
    [Route("api/Event")]
    [ApiController]
    public class UserEventController : ControllerBase
    {
        private readonly IEventUserService _eventUserService;

        public UserEventController( IEventUserService eventUserService) 
        {
            _eventUserService = eventUserService;
        }

        [HttpGet("Event/{userId}/Events")]
        public ActionResult<IEnumerable<UserEventResponseModel>> GetEvent(int userId)
        {
            if (userId <= 0)
            {
                return BadRequest("Invalid user ID");
            }


            var eventt = _eventUserService.GetEventsOfUser(userId);

            if (eventt == null || !eventt.Any())
            {
                return NotFound($"No eventts found for UserId {userId}.");
            }

            var response = eventt.Select(s => new UserEventResponseModel
            {
                UserId = userId,
                Events = eventt.ToList()
            });

            return Ok(response);
        }

        [HttpGet("User/{userId}/HasEvent/{eventName}")]
        public ActionResult<bool> UserHasEvent(int userId, string eventtName)
        {
            if (userId <= 0)
            {
                return BadRequest("Invalid user ID");
            }
            if (string.IsNullOrEmpty(eventtName))
            {
                return BadRequest("Event name cannot be null or empty");
            }

            var hasEvent = _eventUserService.UserHasEvent(userId, eventtName);

            return Ok(hasEvent);
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent([FromBody] EventUser eventt)
        {
            if (eventt == null)
            {
                return BadRequest("Event cannot be null.");
            }

            if (eventt.UserId <= 0 || eventt.EventId <= 0)
            {
                return BadRequest("Invalid UserId or EventId.");
            }

            try
            {
                await _eventUserService.AddEventAsync(eventt);
                return Ok("Event successfully added.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the eventt: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveEvent(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid event ID.");
            }
            try
            {
                await _eventUserService.RemoveEventAsync(id);
                return Ok($"Event with ID {id} successfully removed.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
