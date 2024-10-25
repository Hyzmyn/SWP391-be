using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ResponseModels
{
    // PetsResponseModel: Dùng để trả về thông tin cơ bản của Pet
    public class PetResponseModel
    {
        public int PetID { get; set; }
        public int ShelterID { get; set; }
        public int? UserID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string? Breed { get; set; }
        public string? Gender { get; set; }
        public int? Age { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public string? Description { get; set; }
        public string? AdoptionStatus { get; set; }
        public string? Image { get; set; }

        public IEnumerable<StatusResponseModel> Statuses { get; set; }
    }

    public class PetDetailResponse : PetResponseModel
    {
        public string? ShelterName { get; set; } 
        public string? UserName { get; set; } 
    }

}
