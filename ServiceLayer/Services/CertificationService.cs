using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ModelLayer.Entities;
using RepositoryLayer;
using RepositoryLayer.UnitOfWork;
using ServiceLayer.Interfaces;
using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Http;

namespace ServiceLayer.Services
{
    public class CertificationService : ICertificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPetService _petService;
        private readonly IUserRoleService _userRoleService;

        public CertificationService(IUnitOfWork unitOfWork, IPetService petService, IUserRoleService userRoleService)
        {
            _unitOfWork = unitOfWork;
            _petService = petService;
            _userRoleService = userRoleService;
        }
        // Lấy tất cả chứng nhận
        public IEnumerable<CertificationResponseDetail> GetAllCertificates()
        {
            var certifications = _unitOfWork.Repository<Certification>().GetAll()
                .Include(c => c.User)
                    .ThenInclude(u => u.UserRoles)
                        .ThenInclude(ur => ur.Role)
                .Include(c => c.Pet)
                    .ThenInclude(p => p.Shelter)
                .Include(c => c.Pet.Statuses)
                    .ThenInclude(p => p.Status)
                 .Include(c => c.ShelterStaff)
                .ToList();

            var response = certifications.Select(c => new CertificationResponseDetail
            {
                Id = c.Id,
                Image = c.Image,
                Description = c.Desciption,
                Date = c.Date,
                ShelterStaffID = c.ShelterStaffId,
                UserId = c.UserId,
                PetId = c.PetId,
                User = c.User != null ? new UsersResponseModel
                {
                    Id = c.User.Id,
                    Username = c.User.Username,
                    Email = c.User.Email,
                    Location = c.User.Location,
                    Phone = c.User.Phone,
                    Roles = c.User.UserRoles?.Select(r => r.Role.Name).ToList() ?? new List<string>() // Chỉ lấy tên vai trò
                } : null!,
                ShelterStaff = c.ShelterStaff != null ? new UsersResponseModel
                {
                    Id = c.ShelterStaffId,
                    Username = c.ShelterStaff.Username,
                    Email = c.ShelterStaff.Email,
                    Location = c.ShelterStaff.Location,
                    Phone = c.ShelterStaff.Phone,
                    // TotalDonation = (decimal)c.ShelterStaff.TotalDonation,
                } : null!,
                Pet = c.Pet != null ? new PetDetailResponse
                {
                    PetID = c.Pet.Id,
                    Name = c.Pet.Name,
                    Type = c.Pet.Type,
                    Breed = c.Pet.Breed,
                    Gender = c.Pet.Gender,
                    Age = c.Pet.Age.HasValue ? c.Pet.Age.Value : 0,
                    Size = c.Pet.Size,
                    Color = c.Pet.Color,
                    AdoptionStatus = c.Pet.AdoptionStatus,
                    Image = c.Pet.Image,
                    ShelterID = c.Pet.ShelterID,
                    UserID = c.Pet.UserID.HasValue ? c.Pet.UserID.Value : 0,
                    Description = c.Pet.Description,
                    Statuses = c.Pet.Statuses.Select(ps => new StatusResponseModel
                    {
                        StatusId = ps.StatusId,
                        Disease = ps.Status?.Disease,
                        Vaccine = ps.Status?.Vaccine,
                    }).ToList(),
                    ShelterName = c.Pet.Shelter != null ? c.Pet.Shelter.Name : null
                } : null!
            });

            return response;
        }

