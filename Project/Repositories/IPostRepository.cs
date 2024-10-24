using Project.Models;

namespace Project.Repositories;
public interface IPostRepository
{
    Task<IEnumerable<Post>> GetAllPostsAsync();
    Task<Post> GetPostByIdAsync(int id);
    Task<IEnumerable<Post>> GetPostsByUserIdAsync(int userId);
    Task AddPostAsync(Post post);
    Task UpdatePostAsync(Post post);
    Task DeletePostAsync(int id);
}
