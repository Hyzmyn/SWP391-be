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
    public class ShelterService : IShelterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShelterService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Shelter> GetShelter()
        {
            return _unitOfWork.Repository<Shelter>().GetAll();
        }

        public async Task<Shelter> GetShelterByID(int shelterId)
        {
            return await _unitOfWork.Repository<Shelter>().GetById(shelterId);
        }

        public async Task CreateShelter(Shelter shelter)
        {
            try
            {
                await _unitOfWork.Repository<Shelter>().InsertAsync(shelter);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task UpdateShelter(Shelter shelter)
        {
            try
            {
                var check = await _unitOfWork.Repository<Shelter>().GetById(shelter.Id);
                if (check != null)
                {
                    await _unitOfWork.Repository<Shelter>().Update(shelter, shelter.Id);
                    await _unitOfWork.CommitAsync();
                }
                else
                {
                    throw new Exception("Account not found ! Can not Update");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteShelter(int id)
        {
            try
            {
                var shelter = await _unitOfWork.Repository<Shelter>().GetById(id);
                if (shelter != null)
                {
                    _unitOfWork.Repository<Shelter>().Delete(shelter);
                    await _unitOfWork.CommitAsync();
                }
                else
                {
                    throw new Exception("Shelter not found");
                }
            }
            catch (Exception ex) { throw ex; }

        }

    }
}
