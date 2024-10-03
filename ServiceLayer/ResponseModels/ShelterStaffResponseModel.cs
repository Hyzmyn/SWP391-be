using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ResponseModels
{
    public class ShelterStaffResponseModel
    {
        public int ShelterId { get; set; }
        public List<string> Staffs { get; set; }
    }
}
