using DogMateCleanArch.Domain.Entity;
using DogMateCleanArch.Domain.Repository;
using DogMateCleanArch.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace DogMateCleanArch.Infra.Repository;

public class PostRepository : IPostRepository
{
    private readonly PostDbContext _postDbContext;

    public PostRepository(PostDbContext postDbContext)
    {
        _postDbContext = postDbContext;
    }
    public async Task<List<Post>> GetAllPostsAsync()
    {
        return await _postDbContext.Posts.ToListAsync();
    }

    public async Task<Post> GetByIdAsync(int id)
    {
       return await _postDbContext.Posts.AsNoTracking()
           .FirstOrDefaultAsync(p => p.PostID == id);
    }

    public async Task<Post> CreatePostAsync(Post post)
    {
        await _postDbContext.Posts.AddAsync(post);
        await _postDbContext.SaveChangesAsync();
        return post;
    }

    public async Task<int> UpdatePostAsync(int id, Post post)
    {
        return await _postDbContext.Posts
            .Where(model => model.PostID == id)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(m => m.PostID, post.PostID)
                .SetProperty(m => m.UserID, post.UserID)
                .SetProperty(m => m.Content, post.Content)
                .SetProperty(m => m.MediaUrl, post.MediaUrl)
            );
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _postDbContext.Posts
            .Where(model => model.PostID == id)
            .ExecuteDeleteAsync();
    }
}