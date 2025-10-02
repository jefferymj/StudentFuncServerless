using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudentFunc.Models.School;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
// builder.Services
    // .AddApplicationInsightsTelemetryWorkerService()
    // .ConfigureFunctionsApplicationInsights();


// Add Entity Framework DbContext
builder.Services.AddDbContext<SchoolContext>(options =>
{
var connectionString =
Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");
options.UseSqlServer(connectionString);
});
// Add HttpClient as singleton
builder.Services.AddSingleton<HttpClient>();

builder.Build().Run();