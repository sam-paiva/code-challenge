using ProsigliereChallenge.Core.Models;

namespace ProsigliereChallenge.Core.Repositories;

public interface IPostsRepository
{
    IEnumerable<BlogPost> GetAll();
    void Save(BlogPost post);
    void Update(BlogPost post);
    BlogPost? GetById(Guid id);
}