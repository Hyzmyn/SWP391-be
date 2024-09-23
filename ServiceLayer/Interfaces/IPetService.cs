using ModelLayer.Entities;

namespace ServiceLayer.Interfaces
{
    public interface IPetService
    {
        Task CreatePetAsync(Pet pet);
        Task DeletePetAsync(int id);
        Task<Pet> GetPetById(int id);
        IEnumerable<Pet> GetPets();
        Task UpdatePetAsync(Pet pet);
        Task UpdatePetStatus(Pet pet);
    }
}