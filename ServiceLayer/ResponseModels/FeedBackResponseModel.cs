using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ResponseModels
{
    public class FeedBackResponseModel
    {
        public int FeedbackId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        // Optional: Thêm thông tin liên quan từ User và Post nếu cần
        //public string? Username { get; set; }
        //public string? PostTitle { get; set; }
    }
    public class FeedBackResponseDetail:FeedBackResponseModel
    {
        public UsersResponseModel User { get; set; } = null!;
        public PostResponseDetail Post { get; set; } = null!;
    }
}
