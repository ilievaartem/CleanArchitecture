using DogMateCleanArch.Domain.Repository;
using MediatR;

namespace DogMateCleanArch.Application.Posts.Commands.DeletePost;

public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, int>
{
    private readonly IPostRepository _postRepository;

    public DeletePostCommandHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }
    public async Task<int> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        return await _postRepository.DeleteAsync(request.PostId);
    }
}