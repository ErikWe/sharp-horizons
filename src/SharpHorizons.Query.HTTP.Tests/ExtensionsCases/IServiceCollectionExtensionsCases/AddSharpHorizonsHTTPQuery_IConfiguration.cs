namespace SharpHorizons.Tests.QueryCases.ExtensionsCases.IServiceCollectionExtensionsCases;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Moq;

using SharpHorizons.Extensions.Query.HTTP;
using SharpHorizons.Query.Request.HTTP;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Xunit;

public class AddSharpHorizonsHTTPQuery_IConfiguration
{
    [Fact]
    public void Null_ArgumentNullException()
    {
        var services = GetServiceCollection();

        IConfiguration configuration = null!;

        var exception = Record.Exception(() => services.AddSharpHorizonsHTTPQuery(configuration));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Valid_ReturnsSameServiceCollectionInstance()
    {
        var expected = GetServiceCollection();

        var configuration = GetConfiguration();

        var actual = expected.AddSharpHorizonsHTTPQuery(configuration);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Valid_UsingCustomConfiguration()
    {
        var host = GetConfiguredHost();

        var httpAddressProvider = host.Services.GetRequiredService<IHorizonsHTTPAddressProvider>();

        Assert.Equal(CustomConfiguration.ExpectedHorizonsHTTPAddressProvider.HTTPAddress, httpAddressProvider.HTTPAddress);
    }

    private static IServiceCollection GetServiceCollection() => new ServiceCollection();

    private static IConfiguration GetConfiguration()
    {
        var mock = new Mock<IConfiguration>();
        var sectionMock = new Mock<IConfigurationSection>();

        mock.Setup((obj) => obj.GetSection(It.IsAny<string>())).Returns(sectionMock.Object);

        return mock.Object;
    }

    private static IHost GetConfiguredHost()
    {
        var host = Host.CreateDefaultBuilder().ConfigureAppConfiguration(configureConfiguration).ConfigureServices(configureServices).Build();

        host.Start();

        return host;

        static void configureConfiguration(IConfigurationBuilder configuration) => configuration.AddInMemoryCollection(CustomConfiguration.Dictionary);
        static void configureServices(HostBuilderContext context, IServiceCollection services) => services.AddSharpHorizonsHTTPQuery(context.Configuration);
    }

    private static class CustomConfiguration
    {
        public static IReadOnlyDictionary<string, string?> Dictionary { get; }

        public static IHorizonsHTTPAddressProvider ExpectedHorizonsHTTPAddressProvider { get; }

        private static (string, Expression<Func<IHorizonsHTTPAddressProvider, Uri>>)[] HorizonsHTTPAddressProviderKeys { get; } = new (string, Expression<Func<IHorizonsHTTPAddressProvider, Uri>>)[]
        {
            ("HorizonsHTTPAddress", (provider) => provider.HTTPAddress)
        };

        static CustomConfiguration()
        {
            Dictionary<string, string?> dictionary = new(HorizonsHTTPAddressProviderKeys.Length);

            Mock<IHorizonsHTTPAddressProvider> horizonsHTTPAddressProviderMock = new();

            foreach (var (key, action) in HorizonsHTTPAddressProviderKeys)
            {
                var result = $"https://www.random.org/?{key}";

                dictionary[key] = result;
                horizonsHTTPAddressProviderMock.SetupGet(action).Returns(new Uri(result));
            }

            Dictionary = dictionary;

            ExpectedHorizonsHTTPAddressProvider = horizonsHTTPAddressProviderMock.Object;
        }
    }
}
