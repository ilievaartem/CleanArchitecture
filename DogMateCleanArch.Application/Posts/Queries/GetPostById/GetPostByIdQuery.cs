using DogMateCleanArch.Application.Posts.Queries.GetPosts;
using MediatR;

namespace DogMateCleanArch.Application.Posts.Queries.GetPostById;

public class GetPostByIdQuery : IRequest<PostVm>
{
    public int PostId { get; set; }
}