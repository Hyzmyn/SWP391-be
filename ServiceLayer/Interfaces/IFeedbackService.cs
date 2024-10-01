using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;

namespace ServiceLayer.Interfaces
{
    public interface IFeedbackService
    {
        Task<FeedBackResponseModel> CreateFeedback(FeedBackRequestModel request);
        Task DeleteFeedback(int id);
        IEnumerable<FeedBackResponseModel> GetAllFeedbacks();
        Task<FeedBackResponseModel> GetFeedBackById(int id);
        Task<FeedBackResponseModel> UpdateFeedbackAsync(int id, FeedBackRequestModel request);
    }
}