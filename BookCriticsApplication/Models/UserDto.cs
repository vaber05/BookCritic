namespace BookCriticsApplication.ModelDtos;

public class UserDto
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Password { get; set; }

    public string? Username { get; set; }


    //public DateTime? CreatedDate { get; set; }

    //public DateTime? LastLoggin { get; set; }

    //public ICollection<int> ReviewedBooks { get; set; } = new List<int>();

    //public ICollection<int> LikedBooks { get; set; } = new List<int>();

    //public ICollection<int> RatedBooks { get; set; } = new List<int>();
}
