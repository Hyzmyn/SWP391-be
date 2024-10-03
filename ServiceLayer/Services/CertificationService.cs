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

namespace ServiceLayer.Services
{
    public class CertificationService : ICertificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPetService _petService;

        public CertificationService(IUnitOfWork unitOfWork, IPetService petService)
        {
            _unitOfWork = unitOfWork;
            _petService = petService;
        }

        // Services/CertificationService.cs
        public IEnumerable<CertificationResponseDetail> GetAllCertificates()
        {
            var certifications = _unitOfWork.Repository<Certification>().GetAll()
                .Include(c => c.User) 
                .Include(c => c.Pet)
                .ThenInclude(p => p.Shelter); 

            var response = certifications.Select(c => new CertificationResponseDetail
            {
                Id = c.Id,
                Image = c.Image,
                Description = c.Desciption,
                Date = c.Date,
                ShelterStaffID = c.UserId,
                PetId = c.PetId,
                //ShelterStaff = c.User != null ? new UsersResponseModel
                //{
                //    Id = c.User.Id,
                //    Username = c.User.Username,
                //    Email = c.User.Email,
                //    Location = c.User.Location,
                //    Phone = c.User.Phone,
                //    TotalDonation = c.User.TotalDonation,
                //    // RatingCount = c.User.RatingCount // Nếu cần
                //} : null!,
                Pet = c.Pet != null ? new PetDetailResponse
                {
                    Id = c.Pet.Id,
                    Name = c.Pet.Name,
                    Type = c.Pet.Type,
                    Breed = c.Pet.Breed,
                    Gender = c.Pet.Gender,
                    Age = (int)c.Pet.Age,
                    Size = c.Pet.Size,
                    Color = c.Pet.Color,
                    AdoptionStatus = c.Pet.AdoptionStatus,
                    Image = c.Pet.Image,
                    ShelterID = c.Pet.ShelterID,
                    UserID = (int)c.Pet.UserID,
                    Description = c.Pet.Description,
                    StatusId =(int) c.Pet.StatusId,
                    ShelterName = c.Pet.Shelter != null ? c.Pet.Shelter.Name : null
                } : null!
            });

            return response;
        }


