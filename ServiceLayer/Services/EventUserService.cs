using Microsoft.EntityFrameworkCore;
using ModelLayer.Entities;
using RepositoryLayer.UnitOfWork;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
	public class EventUserService : IEventUserService
	{
		private readonly IUnitOfWork _unitOfWork;

		public EventUserService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<IEnumerable<EventUser>> GetEventUsersAsync()
		{
			return await _unitOfWork.Repository<EventUser>()
				.AsQueryable()
				.ToListAsync();
		}

		public async Task<EventUser> GetEventUserByIdAsync(int userId, int eventId)
		{
			return await _unitOfWork.Repository<EventUser>()
				.FindAsync(eu => eu.UserId == userId && eu.EventId == eventId);
		}

		public async Task CreateEventUserAsync(EventUser eventUser)
		{
			await _unitOfWork.Repository<EventUser>().InsertAsync(eventUser);
			await _unitOfWork.CommitAsync();
		}

		public async Task UpdateEventUserAsync(EventUser eventUser)
		{
			// Tìm bản ghi EventUser dựa trên UserId và EventId
			var existingEventUser = await _unitOfWork.Repository<EventUser>()
				.FindAsync(eu => eu.UserId == eventUser.UserId && eu.EventId == eventUser.EventId);

			if (existingEventUser != null)
			{
				// Cập nhật các thuộc tính mong muốn
				existingEventUser.Status = eventUser.Status;

				// Lưu thay đổi mà không gọi Update với Id
				await _unitOfWork.CommitAsync();
			}
			else
			{
				throw new Exception("EventUser not found.");
			}
		}




		public async Task DeleteEventUserAsync(int userId, int eventId)
		{
			var eventUser = await GetEventUserByIdAsync(userId, eventId);
			if (eventUser != null)
			{
				_unitOfWork.Repository<EventUser>().Delete(eventUser);
				await _unitOfWork.CommitAsync();
			}
		}

		public async Task<bool> EventUserExistsAsync(int userId, int eventId)
		{
			var eventUser = await GetEventUserByIdAsync(userId, eventId);
			return eventUser != null;
		}
	}
}
