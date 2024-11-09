using Microsoft.EntityFrameworkCore;
using ModelLayer.Entities;
using RepositoryLayer.UnitOfWork;
using ServiceLayer.Interfaces;
using ServiceLayer.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class UsersServices : IUsersService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _unitOfWork.Repository<User>()
                .AsQueryable()
                .ToListAsync();  // Make it asynchronous
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _unitOfWork.Repository<User>().GetById(id);
        }

        public async Task CreateUserAsync(User user)
        {
            await _unitOfWork.Repository<User>().InsertAsync(user);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            await _unitOfWork.Repository<User>().Update(user, user.Id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _unitOfWork.Repository<User>().GetById(id);
            if (user != null)
            {
                _unitOfWork.Repository<User>().Delete(user);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task<bool> UserExistsAsync(int id)
        {
            var user = await _unitOfWork.Repository<User>().GetById(id);
            return user != null;
        }

        public async Task<User> GetUserByUsernameAsync(string Username)
        {
            // Truy vấn người dùng từ cơ sở dữ liệu theo tên người dùng
            var user = await _unitOfWork.Repository<User>()
                .GetAll()
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Username == Username);

            return user;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            // Truy vấn người dùng từ cơ sở dữ liệu theo tên người dùng
            var user = await _unitOfWork.Repository<User>()
                .FindAsync(u => u.Email == email);

            return user;
        }

        public async Task<UsersResponseModel> GetUserProfile(int id)
        {
            var user = await _unitOfWork.Repository<User>().GetById(id);
            Shelter shelter = null;  

            if (user == null)
            {
                throw new Exception($"User with ID {id} not found.");
            }

            if (user.ShelterId != null)
            {
                shelter = await _unitOfWork.Repository<Shelter>().GetById((int)user.ShelterId);
            }

            var eventEntity = await _unitOfWork.Repository<EventUser>()
                .AsQueryable()
                .AsNoTracking()
                .Where(s => s.UserId == id)
                .Include(s => s.Event)
                .Select(s => s.Event.Name)
                .ToListAsync();

            var roles = await _unitOfWork.Repository<UserRole>()
                .AsQueryable()
                .AsNoTracking()
                .Where(s => s.UserId == id)
                .Include(s => s.Role)
                .Select(s => s.Role.Name)
                .ToListAsync();

            var responseModel = new UsersResponseModel
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Location = user.Location,
                Phone = user.Phone,
                TotalDonation = user.TotalDonation ?? 0,
                Image = user.Image ?? string.Empty,
                Shelter = shelter?.Name ?? "No Shelter",
                Wallet = user.wallet ?? 0m,
                Event = eventEntity.ToList(),
                Roles = roles.ToList(),
                Point = user.Point ?? 0,
                
            };

            return responseModel;
        }


    }
}
