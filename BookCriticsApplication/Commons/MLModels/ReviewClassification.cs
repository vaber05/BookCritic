using BookCriticsApplication.Abstractions;
using BookCriticsApplication.Models.MLModelIO;
using Microsoft.Extensions.Configuration;
using Microsoft.ML;

namespace BookCriticsApplication.Commons.MLModels;

public class ReviewClassification : IMLModel<ModelInput, ModelOutput>
{
    private readonly MLContext context = new();
    private readonly ITransformer model;
    private readonly PredictionEngine<ModelInput, ModelOutput> predictionEngine;
    private readonly IConfiguration configuration;

    public ReviewClassification(IConfiguration configuration)
    {
        this.configuration = configuration;
        model = LoadModel();
        predictionEngine = context.Model.CreatePredictionEngine<ModelInput, ModelOutput>(model);
    }

    public ModelOutput Predict(ModelInput inputModel)
    {
        return predictionEngine.Predict(inputModel);
    }

    private ITransformer LoadModel()
    {
        var path = configuration["MLModelPaths:ReviewClassificationPath"];

        return context.Model.Load(path, out DataViewSchema inputSchema);
    }
}
