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
        [Required]
        public string Name { get; set; } = string.Empty;      // Tên trạng thái
        public string Date { get; set; } // Sử dụng DateTime thay vì string

        public string Disease { get; set; } = string.Empty;   // Bệnh lý (nếu có)
        public string Vaccine { get; set; } = string.Empty;   // Vắc xin đã tiêm
        public int PetId { get; set; }                       // ID của thú cưng liên kết

        // Thuộc tính cho Pet (không bắt buộc, sử dụng khi cần liên kết với thông tin thú cưng trong Create/Update)
        public string? PetName { get; set; } = string.Empty;  // Tên thú cưng (nếu cần cập nhật)
        public string? PetType { get; set; } = string.Empty;  // Loại thú cưng (chó, mèo...)
        public string? PetBreed { get; set; } = string.Empty; // Giống loài
        public string? PetColor { get; set; } = string.Empty; // Màu sắc của thú cưng
    }

}
