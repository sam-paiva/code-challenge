using FluentValidation;

namespace ProsigliereChallenge.API.Filters;

public class ValidationFilter<T> : IEndpointFilter where T : class
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext ctx, EndpointFilterDelegate next)
    {
        var validator = ctx.HttpContext.RequestServices.GetService<IValidator<T>>();
        if (validator is null) return await next(ctx);

        var entity = ctx.Arguments
            .OfType<T>()
            .FirstOrDefault(a => a?.GetType() == typeof(T));
        if (entity is null) return Results.Problem("Error Not Found");

        var results = await validator.ValidateAsync((entity));
        if (!results.IsValid)
        {
            return Results.ValidationProblem(results.ToDictionary());
        }

        return await next(ctx);
    }
}
