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

        public async Task UpdatePetStatus(Pet pet)
        {
            var check = await _content.Pets.Include(x => x.Status).FirstOrDefaultAsync(x => x.Id == pet.Id);

            await _unitOfWork.Repository<Pet>().Update(pet, pet.Id);
            await _unitOfWork.CommitAsync();
        }
    }
}
