using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ResponseModels
{
    public class PostResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UserId { get; set; }
        public int PetId { get; set; }
    }
    public class PostResponseDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UserId { get; set; }
        public int PetId { get; set; }
        public UserDetailResponse User { get; set; } = null!;
        public IEnumerable<FeedBackResponseModel> FeedBacks { get; set; } = new List<FeedBackResponseModel>();
    }
}
