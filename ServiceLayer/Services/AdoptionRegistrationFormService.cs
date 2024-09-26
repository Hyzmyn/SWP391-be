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
    public class AdoptionRegistrationFormService : IAdoptionRegistrationFormService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdoptionRegistrationFormService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Get all adoption registration forms
        public IEnumerable<AdoptionRegistrationForm> GetAllAdoptionForms()
        {
            return _unitOfWork.Repository<AdoptionRegistrationForm>().GetAll();
        }

        // Get a specific adoption form by ID
        public async Task<AdoptionRegistrationForm> GetAdoptionFormByIdAsync(int id)
        {
            return await _unitOfWork.Repository<AdoptionRegistrationForm>().GetById(id);
        }

        // Create a new adoption form
        public async Task CreateAdoptionFormAsync(AdoptionRegistrationForm form)
        {
            await _unitOfWork.Repository<AdoptionRegistrationForm>().InsertAsync(form);
            await _unitOfWork.CommitAsync();
        }

        // Update an existing adoption form
        public async Task UpdateAdoptionFormAsync(AdoptionRegistrationForm form)
        {
            await _unitOfWork.Repository<AdoptionRegistrationForm>().Update(form, form.Id);
            await _unitOfWork.CommitAsync();
        }

        // Delete an adoption form by ID
        public async Task DeleteAdoptionFormAsync(int id)
        {
            var form = await _unitOfWork.Repository<AdoptionRegistrationForm>().GetById(id);
            if (form != null)
            {
                _unitOfWork.Repository<AdoptionRegistrationForm>().Delete(form);
                await _unitOfWork.CommitAsync();
            }
        }

        // Check if an adoption form exists by ID
        public async Task<bool> FormExistsAsync(int id)
        {
            var form = await _unitOfWork.Repository<AdoptionRegistrationForm>().GetById(id);
            return form != null;
        }

        // Các phương thức khác không thay đổi

        public async Task<AdoptionRegistrationForm> GetAdopterByIdAsync(int adopterId)
        {
            return await _unitOfWork.Repository<AdoptionRegistrationForm>().GetById(adopterId);
        }

        public async Task<ShelterStaff> GetShelterStaffByIdAsync(int shelterStaffId)
        {
            return await _unitOfWork.Repository<ShelterStaff>().GetById(shelterStaffId);
        }

        public async Task<Pet> GetPetByIdAsync(int petId)
        {
            return await _unitOfWork.Repository<Pet>().GetById(petId);
        }
    }

}
