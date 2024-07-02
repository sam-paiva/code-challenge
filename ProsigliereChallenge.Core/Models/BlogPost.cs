namespace ProsigliereChallenge.Core.Models;

public class BlogPost
{
    public BlogPost(string title, string content)
    {
        ArgumentNullException.ThrowIfNull(title);
        ArgumentNullException.ThrowIfNull(content);

        Id = Guid.NewGuid();
        Title = title;
        Content = content;
        Comments = [];
    }

    private BlogPost(Guid id, string title, string content)
    {
        Id = id;
        Title = title;
        Content = content;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }
    public ICollection<Comment> Comments { get; private set; }

    public void AddComment(Comment comment)
    {
        ArgumentNullException.ThrowIfNull(comment.Content);
        ArgumentNullException.ThrowIfNull(comment.Author);
        
        Comments.Add(comment);
    }

    public static BlogPost ConstructWith(Guid id, string title, string content)
    {
        return new BlogPost(id, title, content);
    }
}