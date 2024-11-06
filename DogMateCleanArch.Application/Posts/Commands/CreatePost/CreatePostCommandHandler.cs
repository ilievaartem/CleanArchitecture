using AutoMapper;
using DogMateCleanArch.Domain.Entity;
using DogMateCleanArch.Domain.Repository;
using DogMateCleanArch.Application.Posts.Queries.GetPosts;
using MediatR;

namespace DogMateCleanArch.Application.Posts.Commands.CreatePost;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, PostVm>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public CreatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }
    public async Task<PostVm> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var postEntity = new Post() { UserID = request.UserID, Content = request.Content, MediaUrl = request.MediaUrl };
        var Result = await _postRepository.CreatePostAsync(postEntity);
        return _mapper.Map<PostVm>(Result);
    }
}