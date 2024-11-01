using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Services;

namespace Project.Controllers;
[ApiController]
[Route("api/posts")]
public class PostController : BaseController
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPosts()
    {
        var posts = await _postService.GetAllPostsAsync();
        return Ok(posts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostById(int id)
    {
        var post = await _postService.GetPostByIdAsync(id);
        return HandleResponse(post);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost(Post post)
    {
        var createdPost = await _postService.CreatePostAsync(post);
        return CreatedAtAction(nameof(GetPostById), new { id = createdPost.PostId }, createdPost);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePost(int id, Post post)
    {
        var updatedPost = await _postService.UpdatePostAsync(id, post);
        return HandleResponse(updatedPost);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        var success = await _postService.DeletePostAsync(id);
        if (!success) return NotFound();
        return NoContent();
    }
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetPostsByUserIdAsync(int userId)
    {
        var posts = await _postService.GetPostsByUserIdAsync(userId);
        return HandleResponse(posts);
    }
}
