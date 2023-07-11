using BookCriticsApplication.ModelDtos;

namespace BookCriticsApplication.Models;

public class BookProfile
{
    public BookDto? Book { get; set; }

    public int? NumberOfLikes { get; set; }

    public int? NumberOfComments { get; set; }

    public int? TotalRatings { get; set; }

    public float? AvarageRating { get; set; }
}
