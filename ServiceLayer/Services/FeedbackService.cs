using Microsoft.AspNetCore.Http.HttpResults;
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
        private readonly IUsersService _usersService;
        public FeedbackService(IUnitOfWork unitOfWork, IUsersService usersService)
        {
            _unitOfWork = unitOfWork;
            _usersService = usersService;
        }

        // Get ALL FeedBack
        // Get ALL Feedbacks
        public IEnumerable<FeedBackResponseModel> GetAllFeedbacks()
        {
            var feedbacks = _unitOfWork.Repository<FeedBack>().GetAll()
                //.Include(fb => fb.Post)
                //.Include(fb => fb.UserId)
                ;
            return feedbacks.Select(fb => new FeedBackResponseModel
            {
                FeedbackId = fb.Id,
                UserId = fb.UserId,
                Description = fb.Description,
                Date = fb.Date,
                PostId = fb.Post.Id,
                //PostTitle = fb.Post?.Title,
                //Thiếu UserDetail
            });
        }

        // Get By ID
        public async Task<FeedBackResponseModel> GetFeedBackById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be greater than zero.", nameof(id));
            }

            var feedback = await _unitOfWork.Repository<FeedBack>().GetById(id);
            if (feedback == null)
            {
                throw new KeyNotFoundException($"Feedback with ID({id} )not found.");
            }

            return new FeedBackResponseModel
            {
                FeedbackId = feedback.Id,
                UserId = feedback.UserId,
                Description = feedback.Description,
                Date = feedback.Date,
                PostId = feedback.Post?.Id
            };
        }

        // Create new Feedback
        public async Task<FeedBackResponseModel> CreateFeedback(FeedBackRequestModel request)
        {
            var feedback = new FeedBack
            {
                UserId = request.UserId,
                Description = request.Description,
                Date = DateTime.UtcNow

                //Thiếu PostID
            };

            //if ((int)request.PostId.HasValue)
            //{
            //    var post = await _unitOfWork.Repository<Post>().GetById(request.PostId.Value);
            //    if (post == null)
            //    {
            //        throw new KeyNotFoundException("Post not found.");
            //    }
            //    feedback.Post = post;
            //}

            await _unitOfWork.Repository<FeedBack>().InsertAsync(feedback);
            await _unitOfWork.CommitAsync();

            return new FeedBackResponseModel
            {
                FeedbackId = feedback.Id,
                UserId = feedback.UserId,
                Description = feedback.Description,
                Date = feedback.Date,
                PostId = feedback.Post?.Id
            };
        }

        // Update Feedback
        public async Task<FeedBackResponseModel> UpdateFeedbackAsync(int id, FeedBackRequestModel request)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be greater than zero.", nameof(id));
            }

            var existingFeedback = await _unitOfWork.Repository<FeedBack>().GetById(id);
            if (existingFeedback == null)
            {
                throw new KeyNotFoundException($"Feedback with ID ({id}) not found.");
            }

            var user = await _unitOfWork.Repository<User>().GetById(request.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID ({request.UserId}) not found.");
            }

            // Kiểm tra sự tồn tại của Post nếu PostId được cung cấp
            //Post? post = null;
            //if (request.PostId.HasValue)
            //{
            //    post = await _unitOfWork.Repository<Post>().GetById(request.PostId.Value);
            //    if (post == null)
            //    {
            //        throw new KeyNotFoundException($"Post with ID {request.PostId.Value} not found.");
            //    }
            //}

            // Cập nhật các thuộc tính
            existingFeedback.UserId = request.UserId;
            existingFeedback.Description = request.Description;
            existingFeedback.Date = DateTime.UtcNow;
            //existingFeedback.Post = request.PostId;

            await _unitOfWork.Repository<FeedBack>().Update(existingFeedback, existingFeedback.Id);
            await _unitOfWork.CommitAsync();

            return new FeedBackResponseModel
            {
                FeedbackId = existingFeedback.Id,
                UserId = existingFeedback.UserId,
                Description = existingFeedback.Description,
                Date = existingFeedback.Date,
                PostId = existingFeedback.Post?.Id,
                //Username = user.Username
            };
        }
        // Delete Feedback
        public async Task DeleteFeedback(int id)
        {
            var feedback = await _unitOfWork.Repository<FeedBack>().GetById(id);
            if (feedback == null)
            {
                throw new KeyNotFoundException($"Feedback with Id ({id}) not found.");
            }

            _unitOfWork.Repository<FeedBack>().Delete(feedback);
            await _unitOfWork.CommitAsync();
        }
    }
}
