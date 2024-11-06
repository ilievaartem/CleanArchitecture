using DogMateCleanArch.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace DogMateCleanArch.Infra.Data;

public class PostDbContext : DbContext
{
    public PostDbContext(DbContextOptions<PostDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }
    
    public DbSet<Post> Posts { get; set; }
}