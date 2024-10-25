using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.RequestModels
{
    public class PostRequestModel
    {
        [Required]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters.")]
        public string Title { get; set; }

        [Required]
        [StringLength(5000, ErrorMessage = "Content cannot exceed 5000 characters.")]
        public string Content { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int PetId { get; set; }
    }
}
