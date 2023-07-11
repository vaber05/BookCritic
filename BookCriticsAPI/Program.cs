using BookCriticsAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices();
builder.RegisterDependencyInjections();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));

app.RegisterEndpointDefinitions();

app.UseHttpsRedirection();

app.Run();