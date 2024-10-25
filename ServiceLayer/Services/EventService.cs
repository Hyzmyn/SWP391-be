using Microsoft.EntityFrameworkCore;
using ModelLayer.Entities;
using RepositoryLayer.UnitOfWork;
using ServiceLayer.Interfaces;
using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;

namespace ServiceLayer.Services
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EventResponseModel>> GetAllEventsAsync()
        {
            var events = _unitOfWork.Repository<Event>().GetAll();
            var response = events.Select(e => new EventResponseModel
            {
                Id = e.Id,
                ShelterId = e.ShelterId,
                Name = e.Name,
                Date = e.Date,
                Description = e.Description,
                Location = e.Location
            });

            return await Task.FromResult(response);
        }

        public async Task<IEnumerable<EventResponseModels>> GetAllEventsWithUsersAsync()
        {
            var events = await _unitOfWork.Repository<Event>()
                .GetAll()
                .Include(e => e.Users)
                    .ThenInclude(eu => eu.User)
                .ToListAsync();

            var response = events.Select(e => new EventResponseModels
            {
                Id = e.Id,
                ShelterId = e.ShelterId,
                Name = e.Name,
                Date = e.Date,
                Description = e.Description,
                Location = e.Location,
                Users = e.Users?.Select(eu => new UsersResponseModel
                {
                    Id = eu.User.Id,
                    Username = eu.User.Username,
                    Email = eu.User.Email,
                    Location = eu.User.Location ?? string.Empty,
                    Phone = eu.User.Phone ?? string.Empty
                }).ToList()
            });

            return response;
        }

        public async Task<EventWithUserResponseModel> AddUserToEventAsync(AddUserToEventRequestModel request)
        {
            var eventEntity = await _unitOfWork.Repository<Event>()
                .GetAll()
                .Include(e => e.Users)
                .FirstOrDefaultAsync(e => e.Id == request.EventId);

            if (eventEntity == null)
            {
                throw new Exception($"Event with ID {request.EventId} not found.");
            }

            var user = await _unitOfWork.Repository<User>()
                .GetAll()
                .Include(u => u.Events)
                .FirstOrDefaultAsync(u => u.Id == request.UserId);

            if (user == null)
            {
                throw new Exception($"User with ID {request.UserId} not found.");
            }

            // Check if the user is already registered for this event
            if (eventEntity.Users != null && 
                eventEntity.Users.Any(eu => eu.UserId == request.UserId))
            {
                throw new Exception($"User is already registered for this event.");
            }

            // Initialize the Users collection if it's null
            if (eventEntity.Users == null)
            {
                eventEntity.Users = new List<EventUser>();
            }

            // Create new EventUser entry
            var eventUser = new EventUser
            {
                EventId = request.EventId,
                UserId = request.UserId,
                Event = eventEntity,
                User = user
            };

            eventEntity.Users.Add(eventUser);
            await _unitOfWork.CommitAsync();

            return new EventWithUserResponseModel
            {
                Event = new EventResponseModel
                {
                    Id = eventEntity.Id,
                    ShelterId = eventEntity.ShelterId,
                    Name = eventEntity.Name,
                    Date = eventEntity.Date,
                    Description = eventEntity.Description,
                    Location = eventEntity.Location
                },
                User = new UserResponseModel
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    Phone = user.Phone ?? string.Empty,
                    Location = user.Location ?? string.Empty,
                    TotalDonation = user.TotalDonation,
                    Wallet = user.wallet,
                    Image = user.Image ?? string.Empty,
                    Status = user.Status
                }
            };
        }

        public async Task<EventResponseModel> GetEventByIdAsync(int id)
        {
            var eventEntity = await _unitOfWork.Repository<Event>().GetById(id);

            if (eventEntity == null)
            {
                throw new Exception($"Event with ID {id} not found.");
            }

            return new EventResponseModel
            {
                Id = eventEntity.Id,
                ShelterId = eventEntity.ShelterId,
                Name = eventEntity.Name,
                Date = eventEntity.Date,
                Description = eventEntity.Description,
                Location = eventEntity.Location
            };
        }

		public async Task<IEnumerable<EventResponseModel>> GetEventsByUserIdAsync(int userId)
		{
			var user = await _unitOfWork.Repository<User>()
				.GetAll()
				.Include(u => u.Events)
					.ThenInclude(eu => eu.Event)
				.FirstOrDefaultAsync(u => u.Id == userId);

			if (user == null)
			{
				throw new Exception($"User with ID {userId} not found.");
			}

			var events = user.Events?
				.Select(eu => eu.Event)
				.Select(e => new EventResponseModel
				{
					Id = e.Id,
					ShelterId = e.ShelterId,
					Name = e.Name,
					Date = e.Date,
					Description = e.Description,
					Location = e.Location
				});

			return events ?? Enumerable.Empty<EventResponseModel>();
		}

		public async Task<IEnumerable<EventResponseModel>> GetEventsByShelterIdAsync(int shelterId)
		{
			var shelter = await _unitOfWork.Repository<Shelter>()
				.GetAll()
				.Include(s => s.Events)
				.FirstOrDefaultAsync(s => s.Id == shelterId);

			if (shelter == null)
			{
				throw new Exception($"Shelter with ID {shelterId} not found.");
			}

			var events = shelter.Events?
				.Select(e => new EventResponseModel
				{
					Id = e.Id,
					ShelterId = e.ShelterId,
					Name = e.Name,
					Date = e.Date,
					Description = e.Description,
					Location = e.Location
				});

			return events ?? Enumerable.Empty<EventResponseModel>();
		}




		public async Task CreateEventAsync(CreateEventRequestModel request)
        {
            var newEvent = new Event
            {
                ShelterId = request.ShelterId,
                Name = request.Name,
                Date = request.Date,
                Description = request.Description,
                Location = request.Location,
                Users = new List<EventUser>()
            };

            await _unitOfWork.Repository<Event>().InsertAsync(newEvent);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateEventAsync(int id, UpdateEventRequestModel request)
        {
            var existingEvent = await _unitOfWork.Repository<Event>()
                .GetAll()
                .Include(e => e.Users)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (existingEvent == null)
            {
                throw new Exception($"Event with ID {id} not found.");
            }

            existingEvent.ShelterId = request.ShelterId;
            existingEvent.Name = request.Name;
            existingEvent.Date = request.Date;
            existingEvent.Description = request.Description;
            existingEvent.Location = request.Location;

            await _unitOfWork.Repository<Event>().Update(existingEvent, existingEvent.Id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteEventAsync(int id)
        {
            var existingEvent = await _unitOfWork.Repository<Event>()
                .GetAll()
                .Include(e => e.Users)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (existingEvent == null)
            {
                throw new Exception($"Event with ID {id} not found.");
            }

            // Remove all associated EventUser entries
            if (existingEvent.Users != null)
            {
                existingEvent.Users.Clear();
            }

            _unitOfWork.Repository<Event>().Delete(existingEvent);
            await _unitOfWork.CommitAsync();
        }
    }
}