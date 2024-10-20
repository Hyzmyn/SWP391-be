﻿using Microsoft.EntityFrameworkCore;
using ModelLayer.Entities;
using RepositoryLayer.UnitOfWork;
using ServiceLayer.Interfaces;
using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
				.ToListAsync();

			var response = events.Select(e => new EventResponseModels
			{
				Id = e.Id,
				ShelterId = e.ShelterId,
				Name = e.Name,
				Date = e.Date,
				Description = e.Description,
				Location = e.Location,
				Users = e.Users?.Select(u => new UsersResponseModel
				{
					Id = u.Id,
					Username = u.Username,
					Email = u.Email,
					Location = u.Location ?? string.Empty,
					Phone = u.Phone ?? string.Empty
				}).ToList()
			});

			return response;
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

		public async Task CreateEventAsync(CreateEventRequestModel request)
		{
			var newEvent = new Event
			{
				ShelterId = request.ShelterId,
				Name = request.Name,
				Date = request.Date,
				Description = request.Description,
				Location = request.Location
			};

			await _unitOfWork.Repository<Event>().InsertAsync(newEvent);
			await _unitOfWork.CommitAsync();
		}

		public async Task UpdateEventAsync(int id, UpdateEventRequestModel request)
		{
			var existingEvent = await _unitOfWork.Repository<Event>().GetById(id);

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
			var existingEvent = await _unitOfWork.Repository<Event>().GetById(id);

			if (existingEvent == null)
			{
				throw new Exception($"Event with ID {id} not found.");
			}

			_unitOfWork.Repository<Event>().Delete(existingEvent);
			await _unitOfWork.CommitAsync();
		}
	}
}
