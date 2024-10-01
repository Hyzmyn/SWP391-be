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
        public string Name { get; set; } = string.Empty;     
        [Required]
        public DateTime Date { get; set; } 

        public string Disease { get; set; } = string.Empty;   
        public string Vaccine { get; set; } = string.Empty;   
        [Required]
        public int PetId { get; set; }                     

        // Thuộc tính cho Pet (không bắt buộc, sử dụng khi cần liên kết với thông tin thú cưng trong Create/Update)
        public string? PetName { get; set; } = string.Empty;  
        public string? PetType { get; set; } = string.Empty; 
        public string? PetBreed { get; set; } = string.Empty; 
        public string? PetColor { get; set; } = string.Empty; 
    }
    public class StatusUpdateRequestModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; } 

        public string Disease { get; set; } = string.Empty;
        public string Vaccine { get; set; } = string.Empty;

        [Required]
        public int PetId { get; set; }
    }
}
