using BookCriticsAPI.Abstractions;
using BookCriticsApplication.ModelDtos;
using BookCriticsApplication.Modules.UserModules.Commands;
using BookCriticsApplication.Modules.UserModules.Queries;
using MediatR;

namespace BookCriticsAPI.EndpointDefinitions;

public class UserEndpointDefinition : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        var user = app.MapGroup("/user");

        user.MapGet("/GetById/{id}", async (IMediator mediator, int id) =>
        {
            var getQuery = new GetUserById { userId = id };
            var user = await mediator.Send(getQuery);

            return user.Id == 0 ? Results.NotFound() : Results.Ok(user);
        });

        user.MapGet("/GetAll", async (IMediator mediator) =>
        {
            var getQuery = new GetAllUsers();
            var users = await mediator.Send(getQuery);

            return Results.Ok(users);
        });

        user.MapPost("/Post", async (IMediator mediator, UserDto userToPost) =>
        {
            var postCommand = new PostUser { UserToPost = userToPost };
            var result = await mediator.Send(postCommand);

            return result ? Results.Ok() : Results.BadRequest();
        });

        user.MapDelete("/Delete/{id}", async (IMediator mediator, int id) =>
        {
            var deleteCommand = new DeleteUser { UserId = id };
            var result = await mediator.Send(deleteCommand);

            return result ? Results.Ok(result) : Results.NotFound();
        });

        user.MapPatch("/Update", async (IMediator mediator, UserDto userToPatch) =>
        {
            var patchCommand = new EditUser { UserToEdit = userToPatch };
            var result = await mediator.Send(patchCommand);

            return result ? Results.Ok() : Results.NotFound();
        });

        user.MapPost("/LikeBook", async (IMediator mediator, int userId, int bookId) =>
        {
            var postCommand = new LikeBook { UserId = userId, BookId = bookId };
            var result = await mediator.Send(postCommand);

            return result ? Results.Ok() : Results.BadRequest();
        });

        user.MapDelete("/UnlikeBook", async (IMediator mediator, int userId, int bookId) =>
        {
            var deleteCommand = new UnlikeBook { UserId = userId, BookId = bookId };
            var result = await mediator.Send(deleteCommand);

            return result ? Results.Ok() : Results.BadRequest();
        });

        user.MapPost("/LikeReview", async (IMediator mediator, int userId, int reviewId) =>
        {
            var postCommand = new LikeReview { UserId = userId, ReviewId = reviewId };
            var result = await mediator.Send(postCommand);

            return result ? Results.Ok() : Results.BadRequest();
        });

        user.MapDelete("/DeleteReview", async (IMediator mediator, int userId, int reviewId) =>
        {
            var postCommand = new UnlikeReview { UserId = userId, ReviewId = reviewId };
            var result = await mediator.Send(postCommand);

            return result ? Results.Ok() : Results.BadRequest();
        });
    }
}
