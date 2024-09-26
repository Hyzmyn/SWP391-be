using ModelLayer.Entities;

namespace ServiceLayer.Interfaces
{
    public interface IAdoptionRegistrationFormService
    {
        Task CreateAdoptionFormAsync(AdoptionRegistrationForm form);
        Task DeleteAdoptionFormAsync(int id);
        Task<bool> FormExistsAsync(int id);
        Task<AdoptionRegistrationForm> GetAdoptionFormByIdAsync(int id);
        IEnumerable<AdoptionRegistrationForm> GetAllAdoptionForms();
        Task UpdateAdoptionFormAsync(AdoptionRegistrationForm form);
    }
}