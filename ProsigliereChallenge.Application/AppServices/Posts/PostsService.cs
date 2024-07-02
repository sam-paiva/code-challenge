using ProsigliereChallenge.Application.Requests;
using ProsigliereChallenge.Core.Models;
using ProsigliereChallenge.Core.Repositories;

namespace ProsigliereChallenge.Application.AppServices.Posts;

public class PostsService(IPostsRepository repository) : IPostsService
{
    private readonly IPostsRepository _repository = repository;
    
    public IEnumerable<BlogPost> GetAll()
    {
        return _repository.GetAll();
    }

    public Result<BlogPost> Save(CreatePostRequest request)
    {
        var post = new BlogPost(request.Content, request.Title);
        _repository.Save(post);

        return Result<BlogPost>.Success(post);
    }

    public Result<BlogPost?> GetById(Guid id)
    {
        return Result<BlogPost?>.Success(_repository.GetById(id));
    }

    public Result<Comment> AddComment(Guid postId, AddCommentRequest request)
    {
        var post = _repository.GetById(postId);

        if (post is null)
            return Result<Comment>.Failure(new Error(nameof(postId), "Post not found"));

        var comment = new Comment(request.Content, request.Author);
        post.AddComment(comment);
        
        _repository.Update(post);
        
        return Result<Comment>.Success(comment);
    }
}