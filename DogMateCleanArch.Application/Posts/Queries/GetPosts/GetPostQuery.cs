using DogMateCleanArch.Domain.Entity;
using MediatR;

namespace DogMateCleanArch.Application.Posts.Queries.GetPosts;

public class GetPostQuery : IRequest<List<PostVm>>
{
}
// public record GetPostQuery : IRequest<List<PostVm>>;
