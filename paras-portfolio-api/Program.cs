global using paras_portfolio_api.Models;
using paras_portfolio_api.AuthFilters;
using paras_portfolio_api.Services;
using paras_portfolio_api.Services.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<PortfolioDatabaseSettings>(
    builder.Configuration.GetSection("PortfolioDatabaseSettings"));

builder.Services.AddScoped<IPortfolioMessageService, PortfolioMessageService>();
builder.Services.AddSingleton<ApiKeyAuthorizationFilter>();
builder.Services.AddSingleton<IApiKeyValidator, ApiKeyValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
