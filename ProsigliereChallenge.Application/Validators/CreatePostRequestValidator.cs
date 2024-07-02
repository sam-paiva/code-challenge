using FluentValidation;
using ProsigliereChallenge.Application.Requests;

namespace ProsigliereChallenge.Application.Validators;

public class CreatePostRequestValidator : AbstractValidator<CreatePostRequest>
{
    public CreatePostRequestValidator()
    {
        RuleFor(c => c.Title).NotEmpty().WithMessage("Title can't be null or empty");
        RuleFor(c => c.Content).NotEmpty().WithMessage("Content can't be null or empty");
    }
}