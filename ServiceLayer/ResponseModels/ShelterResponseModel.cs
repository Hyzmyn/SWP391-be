using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ResponseModels
{
    public class ShelterResponseModel
    {
        public int Id { get; set; }  // Thêm ID để nhận diện Shelter
        public string Name { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public int Capacity { get; set; }
        public string Email { get; set; }
        public string? Website { get; set; }
        public decimal? DonationAmount { get; set; }

        // Thông tin thêm về các quan hệ liên kết có thể có
        public List<PetResponseModel>? Pets { get; set; }
        public List<EventResponseModel>? Events { get; set; }
        public List<UsersResponseModel>? Users { get; set; }
        public List<DonationResponseModel>? Donations { get; set; }
    }

}
