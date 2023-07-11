using AutoMapper;
using BookCriticsApplication.Abstractions;
using BookCriticsApplication.ModelDtos;
using BookCriticsApplication.Models;
using BookCriticsApplication.Modules.BookProfileModules.Queries;
using BookCriticsDomain.Models;
using MediatR;

namespace BookCriticsApplication.Modules.BookProfileModules.QueryHandlers;

public class GetAllBookProfilesHandler : IRequestHandler<GetAllBookProfiles, List<BookProfile>>
{
    private readonly IBookRepository repository;
    private readonly IMapper mapper;

    public GetAllBookProfilesHandler(IMapper mapper, IBookRepository repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public async Task<List<BookProfile>> Handle(GetAllBookProfiles request, CancellationToken cancellationToken)
    {
        var books = new List<Book>();

        try
        {
            books = await repository.GetAllBooks();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        var bookProfiles = new List<BookProfile>();

        foreach (var book in books)
        {
            bookProfiles.Add(new BookProfile
            {
                Book = mapper.Map<BookDto>(book),
                AvarageRating = CalculateRatingAvarage(book.Ratings.ToList()),
                NumberOfLikes = book.LikedByUsers!.Count,
                TotalRatings = book.Ratings!.Count,
                NumberOfComments = book.Reviews!.Count,
            });
        }

        return bookProfiles;
    }

    private static float CalculateRatingAvarage(List<Rating> ratings)
    {
        if(ratings.Count == 0)
            return 0;

        float totalRatingValueSum = 0;

        foreach (var rating in ratings)
        {
            totalRatingValueSum += rating.RatingValue;
        }

        return totalRatingValueSum / ratings.Count;
    }
}
