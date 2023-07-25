using AutoMapper;
using BookCriticsAPI.Abstractions;
using BookCriticsApplication;
using BookCriticsApplication.Abstractions;
using BookCriticsApplication.Commons.MLModels;
using BookCriticsApplication.Models.MLModelIO;
using BookCriticsApplication.Modules.BookModules.CommandHandlers;
using BookCriticsInfrastructure;
using BookCriticsInfrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ML;

namespace BookCriticsAPI.Extensions;

public static class ApiExtensions
{
    public static void RegisterEndpointDefinitions(this WebApplication app)
    {
        var endpointDefinitions = typeof(Program).Assembly
            .GetTypes().Where(t => t.IsAssignableTo(typeof(IEndpointDefinition)) && !t.IsAbstract && !t.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<IEndpointDefinition>();

        foreach (var endpointDefinition in endpointDefinitions)
        {
            endpointDefinition.RegisterEndpoints(app);
        }
    }

    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        var connString = builder.Configuration["SqlConnString"];
        builder.Services.AddDbContext<BookCriticsDbContext>(opt => opt.UseSqlServer(connString));

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
    }

    public static void RegisterDependencyInjections(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IBookRepository, BookRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
        builder.Services.AddScoped<IRatingRepository, RatingRepository>();
        builder.Services.AddSingleton<IMLModel<ModelInput, ModelOutput>, ReviewClassification>();
    }
}
