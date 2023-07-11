namespace BookCriticsApplication.ModelDtos;

public class BookDto
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Author { get; set; }

    public int NumberOfPages { get; set; }

    public int ReleaseYear { get; set; }

    public ICollection<int> GenreIds { get; set; } = new List<int>();
}
