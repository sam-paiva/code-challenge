using FluentValidation;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using ProsigliereChallenge.Application.AppServices.Posts;
using ProsigliereChallenge.Application.Validators;
using ProsigliereChallenge.Core.Models;
using ProsigliereChallenge.Core.Repositories;
using ProsigliereChallenge.Infra.DataModels;
using ProsigliereChallenge.Infra.Repositories;

namespace ProsigliereChallenge.IoC;

public static class DependencyResolver
{
    public static void AddDependencies(this IServiceCollection services)
    {
        services.AddScoped<IPostsService, PostsService>();
        services.AddSingleton<IPostsRepository, PostsRepository>();
        
        services.AddValidatorsFromAssemblyContaining<CreatePostRequestValidator>(ServiceLifetime.Singleton);
        AddMapster();
    }

    private static void AddMapster()
    {
        TypeAdapterConfig<BlogPostDataModel, BlogPost>
            .NewConfig()
            .ConstructUsing(dto => BlogPost.ConstructWith(dto.Id, dto.Title, dto.Content))
            .PreserveReference(true);
        
        
        TypeAdapterConfig<Comment, CommentDataModel>
            .NewConfig()
            .PreserveReference(true);
    }
}