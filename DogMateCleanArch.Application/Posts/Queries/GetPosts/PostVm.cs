using DogMateCleanArch.Domain.Entity;
using DogMateCleanArch.Application.Common.Mappings;

namespace DogMateCleanArch.Application.Posts.Queries.GetPosts;

public class PostVm : IMapFrom<Post>
{
    public int PostID { get; set; }

    public int UserID { get; set; }

    public string? Content { get; set; }

    public string? MediaUrl { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}