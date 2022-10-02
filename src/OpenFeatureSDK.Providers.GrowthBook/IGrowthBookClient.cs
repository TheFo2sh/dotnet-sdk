using Refit;

namespace OpenFeature.Providers.GrowthBook;

internal interface IGrowthBookClient
{
    [Get("/api/features/{apiKey}")]
    Task<FeaturesResponse> GetFeatureAsync(string apiKey);
}
