using DogMateCleanArch.Domain.Entity;
using DogMateCleanArch.Domain.Repository;
using MediatR;

namespace DogMateCleanArch.Application.Posts.Commands.UpdatePost;

public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, int>
{
    private readonly IPostRepository _postRepository;

    public UpdatePostCommandHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }
    public async Task<int> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var UpdatepostEntity = new Post()
        {
            PostID = request.PostID,
            UserID = request.UserID,
            Content = request.Content,
            MediaUrl = request.MediaUrl
        };
        return await _postRepository.UpdatePostAsync(request.PostID, UpdatepostEntity);
    }
}