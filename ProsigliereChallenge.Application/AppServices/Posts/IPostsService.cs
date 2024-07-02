using ProsigliereChallenge.Application.Requests;
using ProsigliereChallenge.Core.Models;

namespace ProsigliereChallenge.Application.AppServices.Posts;

public interface IPostsService
{
    IEnumerable<BlogPost> GetAll();
    Result<BlogPost> Save(CreatePostRequest request);
    Result<BlogPost?> GetById(Guid id);
    Result<Comment> AddComment(Guid postId, AddCommentRequest request);

}