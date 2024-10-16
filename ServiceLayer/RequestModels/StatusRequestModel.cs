using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.RequestModels
{
    public class StatusRequestModel
    {
        public DateTime Date { get; set; }
        public string Disease { get; set; }
        public string Vaccine { get; set; } 
        public int PetId { get; set; }

    }
    public class StatusUpdateRequestModel
    {
        public DateTime Date { get; set; }
        public string Disease { get; set; }
        public string Vaccine { get; set; }
    }
    public class StatusCreateRequest
    {
        //public DateTime Date { get; set; }
        public string Disease { get; set; }
        public string Vaccine { get; set; }
        public int PetId { get; set; }
    }
}
