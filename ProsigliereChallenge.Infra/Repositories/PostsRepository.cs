using Mapster;
using MapsterMapper;
using ProsigliereChallenge.Core.Models;
using ProsigliereChallenge.Core.Repositories;
using ProsigliereChallenge.Infra.DataModels;

namespace ProsigliereChallenge.Infra.Repositories;

public class PostsRepository : IPostsRepository
{
    private readonly List<BlogPostDataModel> _fakeDb = [];
    public IEnumerable<BlogPost> GetAll()
    {
        var data = _fakeDb;
        return data.Select(d => d.Adapt<BlogPost>());
    }

    public void Save(BlogPost post)
    {
        var dataModel = post.Adapt<BlogPostDataModel>();
        _fakeDb.Add(dataModel);
    }

    public void Update(BlogPost post)
    {
        var model = _fakeDb.SingleOrDefault(c => c.Id == post.Id);

        if (model is null)
            return;

        model.Content = post.Content;
        model.Title = post.Title;
        model.Comments = post.Comments.Adapt<ICollection<CommentDataModel>>();
    }

    public BlogPost? GetById(Guid id)
    {
        return _fakeDb.SingleOrDefault(c => c.Id == id)?.Adapt<BlogPost>();
    }
}