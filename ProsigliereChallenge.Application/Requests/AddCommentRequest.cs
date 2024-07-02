using System.ComponentModel.DataAnnotations;

namespace ProsigliereChallenge.Application.Requests;

public record AddCommentRequest
{
    [Required(ErrorMessage = "Author is required")]
    public required string Author { get; set; }
    
    [Required(ErrorMessage = "Content is required")]
    public required string Content { get; set; }
};