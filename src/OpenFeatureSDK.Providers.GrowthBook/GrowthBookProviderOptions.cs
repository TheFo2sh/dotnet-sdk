namespace OpenFeature.Providers.GrowthBook;

public class GrowthBookProviderOptions
{
    public Uri ServerUrl { get; set; } =new Uri( "https://api.growthbook.io");
    public string ApiKey { get; set; }
}
