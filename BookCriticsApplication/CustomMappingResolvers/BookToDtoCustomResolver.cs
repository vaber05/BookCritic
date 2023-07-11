using AutoMapper;
using BookCriticsApplication.ModelDtos;
using BookCriticsDomain.Models;

namespace BookCriticsApplication.CustomMappingResolvers;

public class BookToDtoCustomResolver : IValueResolver<Book, BookDto, ICollection<int>>
{
    public ICollection<int> Resolve(Book source, BookDto destination, ICollection<int> destMember, ResolutionContext context)
    {
        foreach (var genre in source.Genres.ToList())
            destMember.Add(genre.GenreId);

        return destMember;
    }
}
