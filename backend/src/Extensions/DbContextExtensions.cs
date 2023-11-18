namespace Double.Partners.Extensions;

public static class DbContextExtensions
{
    public static IServiceCollection AddDatabaseContext(this IServiceCollection services)
    {
        string cs = EnvReader.Instance["DB_CONNECTION_STRING"];
        services.AddDbContext<DbContext, AppDbContext>(options =>
        {
            options.UseMySql(cs, ServerVersion.AutoDetect(cs));
        }).AddScoped<IDbConnection>(serviceProvider => new MySqlConnection(cs));

        return services;
    }
}
