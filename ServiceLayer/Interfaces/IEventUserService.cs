using ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
	public interface IEventUserService
	{
		Task<IEnumerable<EventUser>> GetEventUsersAsync();
		Task<EventUser> GetEventUserByIdAsync(int userId, int eventId);
		Task CreateEventUserAsync(EventUser eventUser);
		Task UpdateEventUserAsync(EventUser eventUser);
		Task DeleteEventUserAsync(int userId, int eventId);
		Task<bool> EventUserExistsAsync(int userId, int eventId);
	}
}
