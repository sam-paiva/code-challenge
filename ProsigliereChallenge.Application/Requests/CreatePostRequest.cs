using System.ComponentModel.DataAnnotations;

namespace ProsigliereChallenge.Application.Requests;

public record CreatePostRequest
{
    public string? Title { get; init; }
    public string? Content { get; init; }
}