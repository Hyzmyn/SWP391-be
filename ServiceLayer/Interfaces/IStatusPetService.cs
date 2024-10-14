using ModelLayer.Entities;

namespace ServiceLayer.Interfaces
{
    public interface IStatusPetService
    {
        Task CreateStatusAsync(Status status);
        Task DeleteStatusAsync(int id);
        Task<Status> GetStatusByIdAsync(int id);
        //IEnumerable<Status> GetStatusesForPet(int petId);
        Task UpdateStatusAsync(Status status);
    }
}