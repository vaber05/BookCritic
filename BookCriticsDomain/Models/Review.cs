namespace BookCriticsDomain.Models;

public class Review
{
    public int Id { get; set; }

    public int BookId { get; set; }

    public int UserId { get; set; }

    public int NumberOfLikes { get; set; }

    public string? Content { get; set; }

    public bool? IsPositive { get; set; }

    public DateTime? LastUpdated { get; set; }
}
