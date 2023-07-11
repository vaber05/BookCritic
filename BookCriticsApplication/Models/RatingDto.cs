namespace BookCriticsApplication.Models;

public class RatingDto
{
    public float? RatingValue { get; set; }

    public int BookId { get; set; }

    public int UserId { get; set; }
}
