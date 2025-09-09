using URLShortener.API.DependencyInjection;
using URLShortener.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddShortUrlSettings(builder.Configuration);
builder.Services.AddAppDbContext();
builder.Services.AddCorsPolicies();
builder.Services.AddApplicationServices();

var app = builder.Build();

app.UseCors("BlazorCorsPolicy");

app.MapShortUrlEndpoints();

app.Run();
