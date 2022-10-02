﻿namespace OpenFeature.ServiceCollection;

public class OpenFeatureOption
{
    internal Type? FeatureProvider { get; set; }
    public string Name { get; set; }
    public string Version { get; set; }
    public IEnumerable<Type> Hooks { get; set; } = Enumerable.Empty<Type>();


}
