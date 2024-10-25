using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ResponseModels
{
    public class DonationResponseModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int DonorId { get; set; }
        //public string DonorName { get; set; } = string.Empty;
        public int ShelterId { get; set; }
        //public string ShelterName { get; set; } = string.Empty;
    }

    public class DonationDetailResponseModel : DonationResponseModel
    {
        public UsersResponseModel? Donor { get; set; }
        public ShelterResponseModel? Shelter { get; set; }
    }
    public class DonationReponseForShelterModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int DonorId { get; set; }
        public int ShelterId { get; set; }
        public UsersResponseModel? Donor { get; set; }

    }
    public class TotalDonorDonationResponseModel
    {
        public int DonorId { get; set; }
        public decimal TotalDonation { get; set; }
    }

    public class TotalShelterDonationResponseModel
    {
        public int ShelterId { get; set; }
        public decimal TotalDonation { get; set; }
    }
}
