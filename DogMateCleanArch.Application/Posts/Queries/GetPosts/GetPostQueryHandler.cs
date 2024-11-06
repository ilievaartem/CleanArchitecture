using AutoMapper;
using DogMateCleanArch.Domain.Repository;
using MediatR;

namespace DogMateCleanArch.Application.Posts.Queries.GetPosts;

public class GetPostQueryHandler : IRequestHandler<GetPostQuery, List<PostVm>>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public GetPostQueryHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<List<PostVm>> Handle(GetPostQuery request, CancellationToken cancellationToken)
    {
        var posts = await _postRepository.GetAllPostsAsync();
        // var postList = posts.Select(x => new PostVm 
        //         {UserID = x.UserID, Content = x.Content,
        //             MediaUrl = x.MediaUrl, CreatedAt = x.CreatedAt,
        //             UpdatedAt = x.UpdatedAt, PostID = x.PostID}).ToList();

        var postList = _mapper.Map<List<PostVm>>(posts);
        return postList;
    }
}