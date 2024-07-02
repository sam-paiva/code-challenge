using FluentValidation;
using ProsigliereChallenge.Application.Requests;

namespace ProsigliereChallenge.Application.Validators;

public class AddCommentRequestValidator : AbstractValidator<AddCommentRequest>
{
    public AddCommentRequestValidator()
    {
        RuleFor(c => c.Content).NotEmpty().WithMessage("Content can't be null or empty");
        RuleFor(c => c.Author).NotEmpty().WithMessage("Author can't be null or empty");
    }
}