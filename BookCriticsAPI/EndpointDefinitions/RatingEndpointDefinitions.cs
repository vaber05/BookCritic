using BookCriticsAPI.Abstractions;
using BookCriticsApplication.Models;
using BookCriticsApplication.Modules.RatingModules.Commands;
using MediatR;

namespace BookCriticsAPI.EndpointDefinitions;

public class RatingEndpointDefinitions : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        var rating = app.MapGroup("/rating");

        rating.MapPost("/Post", async (IMediator mediator, RatingDto ratingToPost) =>
        {
            var postCommand = new PostRating { RatingToPost = ratingToPost };
            var result = await mediator.Send(postCommand);

            return result ? Results.Ok() : Results.BadRequest();
        });

        rating.MapDelete("/Delete/{bookId}/{userId}", async (IMediator mediator, int bookId, int userId) =>
        {
            var deleteCommand = new DeleteRating { BookId = bookId, UserId = userId };
            var result = await mediator.Send(deleteCommand);

            return result ? Results.Ok() : Results.NotFound();
        });

        rating.MapPatch("Edit", async (IMediator mediator, RatingDto ratingToEdit) =>
        {
            var patchCommand = new PatchRating { RatingToPatch = ratingToEdit };
            var result = await mediator.Send(patchCommand);

            return result ? Results.Ok() : Results.BadRequest();
        });
    }
}
