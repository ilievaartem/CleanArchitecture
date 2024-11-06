using DogMateCleanArch.Application.Posts.Commands.CreatePost;
using DogMateCleanArch.Application.Posts.Commands.DeletePost;
using DogMateCleanArch.Application.Posts.Commands.UpdatePost;
using DogMateCleanArch.Application.Posts.Queries.GetPostById;
using DogMateCleanArch.Application.Posts.Queries.GetPosts;
using Microsoft.AspNetCore.Mvc;

namespace DogMateCleanArch.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var blogs = await Mediator.Send(new GetPostQuery());
        return Ok(blogs);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var post = await Mediator.Send(new GetPostByIdQuery() { PostId = id });
        if (post == null) return NotFound();
        return Ok(post);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePostCommand command)
    {
        var createPost = await Mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = createPost.PostID }, createPost);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdatePostCommand command)
    {
        if (id != command.PostID)
        {
            return BadRequest();
        }
        
        await Mediator.Send(command);
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await Mediator.Send(new DeletePostCommand { PostId = id });
        if (result == 0)
        {
            return BadRequest(string.Empty);
        }
        return NoContent();
    }
}