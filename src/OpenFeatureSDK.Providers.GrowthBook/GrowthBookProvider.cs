using Microsoft.Extensions.Options;
using OpenFeatureSDK;
using OpenFeatureSDK.Constant;
using OpenFeatureSDK.Model;

namespace OpenFeature.Providers.GrowthBook;

internal class GrowthBookFeatureProvider : FeatureProvider
{
    private readonly IGrowthBookClient _client;
    private readonly string _apikey;

    public GrowthBookFeatureProvider(IGrowthBookClient client, IOptions<GrowthBookProviderOptions> options)
    {
        this._client = client;
        this._apikey = options.Value.ApiKey;
    }

    public override Metadata GetMetadata() => new("GrowthBook");

    public override async Task<ResolutionDetails<bool>> ResolveBooleanValue(string flagKey, bool defaultValue,
        EvaluationContext context = null)
    {
        return await this.GetResolutionDetails(flagKey, defaultValue);

    }

    public override async Task<ResolutionDetails<string>> ResolveStringValue(string flagKey, string defaultValue,
        EvaluationContext context = null)
    {
        return await this.GetResolutionDetails(flagKey, defaultValue);
    }

    public override async Task<ResolutionDetails<int>> ResolveIntegerValue(string flagKey, int defaultValue,
        EvaluationContext context = null)
    {
        return await this.GetResolutionDetails(flagKey, defaultValue);
    }

    public override async Task<ResolutionDetails<double>> ResolveDoubleValue(string flagKey, double defaultValue,
        EvaluationContext context = null)
    {
        return await this.GetResolutionDetails(flagKey, defaultValue);

    }

    public override async Task<ResolutionDetails<Value>> ResolveStructureValue(string flagKey, Value defaultValue,
        EvaluationContext context = null)
    {
        return await this.GetResolutionDetails(flagKey, defaultValue);

    }

    private async Task<ResolutionDetails<T>> GetResolutionDetails<T>(string flagKey, T defaultValue)
    {
        try
        {
            var response = await this._client.GetFeatureAsync(this._apikey);
            return response.Status != 200
                ? new ResolutionDetails<T>(flagKey, defaultValue, ErrorType.ProviderNotReady)
                : response.Features.ContainsKey(flagKey)
                    ? new ResolutionDetails<T>(flagKey, (T)Convert.ChangeType(response.Features[flagKey].DefaultValue,typeof(T)), ErrorType.None)
                    : new ResolutionDetails<T>(flagKey, defaultValue, ErrorType.FlagNotFound);
        }
        catch (Exception e)
        {
            return new ResolutionDetails<T>(flagKey, defaultValue, ErrorType.General, e.Message);
        }
    }
}


