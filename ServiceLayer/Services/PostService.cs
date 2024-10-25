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
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Post> GetPosts()
        {
            return _unitOfWork.Repository<Post>()
                              .GetAll();
        }

        public async Task<Post?> GetPostByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("Post ID cannot be zero.", nameof(id));
            }

            try
            {
                return await _unitOfWork.Repository<Post>()
                                         .GetAll()
                                         .Include(p => p.User)
                                         //.Include(p => p.)
                                         .FirstOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving the post.", ex);
            }
        }

        public async Task CreatePostAsync(Post post)
        {
            // Kiểm tra sự tồn tại của User và Pet trước khi tạo Post
            var user = await _unitOfWork.Repository<User>().GetById(post.UserId);
            if (user == null)
            {
                throw new InvalidOperationException($"User with ID {post.UserId} does not exist.");
            }

            var pet = await _unitOfWork.Repository<Pet>().GetById((int)post.PetId);
            if (pet == null)
            {
                throw new InvalidOperationException($"Pet with ID {post.PetId} does not exist.");
            }

            post.CreateDate = DateTime.UtcNow;
            post.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.Repository<Post>().InsertAsync(post);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdatePostAsync(Post post)
        {
            var existingPost = await _unitOfWork.Repository<Post>().GetById(post.Id);
            if (existingPost == null)
            {
                throw new KeyNotFoundException($"Post with ID {post.Id} not found.");
            }

            // Kiểm tra nếu UserId hoặc PetId được cập nhật
            if (post.UserId != existingPost.UserId)
            {
                var user = await _unitOfWork.Repository<User>().GetById(post.UserId);
                if (user == null)
                {
                    throw new InvalidOperationException($"User with ID {post.UserId} does not exist.");
                }
            }

            if (post.PetId != existingPost.PetId)
            {
                var pet = await _unitOfWork.Repository<Pet>().GetById((int)post.PetId);
                if (pet == null)
                {
                    throw new InvalidOperationException($"Pet with ID {post.PetId} does not exist.");
                }
            }

            existingPost.Title = post.Title;
            existingPost.Content = post.Content;
            existingPost.UpdateDate = DateTime.UtcNow;
            existingPost.UserId = post.UserId;
            existingPost.PetId = post.PetId;

            await _unitOfWork.Repository<Post>().Update(existingPost, existingPost.Id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await _unitOfWork.Repository<Post>().GetById(id);
            if (post != null)
            {
                _unitOfWork.Repository<Post>().Delete(post);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task<bool> PostExistsAsync(int id)
        {
            var post = await _unitOfWork.Repository<Post>().GetById(id);
            return post != null;
        }

        public async Task<IEnumerable<Post>> GetPostsByUserIdAsync(int userId)
        {
            return await _unitOfWork.Repository<Post>()
                                     .GetAll()
                                     .Where(p => p.UserId == userId)
                                     .Include(p => p.User)
                                     .ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsByPetIdAsync(int petId)
        {
            return await _unitOfWork.Repository<Post>()
                                     .GetAll()
                                     .Where(p => p.PetId == petId)
                                     //.Include(p => p.Pet)
                                     .ToListAsync();
        }
    }
}
