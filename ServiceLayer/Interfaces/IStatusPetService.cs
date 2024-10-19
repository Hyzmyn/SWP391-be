using ModelLayer.Entities;
using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;

namespace ServiceLayer.Interfaces
{
    public interface IStatusPetService
    {
        Task<IEnumerable<StatusResponseModel>> GetAllStatusAsync();
        Task<IEnumerable<StatusResponseModel>> GetStatusesForPetAsync(int petId);
        Task<StatusResponseModel> GetStatusByIdAsync(int id);
        Task<StatusResponseModel> CreateStatusAsync(StatusCreateRequest createStatusRequest);
        Task<StatusResponseModel> UpdateStatusAsync(int id, StatusUpdateRequestModel updateStatusRequest);
        Task<bool> DeleteStatusAsync(int id);
    }
}