using AutoMapper;
using BookCriticsApplication.CustomMappingResolvers;
using BookCriticsApplication.ModelDtos;
using BookCriticsApplication.Models;
using BookCriticsDomain.Models;

namespace BookCriticsApplication;

public class ModelProfiles : Profile
{
    public ModelProfiles()
    {
        CreateMap<Book, BookDto>()
            .ForMember(b => b.Author, o => o.Condition(source => source.Author != "string"))
            .ForMember(b => b.Description, o => o.Condition(source => source.Description != "string"))
            .ForMember(b => b.Title, o => o.Condition(source => source.Title != "string"))
            .ForMember(b => b.NumberOfPages, o => o.Condition(source => source.NumberOfPages != 0))
            .ForMember(b => b.ReleaseYear, o => o.Condition(source => source.ReleaseYear != default))
            .ForMember(b => b.GenreIds, o => o.MapFrom<BookToDtoCustomResolver>());

        CreateMap<BookDto, Book>()
            .ForMember(b => b.Author, o => o.Condition(source => source.Author != "string"))
            .ForMember(b => b.Description, o => o.Condition(source => source.Description != "string"))
            .ForMember(b => b.Title, o => o.Condition(source => source.Title != "string"))
            .ForMember(b => b.NumberOfPages, o => o.Condition(source => source.NumberOfPages != 0))
            .ForMember(b => b.ReleaseYear, o => o.Condition(source => source.ReleaseYear != default))
            .ForMember(b => b.Genres, o => o.MapFrom<DtoToBookCustomResolver>());

        CreateMap<Review, ReviewDto>()
            .ReverseMap()
            .ForAllMembers(opt => opt.Condition(src => src != null));

        CreateMap<Rating, RatingDto>()
            .ReverseMap()
            .ForAllMembers(opt => opt.Condition(src => src != null));

        CreateMap<User, UserDto>()
            .ForMember(u => u.FirstName, o => o.Condition(source => source.FirstName != "string" || source.FirstName is null))
            .ForMember(u => u.LastName, o => o.Condition(source => source.LastName != "string" || source.LastName is null))
            .ForMember(u => u.Username, o => o.Condition(source => source.Username != "string" || source.Username is null))
            .ForMember(u => u.Password, o => o.Condition(source => source.Password != "string" || source.Password is null));

        CreateMap<UserDto, User>()
            .ForMember(u => u.FirstName, o => o.Condition(source => source.FirstName != "string" || source.FirstName is null))
            .ForMember(u => u.LastName, o => o.Condition(source => source.LastName != "string" || source.LastName is null))
            .ForMember(u => u.Username, o => o.Condition(source => source.Username != "string" || source.Username is null))
            .ForMember(u => u.Password, o => o.Condition(source => source.Password != "string" || source.Password is null));
    }
}
