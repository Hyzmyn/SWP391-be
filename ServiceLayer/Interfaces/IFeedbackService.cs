using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;

namespace ServiceLayer.Interfaces
{
    public interface IFeedbackService
    {
        Task<FeedBackResponseDetail> CreateFeedbackAsync(FeedBackRequestModel request);
        Task DeleteFeedbackAsync(int id);
        Task<bool> FeedbackExistsAsync(int id);
        IEnumerable<FeedBackResponseModel> GetAllFeedbacks();
        Task<FeedBackResponseDetail> GetFeedbackByIdAsync(int id);
        Task<FeedBackResponseDetail> UpdateFeedbackAsync(int id, FeedBackRequestModel request);
    }
}