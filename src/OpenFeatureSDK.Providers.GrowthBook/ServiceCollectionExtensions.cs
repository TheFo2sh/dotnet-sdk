using Microsoft.Extensions.DependencyInjection;
using OpenFeature.ServiceCollection;
using OpenFeatureSDK;
using Refit;

namespace OpenFeature.Providers.GrowthBook;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGrowthBookProvider(this IServiceCollection services, Action<GrowthBookProviderOptions> options)
    {
        services.Configure(options);

        var data = new GrowthBookProviderOptions();
        options(data);

        services.AddRefitClient<IGrowthBookClient>()
            .ConfigureHttpClient(client => client.BaseAddress = data.ServerUrl);

        services.AddTransient<GrowthBookFeatureProvider>();
        return services;
    }
    public static void UseGrowthBookProvider(this OpenFeatureOption option)
    {
        option.FeatureProvider = typeof(GrowthBookFeatureProvider);
    }
}
