using Azure.Storage.Blobs;
using BookCriticsApplication.Abstractions;
using BookCriticsApplication.Models.MLModelIO;
using Microsoft.Extensions.Configuration;
using Microsoft.ML;

namespace BookCriticsApplication.Commons.MLModels;

public class ReviewClassification : IMLModel<ModelInput, ModelOutput>
{
    private readonly IConfiguration configuration;
    private readonly ITransformer model;
    private readonly PredictionEngine<ModelInput, ModelOutput> predictionEngine;
    private readonly MLContext context = new();

    public ReviewClassification(IConfiguration configuration)
    {
        this.configuration = configuration;
        predictionEngine = CreatePredictionEngine(out model);
    }

    public ModelOutput Predict(ModelInput inputModel)
    {
        return predictionEngine.Predict(inputModel);
    }

    private async Task<ITransformer> LoadModel()
    {
        var containerClient = new BlobContainerClient(configuration["StorageConnString"], configuration["MLModelStorageContainer"]);
        var client = containerClient.GetBlobClient("Model.zip");

        Stream modelData = await client.OpenReadAsync();

        return context.Model.Load(modelData, out _);
    }

    private PredictionEngine<ModelInput, ModelOutput> CreatePredictionEngine(out ITransformer model)
    {
        model = LoadModel().Result;
        return context.Model.CreatePredictionEngine<ModelInput, ModelOutput>(model);
    }
}