        // Lấy chứng nhận theo ID
        public async Task<CertificationResponseDetail> GetCertificateByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id phải lớn hơn 0.", nameof(id));
            }


            var certification = await _unitOfWork.Repository<Certification>().GetAll()
                .Include(c => c.User)
                .Include(c => c.Pet)
                    .ThenInclude(p => p.Shelter)
                .Include(c => c.Pet.Statuses)
                    .ThenInclude(ps => ps.Status)
                .FirstOrDefaultAsync(c => c.Id == id);
            //Check tìm Role
            var roles = await _userRoleService.GetRolesOfUserAsync(certification.UserId);

            if (certification == null)
            {
                throw new KeyNotFoundException($"CertificationID {id} không tìm thấy.");
            }

            var response = new CertificationResponseDetail
            {
                Id = certification.Id,
                Image = certification.Image,
                Description = certification.Desciption,
                Date = certification.Date,
                UserId = certification.Id,
                ShelterStaffID = certification.UserId,
                PetId = certification.PetId,
                User = certification.User != null ? new UsersResponseModel
                {
                    Id = certification.UserId,
                    Username = certification.User.Username,
                    Email = certification.User.Email,
                    Location = certification.User.Location,
                    Phone = certification.User.Phone,
                    Roles = roles.ToList()

                } : null!,
                ShelterStaff = certification.ShelterStaff != null ? new UsersResponseModel
                {
                    Id = certification.ShelterStaff.Id,
                    Username = certification.ShelterStaff.Username,
                    Email = certification.ShelterStaff.Email,
                    Location = certification.ShelterStaff.Location,
                    Phone = certification.ShelterStaff.Phone,
                    //TotalDonation = (decimal)certification.User.TotalDonation,
                } : null!,
                Pet = certification.Pet != null ? new PetDetailResponse
                {
                    PetID = certification.Pet.Id,
                    Name = certification.Pet.Name,
                    Type = certification.Pet.Type,
                    Breed = certification.Pet.Breed,
                    Gender = certification.Pet.Gender,
                    Age = certification.Pet.Age,
                    Size = certification.Pet.Size,
                    Color = certification.Pet.Color,
                    AdoptionStatus = certification.Pet.AdoptionStatus,
                    Image = certification.Pet.Image,
                    ShelterID = certification.Pet.ShelterID,
                    UserID = certification.Pet.UserID,
                    Description = certification.Pet.Description,
                    Statuses = certification.Pet.Statuses.Select(ps => new StatusResponseModel
                    {
                        StatusId = ps.StatusId,
                        Disease = ps.Status.Disease,
                        Vaccine = ps.Status.Vaccine
                    }).ToList(),
                    ShelterName = certification.Pet.Shelter?.Name
                } : null!
            };

            return response;
        }

        // Tạo mới chứng nhận
        public async Task<CertificationResponseDetail> CreateCertificateAsync(CertificationRequest request)
        {
            var shelterStaff = await _unitOfWork.Repository<User>()
                .GetAll()
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Id == request.ShelterStaffId);

            if (shelterStaff == null || !shelterStaff.UserRoles.Any(ur => ur.Role.Name == "ShelterStaff"))
            {
                throw new UnauthorizedAccessException("User không có quyền truy cập, yêu cầu role là 'Staff'.");
            }

            // Kiểm tra sự tồn tại của Pet
            var pet = await _unitOfWork.Repository<Pet>().GetById(request.PetId);
            if (pet == null)
            {
                throw new KeyNotFoundException($"Pet với ID {request.PetId} không tìm thấy.");
            }

            // Kiểm tra sự tồn tại của User trước khi tạo chứng nhận
            var user = await _unitOfWork.Repository<User>().GetById(request.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User với ID {request.UserId} không tìm thấy.");
            }

            var certification = new Certification
            {
                Image = "string",
                Desciption = request.Description,
                Date = DateTime.UtcNow,
                ShelterStaffId = request.ShelterStaffId,
                UserId = request.UserId,
                PetId = request.PetId
            };
            try
            {
                await _unitOfWork.Repository<Certification>().InsertAsync(certification);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                // Log chi tiết lỗi từ InnerException (nếu có)
                throw new ApplicationException($"An error occurred while creating the certification: {ex.Message}", ex);
            }

            //Check tìm Role
            var roles = await _userRoleService.GetRolesOfUserAsync(request.UserId);

            // Lấy lại Certification vừa tạo để trả về response chi tiết
            var createdCertification = await _unitOfWork.Repository<Certification>().GetAll()
                .Include(c => c.User)
                .Include(c => c.Pet)
                    .ThenInclude(p => p.Shelter)
                .Include(c => c.Pet.Statuses) // Include Pet Statuses
                    .ThenInclude(ps => ps.Status)
                .Include(c => c.ShelterStaff)
                .FirstOrDefaultAsync(c => c.Id == certification.Id);

            if (createdCertification == null)
            {
                throw new ApplicationException("Có lỗi xảy ra khi truy xuất chứng nhận đã tạo.");
            }

            var response = new CertificationResponseDetail
            {
                Id = createdCertification.Id,
                Image = createdCertification.Image,
                Description = createdCertification.Desciption,
                Date = createdCertification.Date,
                ShelterStaffID = createdCertification.ShelterStaffId,
                UserId = createdCertification.UserId,
                PetId = createdCertification.PetId,
                User = createdCertification.User != null ? new UsersResponseModel
                {
                    Id = createdCertification.UserId,
                    Username = createdCertification.User.Username,
                    Email = createdCertification.User.Email,
                    Location = createdCertification.User.Location,
                    Phone = createdCertification.User.Phone,
                    Roles = roles.ToList()
                } : null!,
                ShelterStaff = createdCertification.ShelterStaff != null ? new UsersResponseModel
                {
                    Id = createdCertification.ShelterStaff.Id,
                    Username = createdCertification.ShelterStaff.Username,
                    Email = createdCertification.ShelterStaff.Email,
                    Location = createdCertification.ShelterStaff.Location,
                    Phone = createdCertification.ShelterStaff.Phone,
                    //TotalDonation = (decimal)createdCertification.ShelterStaff.TotalDonation,
                } : null!,
                Pet = createdCertification.Pet != null ? new PetDetailResponse
                {

                    Name = createdCertification.Pet.Name,
                    Type = createdCertification.Pet.Type,
                    Breed = createdCertification.Pet.Breed,
                    Gender = createdCertification.Pet.Gender,
                    Age = createdCertification.Pet.Age ?? 0,
                    Size = createdCertification.Pet.Size,
                    Color = createdCertification.Pet.Color,
                    AdoptionStatus = createdCertification.Pet.AdoptionStatus,
                    Image = createdCertification.Pet.Image,
                    ShelterID = createdCertification.Pet.ShelterID,
                    ShelterName = createdCertification.Pet.Shelter?.Name,
                    UserID = createdCertification.Pet.UserID ?? 0,
                    Description = createdCertification.Pet.Description,
                    Statuses = createdCertification.Pet.Statuses?.Select(s => new StatusResponseModel
                    {
                        StatusId = s.StatusId,
                        Disease = s.Status?.Disease,
                        Vaccine = s.Status?.Vaccine
                    }).ToList(), // Trả về danh sách Status
                } : null!
            };
            return response;
        }

        // Cập nhật chứng nhận
        public async Task<CertificationResponseDetail> UpdateCertificateAsync(int id, CertificationRequest request)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id phải lớn hơn 0.", nameof(id));
            }

            var existingCertification = await _unitOfWork.Repository<Certification>().GetById(id);
            if (existingCertification == null)
            {
                throw new KeyNotFoundException($"Chứng nhận với ID {id} không tìm thấy.");
            }

            var shelterStaff = await _unitOfWork.Repository<User>()
                .GetAll()
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Id == request.ShelterStaffId);

            if (shelterStaff == null || !shelterStaff.UserRoles.Any(ur => ur.Role.Name == "ShelterStaff"))
            {
                throw new UnauthorizedAccessException("User không có quyền truy cập, yêu cầu role là 'Staff'.");
            }

            // Kiểm tra sự tồn tại của Pet
            var pet = await _unitOfWork.Repository<Pet>().GetById(request.PetId);
            if (pet == null)
            {
                throw new KeyNotFoundException($"Pet với ID {request.PetId} không tìm thấy.");
            }

            // Kiểm tra sự tồn tại của User trước khi tạo chứng nhận
            var user = await _unitOfWork.Repository<User>().GetById(request.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User với ID {request.UserId} không tìm thấy.");
            }

            existingCertification.Image = "string";
            existingCertification.Desciption = request.Description;
            existingCertification.Date = DateTime.UtcNow;
            existingCertification.UserId = request.ShelterStaffId;
            existingCertification.PetId = request.PetId;

            _unitOfWork.Repository<Certification>().Update(existingCertification, existingCertification.Id);
            await _unitOfWork.CommitAsync();

            var updatedCertification = await _unitOfWork.Repository<Certification>().GetAll()
                .Include(c => c.User)
                .Include(c => c.Pet)
                    .ThenInclude(p => p.Shelter)
                .Include(c => c.Pet.Statuses)
                    .ThenInclude(ps => ps.Status)
                .FirstOrDefaultAsync(c => c.Id == existingCertification.Id);

            if (updatedCertification == null)
            {
                throw new ApplicationException("Có lỗi xảy ra khi truy xuất chứng nhận đã cập nhật.");
            }

            var response = new CertificationResponseDetail
            {
                Id = updatedCertification.Id,
                Image = updatedCertification.Image,
                Description = updatedCertification.Desciption,
                Date = updatedCertification.Date,
                ShelterStaffID = updatedCertification.UserId,
                PetId = updatedCertification.PetId,
                User = updatedCertification.User != null ? new UsersResponseModel
                {
                    Id = updatedCertification.UserId,
                    Username = updatedCertification.User.Username,
                    Email = updatedCertification.User.Email,
                    Location = updatedCertification.User.Location,
                    Phone = updatedCertification.User.Phone
                } : null!,
                ShelterStaff = updatedCertification.ShelterStaff != null ? new UsersResponseModel
                {
                    Id = updatedCertification.ShelterStaff.Id,
                    Username = updatedCertification.ShelterStaff.Username,
                    Email = updatedCertification.ShelterStaff.Email,
                    Location = updatedCertification.ShelterStaff.Location,
                    Phone = updatedCertification.ShelterStaff.Phone,
                    //TotalDonation = (decimal)updatedCertification.User.TotalDonation,
                } : null!,
                Pet = updatedCertification.Pet != null ? new PetDetailResponse
                {
                    PetID = updatedCertification.Pet.Id,
                    Name = updatedCertification.Pet.Name,
                    Type = updatedCertification.Pet.Type,
                    Breed = updatedCertification.Pet.Breed,
                    Gender = updatedCertification.Pet.Gender,
                    Age = updatedCertification.Pet.Age ?? 0,
                    Size = updatedCertification.Pet.Size,
                    Color = updatedCertification.Pet.Color,
                    AdoptionStatus = updatedCertification.Pet.AdoptionStatus,
                    Image = updatedCertification.Pet.Image,
                    ShelterID = updatedCertification.Pet.ShelterID,
                    UserID = updatedCertification.Pet.UserID ?? 0,
                    Description = updatedCertification.Pet.Description,
                    Statuses = updatedCertification.Pet.Statuses?.Select(s => new StatusResponseModel
                    {
                        StatusId = s.StatusId,
                        Disease = s.Status?.Disease,
                        Vaccine = s.Status?.Vaccine
                    }).ToList(), // Trả về danh sách Status
                    ShelterName = updatedCertification.Pet.Shelter?.Name
                } : null!
            };

            return response;
        }


        // Xóa Certification
        public async Task DeleteCertificateAsync(int id)
        {
            var certification = await _unitOfWork.Repository<Certification>().GetById(id);
            if (certification == null)
            {
                throw new KeyNotFoundException($"Certification with ID {id} not found.");
            }

            _unitOfWork.Repository<Certification>().Delete(certification);
            await _unitOfWork.CommitAsync();
        }

        // Kiểm tra Certification tồn tại
        public async Task<bool> CertificationExistsAsync(int id)
        {
            var certification = await _unitOfWork.Repository<Certification>().GetById(id);
            return certification != null;
        }

        // Lấy chứng nhận theo UserId
        public async Task<IEnumerable<CertificationResponseDetail>> GetCertificationByUserIdAsync(int userId)
        {
            if (userId <= 0) { throw new ArgumentException("UserId phải lớn hơn 0.", nameof(userId)); }

            var certifications = await _unitOfWork.Repository<Certification>().GetAll()
                .Include(c => c.User)
                .Include(c => c.Pet)
                    .ThenInclude(p => p.Shelter)
                .Include(c => c.Pet.Statuses)
                    .ThenInclude(ps => ps.Status)
                .Include(c => c.ShelterStaff)
                .Where(c => c.UserId == userId)
                .ToListAsync();
            // Lấy danh sách roles của User
            var roles = await _userRoleService.GetRolesOfUserAsync(userId);

            if (!certifications.Any())
            {
                throw new KeyNotFoundException($"Không tìm thấy CertificateID nào cho UserId {userId}.");
            }

            // Chuẩn bị response
            var response = certifications.Select(c => new CertificationResponseDetail
            {
                Id = c.Id,
                Image = c.Image,
                Description = c.Desciption,
                Date = c.Date,
                UserId = c.UserId,
                ShelterStaffID = c.UserId,
                PetId = c.PetId,
                User = c.User != null ? new UsersResponseModel
                {
                    Id = c.UserId,
                    Username = c.User.Username,
                    Email = c.User.Email,
                    Location = c.User.Location,
                    Phone = c.User.Phone,
                    Roles = roles.ToList()
                } : null!,
                ShelterStaff = c.ShelterStaff != null ? new UsersResponseModel
                {
                    Id = c.ShelterStaff.Id,
                    Username = c.ShelterStaff.Username,
                    Email = c.ShelterStaff.Email,
                    Location = c.ShelterStaff.Location,
                    Phone = c.ShelterStaff.Phone,
                    //TotalDonation = (decimal)c.User.TotalDonation,
                } : null!,
                Pet = c.Pet != null ? new PetDetailResponse
                {
                    PetID = c.Pet.Id,
                    Name = c.Pet.Name,
                    Type = c.Pet.Type,
                    Breed = c.Pet.Breed,
                    Gender = c.Pet.Gender,
                    Age = c.Pet.Age ?? 0,
                    Size = c.Pet.Size,
                    Color = c.Pet.Color,
                    AdoptionStatus = c.Pet.AdoptionStatus,
                    Image = c.Pet.Image,
                    ShelterID = c.Pet.ShelterID,
                    UserID = c.Pet.UserID ?? 0,
                    Description = c.Pet.Description,
                    Statuses = c.Pet.Statuses?.Select(ps => new StatusResponseModel
                    {
                        StatusId = ps.StatusId,
                        Disease = ps.Status?.Disease,
                        Vaccine = ps.Status?.Vaccine
                    }).ToList(),
                    ShelterName = c.Pet.Shelter?.Name
                } : null!
            });
            return response;
        }
    }

}