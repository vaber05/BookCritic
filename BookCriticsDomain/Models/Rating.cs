namespace BookCriticsDomain.Models;

public class Rating
{
    public float RatingValue { get; set; }

    public int UserId { get; set; }

    public int BookId { get; set; }
}