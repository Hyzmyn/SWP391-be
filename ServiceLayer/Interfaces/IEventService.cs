using ModelLayer.Entities;
using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
	public interface IEventService 
	{
		Task<IEnumerable<EventResponseModel>> GetAllEventsAsync();
		Task<EventResponseModel> GetEventByIdAsync(int id);
		Task CreateEventAsync(CreateEventRequestModel request);
		Task UpdateEventAsync(int id, UpdateEventRequestModel request);
		Task DeleteEventAsync(int id);
		Task<IEnumerable<EventResponseModels>> GetAllEventsWithUsersAsync(); // New method
		Task<EventWithUserResponseModel> AddUserToEventAsync(AddUserToEventRequestModel request);
		Task<IEnumerable<EventResponseModel>> GetEventsByUserIdAsync(int userId);
		Task<IEnumerable<EventResponseModel>> GetEventsByShelterIdAsync(int shelterId);

	}
}
