using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ResponseModels
{
    public class StatusResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty; // Nếu có thể, nên sử dụng DateTime thay vì string
        public string Disease { get; set; } = string.Empty;
        public string Vaccine { get; set; } = string.Empty;
        public int PetId { get; set; }
        public string PetName { get; set; } = string.Empty;
    }
    public class StatusDetailResponseModel : StatusResponseModel
    {
        public PetResponseModel Pet { get; set; } = null!;
    }

    public class PetDetailResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        // Thêm các thuộc tính khác của Pet nếu cần
    }

}
