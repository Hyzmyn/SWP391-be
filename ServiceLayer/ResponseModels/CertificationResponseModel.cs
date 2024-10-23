using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ResponseModels
{
    public class CertificationResponse
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public int ShelterStaffID { get; set; }

        public int UserId { get; set; }
        public int PetId { get; set; }
        //public string? PetName { get; set; }
    }
    public class CertificationResponseDetail : CertificationResponse
    {
        public UsersResponseModel ShelterStaff { get; set; } = null!;
        public UsersResponseModel User { get; set; } = null!;
        public PetDetailResponse Pet { get; set; } = null!;
    }
    public class DeleteCertificationResponse
    {
        public int Id { get; set; }
        public string Message { get; set; }
    }
}
