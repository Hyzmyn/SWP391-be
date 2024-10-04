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
        IEnumerable<string> GetEventsOfUser(int userId);
        bool UserHasEvent(int userId, string eventName);
        Task AddEventAsync(EventUser Event);
        Task RemoveEventAsync(int id);
    }
}
