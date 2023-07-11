using Microsoft.ML.Data;

namespace BookCriticsApplication.Models.MLModelIO;

public class ModelInput
{
    public string? Review;

    [ColumnName("Label")]
    public bool Sentiment;
}