        // Lấy Certification theo ID
        public async Task<CertificationResponseDetail> GetCertificateByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be greater than zero.", nameof(id));
            }

            var certification = await _unitOfWork.Repository<Certification>().GetAll()
                .Include(c => c.User)
                .Include(c => c.Pet)
                    .ThenInclude(p => p.Shelter)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (certification == null)
            {
                throw new KeyNotFoundException($"Certification with ID {id} not found.");
            }

            var response = new CertificationResponseDetail
            {
                Id = certification.Id,
                Image = certification.Image,
                Description = certification.Desciption,
                Date = certification.Date,
                ShelterStaffID = certification.UserId,
                PetId = certification.PetId,
                //ShelterStaff = certification.User != null ? new UserDetailResponse
                //{
                //    Id = certification.User.Id,
                //    Username = certification.User.Username,
                //    Email = certification.User.Email,
                //    Location = certification.User.Location,
                //    Phone = certification.User.Phone,
                //    TotalDonation = certification.User.TotalDonation,
                //    RatingCount = certification.User.RatingCount
                //} : null!,
                Pet = certification.Pet != null ? new PetDetailResponse
                {
                    Id = certification.Pet.Id,
                    Name = certification.Pet.Name,
                    Type = certification.Pet.Type,
                    Breed = certification.Pet.Breed,
                    Gender = certification.Pet.Gender,
                    Age =(int) certification.Pet.Age,
                    Size = certification.Pet.Size,
                    Color = certification.Pet.Color,
                    AdoptionStatus = certification.Pet.AdoptionStatus,
                    Image = certification.Pet.Image,
                    ShelterID = certification.Pet.ShelterID,
                    UserID = (int)certification.Pet.UserID,
                    Description = certification.Pet.Description,
                    StatusId = (int)certification.Pet.StatusId,
                    ShelterName = certification.Pet.Shelter != null ? certification.Pet.Shelter.Name : null
                } : null!
            };

            return response;
        }

        // Tạo mới Certification
        public async Task<CertificationResponseDetail> CreateCertificateAsync(CertificationRequest request)
        {
            // Kiểm tra sự tồn tại của User (ShelterStaff)
            var shelterStaff = await _unitOfWork.Repository<User>().GetById(request.ShelterStaffId);
            if (shelterStaff == null)
            {
                throw new KeyNotFoundException($"ShelterStaff with ID {request.ShelterStaffId} not found.");
            }

            // Kiểm tra sự tồn tại của Pet
            var pet = await _unitOfWork.Repository<Pet>().GetById(request.PetId);
            if (pet == null)
            {
                throw new KeyNotFoundException($"Pet with ID {request.PetId} not found.");
            }

            var certification = new Certification
            {
                Image = request.Image,
                Desciption = request.Description,
                Date = DateTime.UtcNow,
                UserId = request.ShelterStaffId,
                PetId = request.PetId
            };

            await _unitOfWork.Repository<Certification>().InsertAsync(certification);
            await _unitOfWork.CommitAsync();

            var createdCertification = await _unitOfWork.Repository<Certification>().GetAll()
                .Include(c => c.User)
                .Include(c => c.Pet)
                    .ThenInclude(p => p.Shelter)
                .FirstOrDefaultAsync(c => c.Id == certification.Id);

            if (createdCertification == null)
            {
                throw new ApplicationException("An error occurred while retrieving the created certification.");
            }

            var response = new CertificationResponseDetail
            {
                Id = createdCertification.Id,
                Image = createdCertification.Image,
                Description = createdCertification.Desciption,
                Date = createdCertification.Date,
                ShelterStaffID = createdCertification.UserId,
                PetId = createdCertification.PetId,
                //ShelterStaff = createdCertification.User != null ? new UserDetailResponse
                //{
                //    Id = createdCertification.User.Id,
                //    Username = createdCertification.User.Username,
                //    Email = createdCertification.User.Email,
                //    Location = createdCertification.User.Location,
                //    Phone = createdCertification.User.Phone,
                //    TotalDonation = createdCertification.User.TotalDonation,
                //    RatingCount = createdCertification.User.RatingCount
                //} : null!,
                Pet = createdCertification.Pet != null ? new PetDetailResponse
                {
                    Id = createdCertification.Pet.Id,
                    Name = createdCertification.Pet.Name,
                    Type = createdCertification.Pet.Type,
                    Breed = createdCertification.Pet.Breed,
                    Gender = createdCertification.Pet.Gender,
                    Age = (int)createdCertification.Pet.Age,
                    Size = createdCertification.Pet.Size,
                    Color = createdCertification.Pet.Color,
                    AdoptionStatus = createdCertification.Pet.AdoptionStatus,
                    Image = createdCertification.Pet.Image,
                    ShelterID = createdCertification.Pet.ShelterID,
                    UserID =(int) createdCertification.Pet.UserID,
                    Description = createdCertification.Pet.Description,
                    StatusId =(int) createdCertification.Pet.StatusId,
                    ShelterName = createdCertification.Pet.Shelter != null ? createdCertification.Pet.Shelter.Name : null
                } : null!
            };

            return response;
        }

        // Cập nhật Certification
        public async Task<CertificationResponseDetail> UpdateCertificateAsync(int id, CertificationRequest request)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be greater than zero.", nameof(id));
            }

            var existingCertification = await _unitOfWork.Repository<Certification>().GetById(id);
            if (existingCertification == null)
            {
                throw new KeyNotFoundException($"Certification with ID {id} not found.");
            }

            var shelterStaff = await _unitOfWork.Repository<User>().GetById(request.ShelterStaffId);
            if (shelterStaff == null)
            {
                throw new KeyNotFoundException($"ShelterStaff with ID {request.ShelterStaffId} not found.");
            }

            var pet = await _unitOfWork.Repository<Pet>().GetById(request.PetId);
            if (pet == null)
            {
                throw new KeyNotFoundException($"Pet with ID {request.PetId} not found.");
            }

            existingCertification.Image = request.Image;
            existingCertification.Desciption = request.Description;
            existingCertification.Date = DateTime.UtcNow;
            existingCertification.UserId = request.ShelterStaffId;
            existingCertification.PetId = request.PetId;

            await _unitOfWork.Repository<Certification>().Update(existingCertification, existingCertification.Id);
            await _unitOfWork.CommitAsync();

            // Lấy lại Certification vừa cập nhật để trả về response chi tiết
            var updatedCertification = await _unitOfWork.Repository<Certification>().GetAll()
                .Include(c => c.User)
                .Include(c => c.Pet)
                    .ThenInclude(p => p.Shelter)
                .FirstOrDefaultAsync(c => c.Id == existingCertification.Id);

            if (updatedCertification == null)
            {
                throw new ApplicationException("An error occurred while retrieving the updated certification.");
            }

            var response = new CertificationResponseDetail
            {
                Id = updatedCertification.Id,
                Image = updatedCertification.Image,
                Description = updatedCertification.Desciption,
                Date = updatedCertification.Date,
                ShelterStaffID = updatedCertification.UserId,
                PetId = updatedCertification.PetId,
                //ShelterStaff = updatedCertification.User != null ? new UserDetailResponse
                //{
                //    Id = updatedCertification.User.Id,
                //    Username = updatedCertification.User.Username,
                //    Email = updatedCertification.User.Email,
                //    Location = updatedCertification.User.Location,
                //    Phone = updatedCertification.User.Phone,
                //    TotalDonation = updatedCertification.User.TotalDonation,
                //    RatingCount = updatedCertification.User.RatingCount
                //} : null!,
                Pet = updatedCertification.Pet != null ? new PetDetailResponse
                {
                    Id = updatedCertification.Pet.Id,
                    Name = updatedCertification.Pet.Name,
                    Type = updatedCertification.Pet.Type,
                    Breed = updatedCertification.Pet.Breed,
                    Gender = updatedCertification.Pet.Gender,
                    Age =(int) updatedCertification.Pet.Age,
                    Size = updatedCertification.Pet.Size,
                    Color = updatedCertification.Pet.Color,
                    AdoptionStatus = updatedCertification.Pet.AdoptionStatus,
                    Image = updatedCertification.Pet.Image,
                    ShelterID = updatedCertification.Pet.ShelterID,
                    UserID = (int)  updatedCertification.Pet.UserID,
                    Description = updatedCertification.Pet.Description,
                    StatusId = (int)updatedCertification.Pet.StatusId,
                    ShelterName = updatedCertification.Pet.Shelter != null ? updatedCertification.Pet.Shelter.Name : null
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
    }

}