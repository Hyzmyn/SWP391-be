using ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IShelterStaffService
    {
        IEnumerable<string> GetStaffsOfSheler(int shelterId);

        //bool StaffHasShelter(int userId, string shelterName);

        Task AddStaffAsync(ShelterStaff staff);

        Task RemoveStaffAsync(int id);

    }
}
