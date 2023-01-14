namespace SharpHorizons.Tests.QueryCases.ExtensionsCases.IServiceCollectionExtensionsCases;

using Microsoft.Extensions.DependencyInjection;

using SharpHorizons.Extensions.Query.HTTP;
using SharpHorizons.Query.Request.HTTP;

using Xunit;

public class AddSharpHorizonsHTTPQuery
{
    [Fact]
    public void ReturnsSameInstance()
    {
        var expected = GetServiceCollection();

        var actual = expected.AddSharpHorizonsHTTPQuery();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void UsingDefaultConfiguration()
    {
        var provider = GetServiceCollection().AddSharpHorizonsHTTPQuery().BuildServiceProvider();

        var httpAddressProvider = provider.GetRequiredService<IHorizonsHTTPAddressProvider>();

        Assert.Equal("https://ssd.jpl.nasa.gov/api/horizons.api", httpAddressProvider.HTTPAddress.ToString());
    }

    private static IServiceCollection GetServiceCollection() => new ServiceCollection();
}
