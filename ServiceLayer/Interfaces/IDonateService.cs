using ModelLayer.Entities;

namespace ServiceLayer.Services
{
    public interface IDonateService
    {
        Task CreateDonationAsync(Donation donation);
        Task DeleteDonationAsync(int id);
        IEnumerable<Donation> GetAllDonations();
        Task<Donation> GetDonationsByIdAsync(int id);
        decimal GetTotalDonationByDonor(int donorId);
        decimal GetTotalDonationByShelter(int shelterId);
        Task UpdateDonationAsync(Donation donation);
        Task<IEnumerable<Donation>> GetDonationsByDonorId(int donorId);
		Task UpdateDonationStatusAsync(int donationId, bool status);
	}
}