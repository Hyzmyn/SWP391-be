using ModelLayer.Entities;
using RepositoryLayer.UnitOfWork;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class PetService : IPetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PawFundContext _content;
        public PetService(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

        public IEnumerable<Pet> GetPets()
        {
            return _unitOfWork.Repository<Pet>().GetAll();

        }

        public async Task<Pet> GetPetById(int id)
        {
            return await _unitOfWork.Repository<Pet>().GetById(id);
        }

        public async Task CreatePetAsync(Pet pet)
        {
            await _unitOfWork.Repository<Pet>().InsertAsync(pet);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdatePetAsync(Pet pet)
        {
            await _unitOfWork.Repository<Pet>().Update(pet, pet.Id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeletePetAsync(int id)
        {
            var pet = await _unitOfWork.Repository<Pet>().GetById(id);
            if (pet != null)
            {
                _unitOfWork.Repository<Pet>().Delete(pet);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task UpdatePetStatus(Pet pet, int newStatusId)
        {
            // Lấy Pet từ database theo ID
            var existingPet = await _unitOfWork.Repository<Pet>().GetById(pet.Id);

            if (existingPet != null)
            {
                // Cập nhật StatusId mới

                // Nếu cần cập nhật trạng thái liên quan khác, có thể thêm ở đây
                // Ví dụ cập nhật AdoptionStatus
                if (newStatusId == 1) // Ví dụ: 1 là trạng thái "Available for Adoption"
                {
                    existingPet.AdoptionStatus = "Available";
                }
                else if (newStatusId == 2) // Ví dụ: 2 là trạng thái "Adopted"
                {
                    existingPet.AdoptionStatus = "Adopted";
                }
                await _unitOfWork.Repository<Pet>().Update(existingPet, existingPet.Id);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                throw new Exception($"Pet with ID {pet.Id} not found.");
            }
        }

    }
}
