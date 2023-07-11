using BookCriticsAPI.Abstractions;
using BookCriticsApplication.ModelDtos;
using BookCriticsApplication.Models.MLModelIO;
using BookCriticsApplication.Modules.ReviewModules.Commands;
using BookCriticsApplication.Modules.ReviewModules.Queries;
using MediatR;
using Microsoft.Extensions.ML;

namespace BookCriticsAPI.EndpointDefinitions;

public class ReviewEndpointDefinition : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        var review = app.MapGroup("/review");

        review.MapPost("/Post", async (IMediator mediator, ReviewDto reviewToPost) =>
        {
            var postCommand = new PostReview { ReviewToPost = reviewToPost };
            var result = await mediator.Send(postCommand);

            return result ? Results.Ok() : Results.BadRequest();
        });

        review.MapPatch("/Edit/{id}", async (IMediator mediator, string newText, int id) =>
        {
            var patchCommand = new EditReview { ReviewId = id, NewContent = newText };
            var result = await mediator.Send(patchCommand);

            return result ? Results.Ok() : Results.BadRequest();
        });

        review.MapDelete("/Remove/{id}", async (IMediator mediator, int id) =>
        {
            var deleteCommand = new RemoveReview { ReviewId = id };
            var result = await mediator.Send(deleteCommand);

            return result ? Results.Ok() : Results.NotFound();
        });

        review.MapGet("/GetUnderBook/{bookId}", async (IMediator mediator, int bookId) =>
        {
            var getQuery = new GetReviewsUnderBook { BookId = bookId };
            var result = await mediator.Send(getQuery);

            return Results.Ok(result);
        });
    }
}
