using ModelLayer.Entities;

namespace ServiceLayer.Interfaces
{
    public interface IShelterService
    {
        Task<IEnumerable<Shelter>> GetAllSheltersAsync();
        Task<Shelter?> GetShelterByIdAsync(int shelterId);
        Task<Shelter?> GetShelterByUserIdAsync(int userId);
        Task<Shelter> CreateShelterAsync(Shelter shelter);
        Task<Shelter> UpdateShelterAsync(Shelter shelter);
        Task<bool> DeleteShelterAsync(int shelterId);
    }
}