using AutoMapper;
using BookCriticsApplication.ModelDtos;
using BookCriticsDomain.Enums;
using BookCriticsDomain.Models;

namespace BookCriticsApplication.CustomMappingResolvers;

public class DtoToBookCustomResolver : IValueResolver<BookDto, Book, ICollection<BookInGenre>>
{
    public ICollection<BookInGenre> Resolve(BookDto source, Book destination, ICollection<BookInGenre> destMember, ResolutionContext context)
    {
        foreach (var genreId in source.GenreIds)
        {
            destMember.Add(new BookInGenre
            {
                BookId = source.Id,
                GenreId = genreId,
            });
        }

        return destMember;
    }
}
