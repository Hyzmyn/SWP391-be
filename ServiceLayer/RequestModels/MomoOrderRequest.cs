using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.RequestModels
{
    public class MomoOrderRequest
    {
        //Model của OrderInfoModel
        public string FullName { get; set; }
        public string OrderId { get; set; }
        public string? OrderInfo { get; set; }
        public double Amount { get; set; }

        //Phần thêm
        public DateTime CreateDate { get; set; }

        public int userID { get; set; }
    }
}
