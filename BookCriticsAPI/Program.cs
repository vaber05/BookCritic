using BookCriticsAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterDependencyInjections();
builder.RegisterServices();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));

app.RegisterEndpointDefinitions();

app.UseHttpsRedirection();

app.Run();