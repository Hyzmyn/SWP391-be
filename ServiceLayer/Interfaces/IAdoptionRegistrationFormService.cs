using ModelLayer.Entities;

namespace ServiceLayer.Interfaces
{
    public interface IAdoptionRegistrationFormService
    {
        Task CreateAdoptionFormAsync(AdoptionRegistrationForm form);
        Task DeleteAdoptionFormAsync(int id);
        Task<bool> FormExistsAsync(int petid);
        Task<AdoptionRegistrationForm> GetAdoptionFormByIdAsync(int id);
        IEnumerable<AdoptionRegistrationForm> GetAllAdoptionForms();
        Task<IEnumerable<AdoptionRegistrationForm>> GetFormsByPetId(int petid);
        Task UpdateAdoptionFormAsync(AdoptionRegistrationForm form);
    }
}