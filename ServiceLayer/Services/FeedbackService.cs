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
    public class FeedbackService : IFeedbackService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FeedbackService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Get ALL Feedbacks
        public IEnumerable<FeedBackResponseModel> GetAllFeedbacks()
        {
            var feedbacks = _unitOfWork.Repository<FeedBack>().GetAll()
                .Include(fb => fb.User)
                .Include(fb => fb.Post);

            return feedbacks.Select(fb => new FeedBackResponseModel
            {
                FeedbackId = fb.Id,
                UserId = fb.UserId,
                PostId = fb.PostId,
                Description = fb.Description,
                Date = fb.Date
            });
        }

        // Get Feedback by ID
        public async Task<FeedBackResponseDetail> GetFeedbackByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id cần lớn hơn 0.", nameof(id));
            }

            var feedback = await _unitOfWork.Repository<FeedBack>().GetAll()
                .Include(fb => fb.User)
                .Include(fb => fb.Post)
                .FirstOrDefaultAsync(fb => fb.Id == id);

            if (feedback == null)
            {
                throw new KeyNotFoundException($"Phản hồi với ID {id} không tìm thấy.");
            }

            return new FeedBackResponseDetail
            {
                FeedbackId = feedback.Id,
                UserId = feedback.UserId,
                PostId = feedback.PostId,
                Description = feedback.Description,
                Date = feedback.Date,
                User = new UsersResponseModel
                {
                    Id = feedback.User.Id,
                    Username = feedback.User.Username,
                    Email = feedback.User.Email,
                    Location = feedback.User.Location,
                    Phone = feedback.User.Phone,
                    TotalDonation = (decimal)feedback.User.TotalDonation,
                },
                Post = new PostResponseDetail
                {
                    Id = feedback.Post.Id,
                    Title = feedback.Post.Title,
                    Content = feedback.Post.Content,
                    CreateDate = feedback.Post.CreateDate,
                    UpdateDate = feedback.Post.UpdateDate,
                    UserId = feedback.Post.UserId,
                    PetId = feedback.Post.PetId,
                    User = new UsersResponseModel
                    {
                        Id = feedback.Post.User.Id,
                        Username = feedback.Post.User.Username,
                        Email = feedback.Post.User.Email,
                        Location = feedback.Post.User.Location,
                        Phone = feedback.Post.User.Phone,
                        //TotalDonation = (decimal)feedback.Post.User.TotalDonation
                    },
                    FeedBacks = _unitOfWork.Repository<FeedBack>().GetAll()
                        .Where(fb => fb.PostId == feedback.PostId)
                        .Select(fb => new FeedBackResponseModel
                        {
                            FeedbackId = fb.Id,
                            UserId = fb.UserId,
                            PostId = fb.PostId,
                            Description = fb.Description,
                            Date = fb.Date
                        }).ToList()
                }
            };
        }

        //Create Tạo Feedback
        public async Task<FeedBackResponseDetail> CreateFeedbackAsync(FeedBackRequestModel request)
        {
            var user = await _unitOfWork.Repository<User>().GetById(request.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User với ID {request.UserId} không tìm thấy.");
            }

            var vietnamTime = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(7)).DateTime;

            // Tạo mới Feedback và thiết lập các thuộc tính
            var feedback = new FeedBack
            {
                UserId = request.UserId,
                Description = request.Description,
                Date = vietnamTime,
                PostId = request.PostId  
            };

            await _unitOfWork.Repository<FeedBack>().InsertAsync(feedback);
            await _unitOfWork.CommitAsync();

            // Truy vấn và trả về chi tiết Feedback đã tạo
            var createdFeedback = await _unitOfWork.Repository<FeedBack>().GetAll()
                .Include(fb => fb.User)
                .Include(fb => fb.Post)
                .FirstOrDefaultAsync(fb => fb.Id == feedback.Id);

            if (createdFeedback == null)
            {
                throw new ApplicationException("Đã xảy ra lỗi khi truy xuất phản hồi đã tạo.");
            }

            return new FeedBackResponseDetail
            {
                FeedbackId = createdFeedback.Id,
                UserId = createdFeedback.UserId,
                PostId = createdFeedback.PostId,
                Description = createdFeedback.Description,
                Date = createdFeedback.Date,
                User = new UsersResponseModel
                {
                    Id = createdFeedback.User.Id,
                    Username = createdFeedback.User.Username,
                    Email = createdFeedback.User.Email,
                    Location = createdFeedback.User.Location,
                    Phone = createdFeedback.User.Phone
                },
                Post = createdFeedback.Post == null ? null : new PostResponseDetail
                {
                    Id = createdFeedback.Post.Id,
                    Title = createdFeedback.Post.Title,
                    Content = createdFeedback.Post.Content,
                    CreateDate = createdFeedback.Post.CreateDate,
                    UpdateDate = createdFeedback.Post.UpdateDate,
                    UserId = createdFeedback.Post.UserId,
                    PetId = createdFeedback.Post.PetId
                }
            };
        }

        public async Task<FeedBackResponseDetail> UpdateFeedbackAsync(int id, FeedBackRequestModel request)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id cần lớn hơn 0.", nameof(id));
            }

            var existingFeedback = await _unitOfWork.Repository<FeedBack>().GetById(id);
            if (existingFeedback == null)
            {
                throw new KeyNotFoundException($"Phàn hồi với ID {id} không tìm thấy.");
            }

            var user = await _unitOfWork.Repository<User>().GetById(request.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User với ID {request.UserId} không tìm thấy.");
            }

            var vietnamTime = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(7)).DateTime;

            // Cập nhật các thuộc tính
            existingFeedback.UserId = request.UserId;
            existingFeedback.Description = request.Description;
            existingFeedback.Date = vietnamTime;
            existingFeedback.PostId = request.PostId;  

            _unitOfWork.Repository<FeedBack>().Update(existingFeedback, existingFeedback.Id);
            await _unitOfWork.CommitAsync();

            var updatedFeedback = await _unitOfWork.Repository<FeedBack>().GetAll()
                .Include(fb => fb.User)
                .Include(fb => fb.Post)
                .FirstOrDefaultAsync(fb => fb.Id == existingFeedback.Id);

            if (updatedFeedback == null)
            {
                throw new ApplicationException("An error occurred while retrieving the updated feedback.");
            }

            return new FeedBackResponseDetail
            {
                FeedbackId = updatedFeedback.Id,
                UserId = updatedFeedback.UserId,
                PostId = updatedFeedback.PostId,
                Description = updatedFeedback.Description,
                Date = updatedFeedback.Date,
                User = new UsersResponseModel
                {
                    Id = updatedFeedback.User.Id,
                    Username = updatedFeedback.User.Username,
                    Email = updatedFeedback.User.Email,
                    Location = updatedFeedback.User.Location,
                    Phone = updatedFeedback.User.Phone
                },
                Post = updatedFeedback.Post == null ? null : new PostResponseDetail
                {
                    Id = updatedFeedback.Post.Id,
                    Title = updatedFeedback.Post.Title,
                    Content = updatedFeedback.Post.Content,
                    CreateDate = updatedFeedback.Post.CreateDate,
                    UpdateDate = updatedFeedback.Post.UpdateDate,
                    UserId = updatedFeedback.Post.UserId,
                    PetId = updatedFeedback.Post.PetId
                }
            };
        }


        // Delete Feedback
        public async Task DeleteFeedbackAsync(int id)
        {
            var feedback = await _unitOfWork.Repository<FeedBack>().GetById(id);
            if (feedback == null)
            {
                throw new KeyNotFoundException($"Phản hồi với ID {id} không tìm thấy.");
            }

            _unitOfWork.Repository<FeedBack>().Delete(feedback);
            await _unitOfWork.CommitAsync();
        }

        // Check if Feedback Exists
        public async Task<bool> FeedbackExistsAsync(int id)
        {
            var feedback = await _unitOfWork.Repository<FeedBack>().GetById(id);
            return feedback != null;
        }
    }
}
