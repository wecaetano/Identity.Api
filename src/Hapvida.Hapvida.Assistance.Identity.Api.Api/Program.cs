using Hapvida.Core.Infra.OpenTelemetry.Exporter.Azure;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddAppContext<Program>(configuration);
builder.Services.AddDomainContext(configuration);

//builder.Services.AddMongoContext(configuration);

builder.Services.AddOpenTelemetryContext(configuration);
builder.Host.UseOpenTelemetryContext();

var app = builder.Build();
app.UseApplicationContext();
app.Run();