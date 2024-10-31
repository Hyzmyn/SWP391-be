using ModelLayer.Entities;
using RepositoryLayer.UnitOfWork;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.RequestModels;
using System.Net;
using ServiceLayer.ResponseModels;
using Microsoft.AspNetCore.Http.HttpResults;
using ModelLayer.Enum;

namespace ServiceLayer.Services
{
    public class PetService : IPetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PawFundContext _content;
        private readonly IFileUploadService _fileUploadService;
        private readonly IStatusPetService _statusPetService;  

        public PetService(IUnitOfWork unitOfWork, IFileUploadService fileUploadService, IStatusPetService statusPetService)
        {
            _unitOfWork = unitOfWork;
            _fileUploadService = fileUploadService;
            _statusPetService = statusPetService;
        }

        // Lấy tất cả các Pet
        public async Task<IEnumerable<PetResponseModel>> GetAllPetsAsync()
        {
            var pets = await _unitOfWork.Repository<Pet>()
                .AsQueryable()
                .Include(p => p.Statuses)
                    .ThenInclude(ps => ps.Status)
                .ToListAsync();

            var petResponses = new List<PetResponseModel>();

            foreach (var pet in pets)
            {
                var petResponse = new PetResponseModel
                {
                    PetID = pet.Id,
                    ShelterID = pet.ShelterID,
                    UserID = pet.UserID,
                    Name = pet.Name,
                    Type = pet.Type,
                    Breed = pet.Breed,
                    Gender = pet.Gender,
                    Age = pet.Age,
                    Size = pet.Size,
                    Color = pet.Color,
                    Description = pet.Description,
                    AdoptionStatus = pet.AdoptionStatus,
                    Image = pet.Image,
                    Statuses = pet.Statuses?.Select(ps => new StatusResponseModel
                    {
                        StatusId = ps.Status.Id,
                        Disease = ps.Status.Disease,
                        Vaccine = ps.Status.Vaccine,
                        Date=ps.Status.Date
                    }).ToList()
                };

                petResponses.Add(petResponse);
            }

            return petResponses;
        }


        // Lấy Pet theo ID
        public async Task<PetResponseModel> GetPetByIdAsync(int id)
        {
            var pet = await _unitOfWork.Repository<Pet>()
                .AsQueryable()
                .Include(p => p.Statuses)
                    .ThenInclude(ps => ps.Status)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pet == null)
                throw new Exception($"Không tìm thấy Pet với ID {id}.");

            var petResponse = new PetResponseModel
            {
                PetID = pet.Id,
                ShelterID = pet.ShelterID,
                UserID = pet.UserID,
                Name = pet.Name,
                Type = pet.Type,
                Breed = pet.Breed,
                Gender = pet.Gender,
                Age = pet.Age,
                Size = pet.Size,
                Color = pet.Color,
                Description = pet.Description,
                AdoptionStatus = pet.AdoptionStatus,
                Image = pet.Image,
                Statuses = pet.Statuses?.Select(ps => new StatusResponseModel
                {
                    StatusId = ps.Status.Id,
                    Date = ps.Status.Date,
                    Disease = ps.Status.Disease,
                    Vaccine = ps.Status.Vaccine
                }).ToList()
            };

