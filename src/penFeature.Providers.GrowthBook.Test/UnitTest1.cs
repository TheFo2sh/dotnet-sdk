using System.Threading.Tasks;
using FluentAssertions;
using Humanizer;
using Microsoft.Extensions.DependencyInjection;
using OpenFeature.Providers.GrowthBook;
using OpenFeature.ServiceCollection;
using OpenFeature.ServiceCollection.Feature;
using Xunit;

namespace penFeature.Providers.GrowthBook.Test;

public class GrowthBookProviderTest
{
    [Fact]
    public async Task Test1()
    {
        var services = new ServiceCollection();
        services.AddGrowthBookProvider(options =>
        {
            options.ApiKey = "key_prod_5950b3ee0318bea5";
        });

        services.AddOpenFeature(option =>
        {
            option.PropertyNameResolver = (propertyName) => propertyName.Kebaberize();
            option.UseGrowthBookProvider();
        }) ;

       var provider= services.BuildServiceProvider();
       var systemFeatures =await provider.GetRequiredService<IFeatures<SystemFeatures>>().GetValueAsync();

       systemFeatures.legacydex.Should().BeTrue();
       systemFeatures.NumberOfAgents.Should().Be(4);
    }
}
