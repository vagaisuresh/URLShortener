using URLShortener.API.DIs;
using URLShortener.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureSqlContext();
builder.Services.ConfigureToBindDependencies();

var app = builder.Build();

app.MapShortUrlEndpoints();

app.Run();
