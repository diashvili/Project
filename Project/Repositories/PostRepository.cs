using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Repositories;
public class PostRepository : IPostRepository
{
    private readonly AppDbContext _context;

    public PostRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Post>> GetAllPostsAsync()
    {
        return await _context.Posts.ToListAsync();
    }

    public async Task<Post> GetPostByIdAsync(int id)
    {
        return await _context.Posts.FindAsync(id);
    }

    public async Task<IEnumerable<Post>> GetPostsByUserIdAsync(int userId)
    {
        return await _context.Posts.Where(p => p.UserId == userId).ToListAsync();
    }

    public async Task<Post> CreatePostAsync(Post post)
    {
        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
        return post;
    }

    public async Task<Post> UpdatePostAsync(int id, Post post)
    {
        var existingPost = await GetPostByIdAsync(id);
        if (existingPost == null) return null;

        existingPost.Content = post.Content;
        existingPost.Title = post.Title;
        _context.Posts.Update(post);
        await _context.SaveChangesAsync();
        return existingPost;
    }

    public async Task<bool> DeletePostAsync(int id)
    {
        var post = await GetPostByIdAsync(id);
        if (post == null) return false;
        
        post.IsDeleted = 1;
        await _context.SaveChangesAsync(); 
        return true;
    }
}
