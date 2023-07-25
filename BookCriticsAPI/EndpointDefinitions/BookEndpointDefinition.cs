using BookCriticsAPI.Abstractions;
using BookCriticsApplication.ModelDtos;
using BookCriticsApplication.Models;
using BookCriticsApplication.Modules.BookModules.Commands;
using BookCriticsApplication.Modules.BookProfileModules.Queries;
using MediatR;

namespace BookCriticsAPI.EndpointDefinitions;

public class BookEndpointDefinition : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        var book = app.MapGroup("/book");

        book.MapGet("/GetAllProfiles", async (IMediator mediator) =>
        {
            var getQuery = new GetAllBookProfiles();
            var result = await mediator.Send(getQuery);

            return Results.Ok(result);
        });

        book.MapGet("/GetProfileById/{id}", async (IMediator mediator, int id) =>
        {
            var getQuery = new GetBookProfileByBookId { BookId = id };
            var result = await mediator.Send(getQuery);

            return Results.Ok(result);
        });

        book.MapPost("/Post", async (IMediator mediator, BookDto bookToPost) =>
        {
            var postCommand = new PostBook { BookToCreate = bookToPost };
            var result = await mediator.Send(postCommand);

            return result ? Results.Ok() : Results.BadRequest();
        });

        book.MapPatch("/Edit", async (IMediator mediator, BookDto bookToPatch) =>
        {
            var patchCommand = new PatchBook { NewBook = bookToPatch };
            var result = await mediator.Send(patchCommand);

            return result ? Results.Ok() : Results.BadRequest();
        });

        book.MapDelete("/Delete/{id}", async (IMediator mediator, int id) =>
        {
            var deleteCommand = new RemoveBook { BookId = id };
            var result = await mediator.Send(deleteCommand);

            return result ? Results.Ok() : Results.BadRequest();
        });

        book.MapPatch("/AddBookToGenre/{bookId}/{genreId}", async (IMediator mediator, int bookId, int genreId) =>
        {
            var patchCommand = new AddBookToGenre { BookId = bookId, GenreId = genreId };
            var result = await mediator.Send(patchCommand);

            return result ? Results.Ok() : Results.BadRequest();
        });

        book.MapPatch("/RemoveBookFromGenre/{bookId}/{genreId}", async (IMediator mediator, int bookId, int genreId) =>
        {
            var patchCommand = new RemoveBookFromGenre { BookId = bookId, GenreId = genreId };
            var result = await mediator.Send(patchCommand);

            return result ? Results.Ok() : Results.BadRequest();
        });

        book.MapPatch("/ChangeGenre/{bookId}/{oldGenreId}/{newGenreId}", async (IMediator mediator, int bookId,int oldGenreId, int newGenreId) =>
        {
            var patchCommand = new ChangeBookGenre { BookId = bookId, OldBookGenre = oldGenreId, NewBookGenre = newGenreId };
            var result = await mediator.Send(patchCommand);

            return result ? Results.Ok() : Results.BadRequest();
        });
    }
}