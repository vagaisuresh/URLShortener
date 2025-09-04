using URLShortener.API.DependencyInjection;
using URLShortener.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppDbContext();
builder.Services.AddApplicationServices();

var app = builder.Build();

app.MapShortUrlEndpoints();

app.Run();
