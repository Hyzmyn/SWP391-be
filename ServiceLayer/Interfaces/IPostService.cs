using ModelLayer.Entities;

namespace ServiceLayer.Interfaces
{
    public interface IPostService
    {
        Task CreatePostAsync(Post post);
        Task DeletePostAsync(int id);
        Task<Post?> GetPostByIdAsync(int id);
        IEnumerable<Post> GetPosts();
        Task<IEnumerable<Post>> GetPostsByPetIdAsync(int petId);
        Task<IEnumerable<Post>> GetPostsByUserIdAsync(int userId);
        Task<bool> PostExistsAsync(int id);
        Task UpdatePostAsync(Post post);
    }
}