            return petResponse;
        }

        // Tạo mới Pet
        public async Task<PetResponseModel> CreatePetAsync(PetCreateRequestModel createPetRequest)
        {
            string userImage = null;

            if (createPetRequest.Image != null && createPetRequest.Image.Length > 0)
            {
                userImage = await _fileUploadService.UploadFileAsync(createPetRequest.Image);
            }
            var pet = new Pet
            {
                ShelterID = createPetRequest.ShelterID,
                UserID = createPetRequest.UserID,
                Name = createPetRequest.Name,
                Type = createPetRequest.Type,
                Breed = createPetRequest.Breed,
                Gender = createPetRequest.Gender,
                Age = createPetRequest.Age,
                Size = createPetRequest.Size,
                Color = createPetRequest.Color,
                Description = createPetRequest.Description,
                AdoptionStatus = createPetRequest.AdoptionStatus,
                Image = userImage
            };

            await _unitOfWork.Repository<Pet>().InsertAsync(pet);
            await _unitOfWork.CommitAsync();

            return await GetPetByIdAsync(pet.Id);
        }


        // Cập nhật Pet
        public async Task<PetResponseModel> UpdatePetAsync(int id, PetUpdateRequestModel updatePetRequest)
        {
            var existingPet = await _unitOfWork.Repository<Pet>().GetById(id);

            var Pet = await GetPetByIdAsync(id);
            if(Pet == null)
            {
                throw new Exception($"Không tìm thấy Pet với ID {id}.");
            }

            if (updatePetRequest.Image != null && updatePetRequest.Image.Length>0)
            {
                string userImage = await _fileUploadService.UploadFileAsync(updatePetRequest.Image);
                existingPet.Image = userImage;

            }
            if (existingPet == null)
                throw new Exception($"Không tìm thấy Pet với ID {id}.");

            existingPet.ShelterID = updatePetRequest.ShelterID;
            existingPet.UserID = updatePetRequest.UserID;
            existingPet.Name = updatePetRequest.Name;
            existingPet.Type = updatePetRequest.Type;
            existingPet.Breed = updatePetRequest.Breed;
            existingPet.Gender = updatePetRequest.Gender;
            existingPet.Age = updatePetRequest.Age;
            existingPet.Size = updatePetRequest.Size;
            existingPet.Color = updatePetRequest.Color;
            existingPet.Description = updatePetRequest.Description;
            existingPet.AdoptionStatus = updatePetRequest.AdoptionStatus;

            _unitOfWork.Repository<Pet>().Update(existingPet, id);
            await _unitOfWork.CommitAsync();

            return await GetPetByIdAsync(id);
        }

        // Xóa Pet và các Status liên quan
        public async Task<bool> DeletePetAsync(int id)
        {
            // Tìm Pet theo ID
            var pet = await _unitOfWork.Repository<Pet>().AsQueryable()
                .Include(p => p.Statuses) 
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pet == null)
                throw new Exception($"Không tìm thấy Pet với ID {id}.");

            // Xóa từng Status liên quan đến Pet
            if (pet.Statuses != null && pet.Statuses.Any())
            {
                foreach (var petStatus in pet.Statuses)
                {
                    if (petStatus.StatusId != null)
                    {
                        await _statusPetService.DeleteStatusAsync(petStatus.StatusId);
                    }
                }
            }
            _unitOfWork.Repository<Pet>().Delete(pet);
            await _unitOfWork.CommitAsync();

            return true;
        }


        // Cập nhật Status của Pet
        public async Task UpdatePetStatusAsync(int petId, int statusId, StatusUpdateRequestModel updateStatusRequest)
        {
            var petStatus = await _unitOfWork.Repository<PetStatus>()
                .AsQueryable()
                .Include(ps => ps.Status)
                .FirstOrDefaultAsync(ps => ps.PetId == petId && ps.StatusId == statusId);

            var vietnamTime = updateStatusRequest.Date.ToOffset(TimeSpan.FromHours(7)).DateTime;

            if (petStatus == null)
                throw new Exception($"Không tìm thấy Status với ID {statusId} cho Pet với ID {petId}.");

            petStatus.Status.Disease = updateStatusRequest.Disease;
            petStatus.Status.Vaccine = updateStatusRequest.Vaccine;
            petStatus.Status.Date = vietnamTime;

            _unitOfWork.Repository<Status>().Update(petStatus.Status, petStatus.StatusId);
            await _unitOfWork.CommitAsync();
        }

        // Thêm Status vào Pet
        public async Task AddStatusToPetAsync(int petId, CreatePetStatusRequest createPetStatusRequest)
        {
            var pet = await _unitOfWork.Repository<Pet>()
                .AsQueryable()
                .Include(p => p.Statuses)
                    .ThenInclude(sp => sp.Status)
                .FirstOrDefaultAsync(p => p.Id == petId);

            if (pet == null)
                throw new Exception($"Không tìm thấy Pet với ID {petId}.");

            // Kiểm tra xem Status đã tồn tại cho Pet này chưa
            if (pet.Statuses.Any(ps => ps.StatusId == createPetStatusRequest.StatusId))
                throw new Exception($"Status với ID {createPetStatusRequest.StatusId} đã tồn tại cho Pet với ID {petId}.");

            var petStatus = new PetStatus
            {
                PetId = petId,
                StatusId = createPetStatusRequest.StatusId
            };

            await _unitOfWork.Repository<PetStatus>().InsertAsync(petStatus);
            await _unitOfWork.CommitAsync();
        }



        // Xóa Status khỏi Pet và xóa Status nếu không còn liên kết với Pet nào
        public async Task RemoveStatusFromPetAsync(int petId, int statusId)
        {
            var petStatusRepository = _unitOfWork.Repository<PetStatus>();
            var statusRepository = _unitOfWork.Repository<Status>();

            // Tìm PetStatus với PetId và StatusId
            var petStatus = await petStatusRepository
                .AsQueryable()
                .FirstOrDefaultAsync(ps => ps.PetId == petId && ps.StatusId == statusId);

            if (petStatus == null)
                throw new Exception($"Không tìm thấy Status với ID {statusId} cho Pet với ID {petId}.");

            // Xóa mối quan hệ giữa Pet và Status
            petStatusRepository.Delete(petStatus);
            await _unitOfWork.CommitAsync();

            // Kiểm tra xem Status có còn được tham chiếu bởi bất kỳ Pet nào không
            var isStatusInUse = await petStatusRepository
                .AsQueryable()
                .AnyAsync(ps => ps.StatusId == statusId);

            //Xóa Status khỏi bảng Status
            if (!isStatusInUse)
            {
                var status = await statusRepository
                    .AsQueryable()
                    .FirstOrDefaultAsync(s => s.Id == statusId);

                if (status != null)
                {
                    statusRepository.Delete(status);
                    await _unitOfWork.CommitAsync();
                }
            }
        }


        //Cập nhật AdopStatus cho Pet theo Enum (1 = Available , 2 = Adopte ,3 = Unavalable)
        public async Task UpdatePetAdoptionStatusAsync(int id, int status, int? userId)
        {
            var existingPet = await _unitOfWork.Repository<Pet>().GetById(id);
            if (existingPet == null)
                throw new Exception($"Pet with ID {id} not found.");

            // Validate and convert the integer status to enum
            if (Enum.IsDefined(typeof(AdoptionStatus), status))
            {
                existingPet.AdoptionStatus = ((AdoptionStatus)status).ToString();
            }
            else
            {
                throw new Exception($"Invalid status value: {status}. Must be 1 (Available), 2 (Adopted), or 3(Unavailable) .");
            }

            existingPet.UserID = userId;

            await _unitOfWork.Repository<Pet>().Update(existingPet, id);
            await _unitOfWork.CommitAsync();
            
        }

        public async Task<PetResponseModel> PutUserIDAsync(int petId, int? userId)
        {
            var existingPet = await _unitOfWork.Repository<Pet>().GetById(petId);
            if (existingPet == null)
            {
                throw new Exception($"Không tìm thấy Pet với ID {petId}.");
            }

            existingPet.UserID = userId;

            // Kiểm tra trạng thái hiện tại và cập nhật AdoptionStatus
            if (userId != null && existingPet.AdoptionStatus == AdoptionStatus.Available.ToString())
            {
                // Nếu Pet đang Available và User được gán, chuyển sang Adopted
                existingPet.AdoptionStatus = AdoptionStatus.Adopted.ToString();
            }
            else if (userId == null && existingPet.AdoptionStatus == AdoptionStatus.Adopted.ToString())
            {
                // Nếu UserID được bỏ và Pet đang Adopted, chuyển trạng thái về Available
                existingPet.AdoptionStatus = AdoptionStatus.Available.ToString();
            }

            _unitOfWork.Repository<Pet>().Update(existingPet, petId);
            await _unitOfWork.CommitAsync();

            return await GetPetByIdAsync(petId);
        }


    }
}
