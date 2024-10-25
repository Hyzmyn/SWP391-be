using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ResponseModels
{
    public class StatusResponseModel
    {
        public int StatusId { get; set; }
        public DateTime Date { get; set; }
        public string Disease { get; set; }
        public string Vaccine { get; set; }
    }
    public class StatusDetailResponseModel : StatusResponseModel
    {
        public PetResponseModel Pet { get; set; } = null!;
    }

    public class PetDetailResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class PetStatusResponseModel :StatusResponseModel
    {
        public int PetId { get; set; }
    }
}
