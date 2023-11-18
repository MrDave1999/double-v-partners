namespace Double.Partners.Extensions;

public static class DependenciesExtensions
{
    public static IServiceCollection RegisterUseCases(this IServiceCollection services)
    {
        services.Scan(scan => scan
        // Search the types from the specified assemblies.
            .FromAssemblies(typeof(DependenciesExtensions).Assembly)
              // Registers the concrete classes as a service, for example: 'LoginUserUseCase'.
              .AddClasses(classes => classes.Where(type => type.Name.EndsWith("UseCase")))
                .AsSelf()
                .WithTransientLifetime());

        return services;
    }
}
