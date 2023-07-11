using AutoMapper;
using BookCriticsApplication.Abstractions;
using BookCriticsApplication.ModelDtos;
using BookCriticsApplication.Models;
using BookCriticsApplication.Modules.BookProfileModules.Queries;
using BookCriticsDomain.Models;
using MediatR;
using System.Collections.Generic;

namespace BookCriticsApplication.Modules.BookProfileModules.QueryHandlers;

public class GetBookProfileByBookIdHandler : IRequestHandler<GetBookProfileByBookId, BookProfile>
{
    private readonly IBookRepository repository;
    private readonly IMapper mapper;

    public GetBookProfileByBookIdHandler(IBookRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<BookProfile> Handle(GetBookProfileByBookId request, CancellationToken cancellationToken)
    {
        var book = await repository.GetBookById(request.BookId);

        if (book.Id == 0)
            return new BookProfile();

        return new BookProfile
        {
            Book = mapper.Map<BookDto>(book),
            AvarageRating = CalculateRatingAvarage(book.Ratings.ToList()),
            NumberOfLikes = book.LikedByUsers!.Count,
            TotalRatings = book.Ratings!.Count,
            NumberOfComments = book.Reviews.Count,
        };
    }

    private static float CalculateRatingAvarage(List<Rating> ratings)
    {
        if (ratings.Count == 0)
            return 0;

        float totalRatingValueSum = 0;

        foreach (var rating in ratings)
        {
            totalRatingValueSum += rating.RatingValue;
        }

        return totalRatingValueSum / ratings.Count;
    }
}
