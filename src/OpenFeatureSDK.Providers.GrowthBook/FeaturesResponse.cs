namespace OpenFeature.Providers.GrowthBook;

internal record FeaturesResponse(int Status, Dictionary<string, Feature<object>> Features, DateTime DateUpdated);
