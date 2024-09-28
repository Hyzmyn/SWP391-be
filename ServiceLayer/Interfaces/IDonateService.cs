﻿using ModelLayer.Entities;

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
        IEnumerable<Donation> GetDonationsByDonorId(int donorId);
    }
}