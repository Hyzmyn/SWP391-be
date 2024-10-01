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
            return _unitOfWork.Repository<Donation>().GetAll();
        }

        // Lấy danh sách các donation theo danh sách IDs
        public async Task<Donation> GetDonationsByIdAsync(int id)
        {
            if (id == null)
            {
                throw new ArgumentException("Id cannot be null or empty.", nameof(id));
            }

            try
            {
                return await _unitOfWork.Repository<Donation>().GetById(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving donations.", ex);
            }
        }


        // Thêm donation mới
        public async Task CreateDonationAsync(Donation donation)
        {
            await _unitOfWork.Repository<Donation>().InsertAsync(donation);
            await _unitOfWork.CommitAsync();
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
                .Where(d => d.ShelterId == shelterId)
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
        public IEnumerable<Donation> GetDonationsByDonorId(int donorId)
        {
            if (donorId <= 0)
            {
                throw new ArgumentException("DonorId must be greater than 0.", nameof(donorId));
            }

            try
            {
                return _unitOfWork.Repository<Donation>()
                    .AsQueryable()
                    .Where(d => d.DonorId == donorId)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving donations by DonorId.", ex);
            }
        }
    }

}
