using ModelLayer.Entities;
using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;
using System.Net;

namespace ServiceLayer.Interfaces
{
    public interface IPetService
    {
        Task<IEnumerable<PetResponseModel>> GetAllPetsAsync();
        Task<PetResponseModel> GetPetByIdAsync(int id);
        Task<PetResponseModel> CreatePetAsync(PetCreateRequestModel createPetRequest);
        Task<PetResponseModel> UpdatePetAsync(int id, PetUpdateRequestModel updatePetRequest);
        Task<bool> DeletePetAsync(int id);
        Task AddStatusToPetAsync(int petId, CreatePetStatusRequest createPetStatusRequest);
        Task UpdatePetStatusAsync(int petId, int statusId, StatusUpdateRequestModel updateStatusRequest);
        Task RemoveStatusFromPetAsync(int petId, int statusId);
        Task UpdatePetAdoptionStatusAsync(int id, int status, int? userId);
    }
}