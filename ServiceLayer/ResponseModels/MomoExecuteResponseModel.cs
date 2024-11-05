using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ResponseModels
{
    public class MomoExecuteResponseModel
    {
        public bool Success { get; set; }  
        public string OrderId { get; set; }
        public string OrderInfo { get; set; }
        public string Amount { get; set; }

        public int UserId { get; set; }
        public string RequestId { get; set; }
        public string RequestType { get; set; }
        public string Message { get; set; }
        public string LocalMessage { get; set; }
        public string PayUrl { get; set; }
        public string Signature { get; set; }
        public string QrCodeUrl { get; set; }
        public string Deeplink { get; set; }
        public string DeeplinkWebInApp { get; set; }
    }
}
