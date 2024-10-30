using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Repositories;

namespace Project.Services;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;

    public PostService(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<Post> GetPostByIdAsync(int id)
    {
        return await _postRepository.GetPostByIdAsync(id);
    }

    public async Task<IEnumerable<Post>> GetAllPostsAsync()
    {
        return await _postRepository.GetAllPostsAsync();
    }

    public async Task<Post> CreatePostAsync(Post post)
    {
        return await _postRepository.CreatePostAsync(post);
    }

    public async Task<bool> DeletePostAsync(int id)
    {
        return await _postRepository.DeletePostAsync(id);
    }

    public async Task<Post> UpdatePostAsync(int id, Post post)
    {
        return await _postRepository.UpdatePostAsync(id, post);
    }

    public async Task<IEnumerable<Post>> GetPostsByUserIdAsync(int userId)
    {
        return await _postRepository.GetPostsByUserIdAsync(userId);
    }
}
