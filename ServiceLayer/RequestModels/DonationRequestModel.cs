using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.RequestModels
{
    public class DonationCreateRequestModel
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int DonorId { get; set; }
        public int ShelterId { get; set; }
    }
    public class DonationUpdateRequestModel
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int DonorId { get; set; }
        public int ShelterId { get; set; }
    }
    public class TotalShelterResponseModel
    {
        public int ShelterId { get; set; }
        public decimal TotalDonation { get; set; }
    }

    public class TotalDonorResponseModel
    {
        public int DonorID { get; set; }
        public decimal TotalDonation { get; set; }
    }
}
