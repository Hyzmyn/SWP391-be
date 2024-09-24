using ModelLayer.Entities;

namespace ServiceLayer.Interfaces
{
    public interface IDonateService
    {
        Task CreateDonationAsync(Donation donation);
        Task DeleteDonationAsync(int id);
        IEnumerable<Donation> GetAllDonations();
        Task<Donation> GetDonationById(int id);
        decimal GetTotalDonationByDonor(int donorId);
        decimal GetTotalDonationByShelter(int shelterId);
        Task UpdateDonationAsync(Donation donation);
    }
}