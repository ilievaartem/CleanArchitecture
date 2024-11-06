using FluentValidation;
using FluentValidation.Validators;

namespace DogMateCleanArch.Application.Posts.Commands.CreatePost;

public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidator()
    {
        RuleFor(v => v.UserID)
            .NotEmpty().WithMessage("User ID is required");
        
        RuleFor(v => v.Content)
            .NotEmpty().WithMessage("Content is required")
            .MaximumLength(50).WithMessage("Content length must be less than 20 characters");
        
        RuleFor(v => v.MediaUrl)
            .NotEmpty().WithMessage("Media URL is required");
    }
}