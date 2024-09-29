using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ResponseModels
{
    public class AdoptionRegistrationFormResponse
    {
        public int Id { get; set; }
        public string IdentityProof { get; set; }
        public decimal IncomeAmount { get; set; }
        public string Image { get; set; }
        public string Condition { get; set; }
        public int AdopterId { get; set; }
        public int ShelterStaffId { get; set; }
        public int PetId { get; set; }

        public bool? Status { get; set; }
    }
    public class AdoptionRegistrationFormDetailResponse:AdoptionRegistrationFormResponse
    {
        public UserDetailResponse Adopter { get; set; } // Chi tiết về người nhận nuôi
        public PetDetailResponse Pet { get; set; } // Chi tiết về thú cưng
        public UserDetailResponse ShelterStaff { get; set; } // Chi tiết về nhân viên trú ẩn
    }
}
