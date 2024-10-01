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
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int? PostId { get; set; }
    }
    public class FeedBackResponseDetail
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int PostId { get; set; }

        public UserDetailResponse User { get; set; } = null!;
        public PostResponseDetail Post { get; set; } = null!;
    }
}
