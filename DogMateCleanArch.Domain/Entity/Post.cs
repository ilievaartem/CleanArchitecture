namespace DogMateCleanArch.Domain.Entity;

public class Post
{
    public int PostID { get; set; }

    public int UserID { get; set; }

    public string? Content { get; set; }

    public string? MediaUrl { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}