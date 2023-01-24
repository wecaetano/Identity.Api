namespace Hapvida.Hapvida.Assistance.Identity.Api.Api;

public static class Bootstrapper
{
    //TODO Enable if need to use redis
    //public static IServiceCollection AddDistributedCache(this IServiceCollection services, IConfiguration configuration)
    //{
    //    var connectionString = configuration.GetValue<string>("Core:Cache:ConnectionString");
    //    var instanceName = configuration.GetValue<string>("Core:Cache:InstanceName");

    //    ArgumentNullException.ThrowIfNull(connectionString);
    //    ArgumentNullException.ThrowIfNull(instanceName);

    //    return services.AddStackExchangeRedisCache(op =>
    //    {
    //        op.Configuration = connectionString;
    //        op.InstanceName = instanceName;
    //    });
    //}
}