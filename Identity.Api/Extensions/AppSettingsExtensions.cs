namespace Identity.Api.Extensions;

public static class AppSettingsExtensions
{
    public static void ConfigureAppSettings(this WebApplicationBuilder builder)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

        string FullJsonFilePath(string fileName) => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

        builder.Configuration
            .AddJsonFile(FullJsonFilePath("appsettings.Shared.json"), true)
            .AddJsonFile(FullJsonFilePath("appsettings.json"), true)
            .AddJsonFile(FullJsonFilePath($"appsettings.Shared.{environment}.json"), true)
            .AddJsonFile(FullJsonFilePath($"appsettings.{environment}.json"), true);
    }
}