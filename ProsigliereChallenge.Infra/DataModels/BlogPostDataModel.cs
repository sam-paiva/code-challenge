using ProsigliereChallenge.Core.Models;

namespace ProsigliereChallenge.Infra.DataModels;

public record BlogPostDataModel
{
    public required Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public ICollection<CommentDataModel> Comments { get; set; } = [];
    
}