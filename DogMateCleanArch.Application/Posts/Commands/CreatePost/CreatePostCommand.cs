using DogMateCleanArch.Application.Posts.Queries.GetPosts;
using MediatR;

namespace DogMateCleanArch.Application.Posts.Commands.CreatePost;

public class CreatePostCommand : IRequest<PostVm>
{
    public int UserID { get; set; }

    public string? Content { get; set; }

    public string? MediaUrl { get; set; }
}