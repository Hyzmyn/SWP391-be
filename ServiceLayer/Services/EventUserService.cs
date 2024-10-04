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

        public IEnumerable<string> GetEventsOfUser(int userId)
        {
            return _unitOfWork.Repository<EventUser>()
                .AsQueryable()
                .Where(s => s.UserId == userId)
                .Include(s => s.Event)
                .Select(s => s.Event.Name)
                .ToList();
        }

        public bool UserHasEvent(int userId, string eventName)
        {
            return _unitOfWork.Repository<EventUser>()
                .AsQueryable()
                .Where(s => s.UserId == userId)
                .Include(s => s.Event)
                .Any(s => s.Event != null && s.Event.Name == eventName);
        }

        public async Task AddEventAsync(EventUser Event)
        {
            await _unitOfWork.Repository<EventUser>().InsertAsync(Event);
            await _unitOfWork.CommitAsync();
        }


        public async Task RemoveEventAsync(int id)
        {
            var Event = await _unitOfWork.Repository<EventUser>().GetById(id);
            if (Event != null)
            {
                _unitOfWork.Repository<EventUser>().Delete(Event);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                throw new Exception($"UserEvent with EventID {id} not found.");
            }
        }
    }
}
