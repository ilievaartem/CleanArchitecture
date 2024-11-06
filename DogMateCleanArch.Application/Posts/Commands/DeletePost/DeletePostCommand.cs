using MediatR;

namespace DogMateCleanArch.Application.Posts.Commands.DeletePost;

public class DeletePostCommand : IRequest<int>
{
    public int PostId { get; set; }
}