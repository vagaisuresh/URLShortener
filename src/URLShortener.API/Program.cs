using URLShortener.API.DependencyInjection;
using URLShortener.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppDbContext();
builder.Services.AddCorsPolicies();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddAuthorization();
builder.Services.AddShortUrlSettings(builder.Configuration);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

var app = builder.Build();

app.UseCors("BlazorCorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapAllEndpoints();

app.Run();
