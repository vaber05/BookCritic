using Microsoft.ML;

namespace BookCriticsApplication.Abstractions;

public interface IMLModel<in TInputModel, out TOutputModel> where TInputModel : class where TOutputModel : class
{
    public TOutputModel Predict(TInputModel inputModel);
}
