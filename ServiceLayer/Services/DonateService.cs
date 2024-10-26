using Microsoft.EntityFrameworkCore;
using ModelLayer.Entities;
using RepositoryLayer.UnitOfWork;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class DonateService : IDonateService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DonateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Lấy danh sách tất cả các donation
        public IEnumerable<Donation> GetAllDonations()
        {
            return _unitOfWork.Repository<Donation>().GetAll()
                 .Include(d => d.User)
                 .Include(d => d.Shelter)
                 .ToList();
        }

        // Lấy danh sách các donation theo danh sách IDs
        public async Task<Donation> GetDonationsByIdAsync(int id)
        {
            if (id == null)
            {
                throw new ArgumentException("Id annot be null or empty.", nameof(id));
            }

            try
            {
                return await _unitOfWork.Repository<Donation>().GetAll()
                    .Include(d => d.User)
                    .Include(d => d.Shelter)
                    .FirstOrDefaultAsync(d => d.Id == id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving donations.", ex);
            }
        }


        // Thêm donation mới và cập nhật Shelter và User
        public async Task CreateDonationAsync(Donation donation)
        {
			using (var transaction = await _unitOfWork.BeginTransactionAsync())
			{
				try
				{
					// Set initial status to false
					donation.Status = false;

					// Thêm Donation
					await _unitOfWork.Repository<Donation>().InsertAsync(donation);

					// Lấy User và Shelter từ database
					var donor = await _unitOfWork.Repository<User>().GetById(donation.DonorId);
					var shelter = await _unitOfWork.Repository<Shelter>().GetById(donation.ShelterId);

					if (donor == null)
					{
						throw new ArgumentException("Donor not found.", nameof(donation.DonorId));
					}

					if (shelter == null)
					{
						throw new ArgumentException("Shelter not found.", nameof(donation.ShelterId));
					}

					// Cập nhật TotalDonation của User
					donor.TotalDonation = (donor.TotalDonation ?? 0m) + donation.Amount;
					_unitOfWork.Repository<User>().Update(donor, donor.Id);

					// Cập nhật DonationAmount của Shelter
					shelter.DonationAmount = (shelter.DonationAmount ?? 0m) + donation.Amount;
					_unitOfWork.Repository<Shelter>().Update(shelter, shelter.Id);

					await _unitOfWork.CommitAsync();
					await transaction.CommitAsync();
				}
				catch (Exception)
				{
					await transaction.RollbackAsync();
					throw;
				}
			}
		}

        // Cập nhật donation
        public async Task UpdateDonationAsync(Donation donation)
        {
            await _unitOfWork.Repository<Donation>().Update(donation, donation.Id);
            await _unitOfWork.CommitAsync();
        }

        // Xóa donation theo Id
        public async Task DeleteDonationAsync(int id)
        {
            var donation = await _unitOfWork.Repository<Donation>().GetById(id);
            if (donation != null)
            {
                _unitOfWork.Repository<Donation>().Delete(donation);
                await _unitOfWork.CommitAsync();
            }
        }

        // Lấy tổng donation theo ShelterId

        public decimal GetTotalDonationByShelter(int shelterId)
        {
            return _unitOfWork.Repository<Donation>()
                .AsQueryable()
                .Where(d => d.ShelterId == shelterId && d.Status == true)
                // Chỉ lấy các Donation có Status là true
                .Sum(d => d.Amount);
        }

        // Lấy tổng donation theo DonorId (accountId)
        public decimal GetTotalDonationByDonor(int donorId)
        {
            return _unitOfWork.Repository<Donation>()
                .AsQueryable()
                .Where(d => d.DonorId == donorId)
                .Sum(d => d.Amount);
        }

        // Lấy danh sách donations theo DonorId
        public async Task< IEnumerable<Donation>> GetDonationsByDonorId(int donorId)
        {
            if (donorId <= 0)
            {
                throw new ArgumentException("DonorId must be greater than 0.", nameof(donorId));
            }

            try
            {
                return await _unitOfWork.Repository<Donation>().GetAll()
                    .Where(d => d.DonorId == donorId)
                    .Include(d => d.User)
                    .Include(d => d.Shelter)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving donations by DonorId.", ex);
            }
        }
		public async Task UpdateDonationStatusAsync(int donationId, bool status)
		{
			var donation = await _unitOfWork.Repository<Donation>().GetById(donationId);
			if (donation == null)
			{
				throw new ArgumentException($"Donation with ID {donationId} not found.");
			}

			donation.Status = status;
			_unitOfWork.Repository<Donation>().Update(donation, donationId);
			await _unitOfWork.CommitAsync();
		}
	}
}
