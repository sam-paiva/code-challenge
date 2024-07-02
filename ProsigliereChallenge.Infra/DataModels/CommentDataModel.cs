namespace ProsigliereChallenge.Infra.DataModels;

public record CommentDataModel
{
    public required string Content { get; set; }
    public required string Author { get; set; }
}