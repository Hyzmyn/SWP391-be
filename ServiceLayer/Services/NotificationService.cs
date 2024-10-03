using Microsoft.EntityFrameworkCore;
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
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<NotificationResponseDetail> GetAllNotifications()
        {
            var noltifications = _unitOfWork.Repository<Notification>().GetAll()
                .Include(user => user.User)
                .ToList();
            var response = noltifications.Select(n => new NotificationResponseDetail
            {
                Id = n.Id,
                Message = n.Message,
                Date = n.Date,
                User = n.User != null ? new UserDetailResponse
                {
                    Id = n.User.Id,
                    Username = n.User.Username,
                    Email = n.User.Email,
                    Phone = n.User.Phone,
                    Location = n.User.Location,
                    TotalDonation = (decimal)n.User.TotalDonation
                } : null
            });
            return response;
        }

        // Lấy Notification theo ID
        public async Task<NotificationResponseDetail> GetNotificationByIdAsync(int id)
        {
            if (id > 0)
            {
                throw new ArgumentException("Id must be greater than zero.", nameof(id));
            }
            var notification = await _unitOfWork.Repository<Notification>().GetAll()
                .Include(user => user.User)
                .FirstOrDefaultAsync(n => n.Id == id);

            if (notification == null)
            {
                throw new KeyNotFoundException($"Notification and ID {id} not found.");
            }
            var response = new NotificationResponseDetail
            {
                Id = notification.Id,
                Message = notification.Message,
                Date = notification.Date,
                UserId = notification.UserId,
                User = notification.User != null ? new UsersResponseModel
                {
                    Id = notification.User.Id,
                    Username = notification.User.Username,
                    Email = notification.User.Email,
                    Location = notification.User.Location,
                    Phone = notification.User.Phone,
                    TotalDonation = (decimal)notification.User.TotalDonation,
                } : null!
            };
            return response;
        }

        // Lấy Notifications theo UserId
        public async Task<IEnumerable<NotificationResponseDetail>> GetNotificationsByUserIdAsync(int userId)
        {
            var notifications = _unitOfWork.Repository<Notification>()
                    .AsQueryable()
                    .Where(d => d.UserId == userId)
                    .ToList();

            var user = await _unitOfWork.Repository<User>().GetById(userId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User ID {userId} not found.");
            }

            var response = notifications.Select(n => new NotificationResponseDetail
            {
                Id = n.Id,
                Message = n.Message,
                Date = n.Date,
                UserId = n.UserId,
                User = new UsersResponseModel
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    Location = user.Location,
                    Phone = user.Phone,
                    TotalDonation = (decimal) user.TotalDonation
                }
            });

            return response;
        }

        // Tạo mới Notification
        public async Task<NotificationResponseDetail> CreateNotificationAsync(NotificationRequestModel request)
        {
            var user = await _unitOfWork.Repository<User>().GetById(request.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException($"UserID {request.UserId} not found.");
            }

            var notification = new Notification
            {
                Message = request.Message,
                Date = request.Date,
                UserId = request.UserId
            };

            await _unitOfWork.Repository<Notification>().InsertAsync(notification);
            await _unitOfWork.CommitAsync();

            var createdNotification = await _unitOfWork.Repository<Notification>().GetAll()
                .Include(n => n.User)
                .FirstOrDefaultAsync(n => n.Id == notification.Id);

            if (createdNotification == null)
            {
                throw new ApplicationException("An error occurred while retrieving the newly created Notification..");
            }

            var response = new NotificationResponseDetail
            {
                Id = createdNotification.Id,
                Message = createdNotification.Message,
                Date = createdNotification.Date,
                UserId = createdNotification.UserId,
                User = createdNotification.User != null ? new UsersResponseModel
                {
                    Id = createdNotification.User.Id,
                    Username = createdNotification.User.Username, 
                    Email = createdNotification.User.Email,
                    Location = createdNotification.User.Location,
                    Phone = createdNotification.User.Phone,
                    TotalDonation =(decimal) createdNotification.User.TotalDonation
                } : null
            };

            return response;
        }
        // Cập nhật Notification
        public async Task<NotificationResponseDetail> UpdateNotificationAsync(int id, NotificationRequestModel request)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be greater than zero.", nameof(id));
            }

            var existingNotification = await _unitOfWork.Repository<Notification>().GetById(id);
            if (existingNotification == null)
            {
                throw new KeyNotFoundException($"Notification ID {id} not found.");
            }

            var user = await _unitOfWork.Repository<User>().GetById(request.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException($"UserID {request.UserId} not found.");
            }

            existingNotification.Message = request.Message;
            existingNotification.Date = request.Date;
            existingNotification.UserId = request.UserId;

            await _unitOfWork.Repository<Notification>().Update(existingNotification, existingNotification.Id);
            await _unitOfWork.CommitAsync();

            var updatedNotification = await _unitOfWork.Repository<Notification>().GetAll()
                .Include(n => n.User)
                .FirstOrDefaultAsync(n => n.Id == existingNotification.Id);

            if (updatedNotification == null)
            {
                throw new ApplicationException("An error occurred while retrieving the updated Notification..");
            }

            var response = new NotificationResponseDetail
            {
                Id = updatedNotification.Id,
                Message = updatedNotification.Message,
                Date = updatedNotification.Date,
                UserId = updatedNotification.UserId,
                User = updatedNotification.User != null ? new UsersResponseModel
                {
                    Id = updatedNotification.User.Id,
                    Username = updatedNotification.User.Username,
                    Email = updatedNotification.User.Email,
                    Location = updatedNotification.User.Location,
                    Phone = updatedNotification.User.Phone,
                    TotalDonation = (decimal)updatedNotification.User.TotalDonation
                } : null
            };

            return response;
        }

        // Xóa Notification
        public async Task DeleteNotificationAsync(int id)
        {
            var notification = await _unitOfWork.Repository<Notification>().GetById(id);
            if (notification == null)
            {
                throw new KeyNotFoundException($"NotificationID {id} not found.");
            }

            _unitOfWork.Repository<Notification>().Delete(notification);
            await _unitOfWork.CommitAsync();
        }

        // Kiểm tra Notification tồn tại
        public async Task<bool> NotificationExistsAsync(int id)
        {
            var notification = await _unitOfWork.Repository<Notification>().GetById(id);
            return notification != null;
        }
    }
}
