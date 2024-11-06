using AutoMapper;
using DogMateCleanArch.Domain.Repository;
using DogMateCleanArch.Application.Posts.Queries.GetPosts;
using MediatR;

namespace DogMateCleanArch.Application.Posts.Queries.GetPostById;

public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, PostVm>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public GetPostByIdQueryHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<PostVm> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(request.PostId);
        return _mapper.Map<PostVm>(post);
    }
}