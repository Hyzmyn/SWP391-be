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
                PostId = (int)fb.PostId,
                Description = fb.Description,
                Date = fb.Date
            });
        }
        // Get Feedback by ID
        public async Task<FeedBackResponseDetail> GetFeedbackByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be greater than zero.", nameof(id));
            }

            var feedback = await _unitOfWork.Repository<FeedBack>().GetAll()
                .Include(fb => fb.User)
                .Include(fb => fb.Post)
                .FirstOrDefaultAsync(fb => fb.Id == id);

            if (feedback == null)
            {
                throw new KeyNotFoundException($"Feedback with ID {id} not found.");
            }

            return new FeedBackResponseDetail
            {
                FeedbackId = feedback.Id,
                UserId = feedback.UserId,
                PostId = (int)feedback.PostId,
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
                            PostId = (int) fb.PostId,
                            Description = fb.Description,
                            Date = fb.Date
                        }).ToList()
                }
            };
        }


        // Create new Feedback
        public async Task<FeedBackResponseDetail> CreateFeedbackAsync(FeedBackRequestModel request)
        {
            var user = await _unitOfWork.Repository<User>().GetById(request.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {request.UserId} not found.");
            }

            var post = await _unitOfWork.Repository<Post>().GetById(request.PostId);
            if (post == null)
            {
                throw new KeyNotFoundException($"Post with ID {request.PostId} not found.");
            }
            // Chuyển đổi giờ hiện tại sang giờ Việt Nam (UTC+7)
            var vietnamTime = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(7)).DateTime;

            var feedback = new FeedBack
            {
                UserId = request.UserId,
                PostId = request.PostId,
                Description = request.Description,
                Date = vietnamTime
            };

            await _unitOfWork.Repository<FeedBack>().InsertAsync(feedback);
            await _unitOfWork.CommitAsync();

            // Lấy lại Feedback vừa tạo để trả về response chi tiết
            var createdFeedback = await _unitOfWork.Repository<FeedBack>().GetAll()
                .Include(fb => fb.User)
                .Include(fb => fb.Post)
                .FirstOrDefaultAsync(fb => fb.Id == feedback.Id);

            if (createdFeedback == null)
            {
                throw new ApplicationException("An error occurred while retrieving the created feedback.");
            }

            return new FeedBackResponseDetail
            {
                FeedbackId = createdFeedback.Id,
                UserId = createdFeedback.UserId,
                PostId = (int) createdFeedback.PostId,
                Description = createdFeedback.Description,
                Date = createdFeedback.Date,
                User = new UsersResponseModel
                {
                    Id = createdFeedback.User.Id,
                    Username = createdFeedback.User.Username,
                    Email = createdFeedback.User.Email,
                    Location = createdFeedback.User.Location,
                    Phone = createdFeedback.User.Phone,
                    //TotalDonation = (decimal)createdFeedback.User.TotalDonation
                },
                Post = new PostResponseDetail
                {
                    Id = createdFeedback.Post.Id,
                    Title = createdFeedback.Post.Title,
                    Content = createdFeedback.Post.Content,
                    CreateDate = createdFeedback.Post.CreateDate,
                    UpdateDate = createdFeedback.Post.UpdateDate,
                    UserId = createdFeedback.Post.UserId,
                    PetId = createdFeedback.Post.PetId,
                    User = new UsersResponseModel
                    {
                        Id = createdFeedback.Post.User.Id,
                        Username = createdFeedback.Post.User.Username,
                        Email = createdFeedback.Post.User.Email,
                        Location = createdFeedback.Post.User.Location,
                        Phone = createdFeedback.Post.User.Phone,
                        TotalDonation = (decimal)createdFeedback.Post.User.TotalDonation,
                    },
                    FeedBacks = _unitOfWork.Repository<FeedBack>().GetAll()
                        .Where(fb => fb.PostId == createdFeedback.PostId)
                        .Select(fb => new FeedBackResponseModel
                        {
                            FeedbackId = fb.Id,
                            UserId = fb.UserId,
                            PostId = (int)fb.PostId,
                            Description = fb.Description,
                            Date = fb.Date
                        }).ToList()
                }
            };
        }

        // Update Feedback
        public async Task<FeedBackResponseDetail> UpdateFeedbackAsync(int id, FeedBackRequestModel request)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be greater than zero.", nameof(id));
            }

            var existingFeedback = await _unitOfWork.Repository<FeedBack>().GetById(id);
            if (existingFeedback == null)
            {
                throw new KeyNotFoundException($"Feedback with ID {id} not found.");
            }

            var user = await _unitOfWork.Repository<User>().GetById(request.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {request.UserId} not found.");
            }

            // Chuyển đổi giờ hiện tại sang giờ Việt Nam (UTC+7)
            var vietnamTime = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(7)).DateTime;

            var post = await _unitOfWork.Repository<Post>().GetById(request.PostId);
            if (post == null)
            {
                throw new KeyNotFoundException($"Post with ID {request.PostId} not found.");
            }

            // Cập nhật các thuộc tính
            existingFeedback.UserId = request.UserId;
            existingFeedback.PostId = request.PostId;
            existingFeedback.Description = request.Description;
            existingFeedback.Date = vietnamTime;

            _unitOfWork.Repository<FeedBack>().Update(existingFeedback, existingFeedback.Id);
            await _unitOfWork.CommitAsync();

            // Lấy lại Feedback vừa cập nhật để trả về response chi tiết
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
                PostId = (int)updatedFeedback.PostId,
                Description = updatedFeedback.Description,
                Date = updatedFeedback.Date,
                User = new UsersResponseModel
                {
                    Id = updatedFeedback.User.Id,
                    Username = updatedFeedback.User.Username,
                    Email = updatedFeedback.User.Email,
                    Location = updatedFeedback.User.Location,
                    Phone = updatedFeedback.User.Phone,
                    TotalDonation = (decimal)updatedFeedback.User.TotalDonation
                },
                Post = new PostResponseDetail
                {
                    Id = updatedFeedback.Post.Id,
                    Title = updatedFeedback.Post.Title,
                    Content = updatedFeedback.Post.Content,
                    CreateDate = updatedFeedback.Post.CreateDate,
                    UpdateDate = updatedFeedback.Post.UpdateDate,
                    UserId = updatedFeedback.Post.UserId,
                    PetId = updatedFeedback.Post.PetId,
                    User = new UsersResponseModel
                    {
                        Id = updatedFeedback.Post.User.Id,
                        Username = updatedFeedback.Post.User.Username,
                        Email = updatedFeedback.Post.User.Email,
                        Location = updatedFeedback.Post.User.Location,
                        Phone = updatedFeedback.Post.User.Phone,
                        //TotalDonation = (decimal)updatedFeedback.Post.User.TotalDonation,
                    },
                    FeedBacks = _unitOfWork.Repository<FeedBack>().GetAll()
                        .Where(fb => fb.PostId == updatedFeedback.PostId)
                        .Select(fb => new FeedBackResponseModel
                        {
                            FeedbackId = fb.Id,
                            UserId = fb.UserId,
                            PostId = (int)fb.PostId,
                            Description = fb.Description,
                            Date = fb.Date
                        }).ToList()
                }
            };
        }

        // Delete Feedback
        public async Task DeleteFeedbackAsync(int id)
        {
            var feedback = await _unitOfWork.Repository<FeedBack>().GetById(id);
            if (feedback == null)
            {
                throw new KeyNotFoundException($"Feedback with ID {id} not found.");
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
