using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;

namespace ServiceLayer.Interfaces
{
    public interface INotificationService
    {
        Task DeleteNotificationAsync(int id);
        IEnumerable<NotificationResponseDetail> GetAllNotifications();
        Task<NotificationResponseDetail> GetNotificationByIdAsync(int id);
        Task<IEnumerable<NotificationResponseDetail>> GetNotificationsByUserIdAsync(int userId);
        Task<bool> NotificationExistsAsync(int id);
        Task<NotificationResponseDetail> UpdateNotificationAsync(int id, NotificationRequestModel request);

        Task<NotificationResponseDetail> CreateNotificationAsync(NotificationRequestModel request);
    }
}