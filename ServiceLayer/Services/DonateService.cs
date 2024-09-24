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

        // Lấy donation theo Id
        public async Task<Donation> GetDonationById(int id)
        {
            return await _unitOfWork.Repository<Donation>().GetById(id);
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
    }

}
