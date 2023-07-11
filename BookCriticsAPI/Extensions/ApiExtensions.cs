using AutoMapper;
using BookCriticsAPI.Abstractions;
using BookCriticsApplication;
using BookCriticsApplication.Abstractions;
using BookCriticsApplication.Modules.BookModules.CommandHandlers;
using BookCriticsInfrastructure;
using BookCriticsInfrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML.Data;
using Microsoft.Extensions.ML;
using BookCriticsApplication.Models.MLModelIO;
using BookCriticsApplication.Commons.MLModels;

namespace BookCriticsAPI.Extensions;

public static class ApiExtensions
{
    public static void RegisterEndpointDefinitions(this WebApplication app)
    {
        var endpointDefinitions = typeof(Program).Assembly
            .GetTypes().Where(t => t.IsAssignableTo(typeof(IEndpointDefinition)) && !t.IsAbstract && !t.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<IEndpointDefinition>();

        foreach(var endpointDefinition in endpointDefinitions)
        {
            endpointDefinition.RegisterEndpoints(app);
        }
    }

    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        try
        {
            var conString = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<BookCriticsDbContext>(opt => opt.UseSqlServer(conString));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new ModelProfiles()));
        IMapper mapper = mapperConfig.CreateMapper();
        builder.Services.AddSingleton(mapper);

        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(PatchBookHandler).Assembly));

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new() { Title = "Swagger", Version = "v1" });
        });

        builder.Services.AddPredictionEnginePool<ModelInput, ModelOutput>()
            .FromFile(modelName: "SentimentAnalysis", filePath: @"D:\Models\ReviewClassification\Model.zip", watchForChanges: true);

        builder.Services.AddSingleton<IMLModel<ModelInput, ModelOutput>, ReviewClassification>();
    }

    public static void RegisterDependencyInjections(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IBookRepository, BookRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
        builder.Services.AddScoped<IRatingRepository, RatingRepository>();
    }
}
