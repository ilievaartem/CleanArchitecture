using DogMateCleanArch.Domain.Entity;

namespace DogMateCleanArch.Domain.Repository;

public interface IPostRepository
{
    Task<List<Post>> GetAllPostsAsync();
    Task<Post> GetByIdAsync(int id);
    Task<Post> CreatePostAsync(Post post);
    Task<int> UpdatePostAsync(int id, Post post);
    Task<int> DeleteAsync(int id);
}