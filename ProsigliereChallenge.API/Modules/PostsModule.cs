using System.Runtime.InteropServices.JavaScript;
using ProsigliereChallenge.API.Filters;
using ProsigliereChallenge.Application;
using ProsigliereChallenge.Application.AppServices.Posts;
using ProsigliereChallenge.Application.Requests;
using ProsigliereChallenge.Core.Models;

namespace ProsigliereChallenge.API.Modules;

public static class PostsModule
{
    public static void MapPostEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("api/posts", (IPostsService service) =>
            {
                var data = service.GetAll();
                return Results.Ok(data);
            })
            .WithName("GetAllPosts")
            .Produces(200, typeof(IEnumerable<BlogPost>))
            .WithOpenApi();

        endpoints.MapPost("api/posts", (IPostsService service, CreatePostRequest request) =>
            {
                var result = service.Save(request);

                if (!result.IsSuccess)
                    return Results.Problem(result.Error.Description);

                return Results.CreatedAtRoute("CreatePost", result.Data);
            })
            .WithName("CreatePost")
            .AddEndpointFilter<ValidationFilter<CreatePostRequest>>()
            .Produces(201, typeof(BlogPost))
            .ProducesProblem(400)
            .ProducesValidationProblem()
            .WithOpenApi();

        endpoints.MapGet("api/posts/{id}", (IPostsService service, Guid id) =>
            {
                var result = service.GetById(id);

                if (!result.IsSuccess)
                    return Results.Problem(result.Error.Description);

                if (result.Data is null)
                    return Results.NotFound();

                return Results.Ok(result.Data);
            })
            .WithName("GetPostById")
            .Produces(200, typeof(BlogPost))
            .ProducesProblem(400)
            .WithOpenApi();

        endpoints.MapPost("api/posts/{postId}/comments",
                (IPostsService service, Guid postId, AddCommentRequest request) =>
                {
                    var result = service.AddComment(postId, request);

                    if (!result.IsSuccess)
                        return Results.Problem(result.Error.Description);

                    return Results.CreatedAtRoute("AddComment", result.Data);
                })
            .WithName("AddComment")
            .AddEndpointFilter<ValidationFilter<AddCommentRequest>>()
            .Produces(201, typeof(Comment))
            .ProducesProblem(400)
            .ProducesValidationProblem()
            .WithOpenApi();
    }
}