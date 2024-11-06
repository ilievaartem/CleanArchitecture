using MediatR;

namespace DogMateCleanArch.Application.Posts.Commands.UpdatePost;

public class UpdatePostCommand : IRequest<int>
{
    public int PostID { get; set; }

    public int UserID { get; set; }

    public string? Content { get; set; }

    public string? MediaUrl { get; set; }
}