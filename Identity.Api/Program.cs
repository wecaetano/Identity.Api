using Identity.Api.Extensions;
using Identity.Core.Entities;
using Identity.CrossCutting;
using Identity.Infrastructure.Data;

GlobalSettings.Apply();

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureAppSettings();

builder.Services.ConfigureDependencyInjection();

builder.Services.AddDataBase();

builder.Services.AddIdentity<User, Role>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AppDataContext>();

builder.Services.ConfigureAuthentication();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.ConfigureApiVersioning();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureSwagger();

var app = builder.Build();

app.ConfigureSwaggerUi();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
