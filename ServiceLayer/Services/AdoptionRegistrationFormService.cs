﻿using Microsoft.EntityFrameworkCore;
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

        // Get all adoption registration forms with related entities
        public IEnumerable<AdoptionRegistrationForm> GetAllAdoptionForms()
        {
            return _unitOfWork.Repository<AdoptionRegistrationForm>().GetAll()
                .Include(form => form.User)
                .Include(form => form.Pet)
                .Include(pet => pet.Pet.Shelter)
                .ToList();
        }

        // Get a specific adoption form by ID with related entities
        public async Task<AdoptionRegistrationForm> GetAdoptionFormByIdAsync(int id)
        {
            return await _unitOfWork.Repository<AdoptionRegistrationForm>().GetAll()
                .Include(form => form.User)
                .Include(form => form.Pet)
                .FirstOrDefaultAsync(form => form.Id == id);
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
            _unitOfWork.Repository<AdoptionRegistrationForm>().Update(form, form.Id);
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


        public async Task<IEnumerable<AdoptionRegistrationForm>> GetFormsByPetId(int petid)
        {
            return await _unitOfWork.Repository<AdoptionRegistrationForm>().GetWhere(p => p.PetId == petid);
        }

        // Check if an adoption form exists by ID
        public async Task<bool> FormExistsAsync(int petid)
        {
            var form = await _unitOfWork.Repository<AdoptionRegistrationForm>().GetWhere(p => p.PetId == petid && p.Status == true);
            return form.Any(); 
        }
    }

}
