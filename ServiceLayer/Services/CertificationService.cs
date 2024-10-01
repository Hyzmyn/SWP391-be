using ModelLayer.Entities;
using RepositoryLayer;
using RepositoryLayer.UnitOfWork;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class CertificationService : ICertificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPetService _petService;

        public CertificationService(IUnitOfWork unitOfWork, IPetService petService)
        {
            _unitOfWork = unitOfWork;
            _petService = petService;
        }

        public IEnumerable<Certification> GetAllCertificate()
        {
            return _unitOfWork.Repository<Certification>().GetAll();
        }

        public async Task<Certification> GetCertificateByIdAsync(int certId)
        {
            if (certId == 0)
            {
                throw new ArgumentException("Id cannot be null or empty.", nameof(certId));
            }

            try
            {
                return await _unitOfWork.Repository<Certification>().GetById(certId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving the certification.", ex);
            }
        }

        public async Task CreateCertificate(Certification certification)
        {
            var pet = await _petService.GetPetById(certification.PetId);

            // Nếu Pet chưa có UserId (chưa có người nhận nuôi), không tạo Certification
            if (pet.UserID == null)
            {
                throw new InvalidOperationException($"Pet with ID {certification.PetId} does not have a registered user.");
            }

            await _unitOfWork.Repository<Certification>().InsertAsync(certification);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateCertificate(Certification certification)
        {
            await _unitOfWork.Repository<Certification>().Update(certification, certification.Id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteCertificateAsync(int id)
        {
            var certification = await _unitOfWork.Repository<Certification>().GetById(id);
            if (certification != null)
            {
                _unitOfWork.Repository<Certification>().Delete(certification);
                await _unitOfWork.CommitAsync();
            }
        }
    }

}