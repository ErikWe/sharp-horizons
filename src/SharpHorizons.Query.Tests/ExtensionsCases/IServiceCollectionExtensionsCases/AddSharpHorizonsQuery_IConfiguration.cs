namespace SharpHorizons.Tests.QueryCases.ExtensionsCases.IServiceCollectionExtensionsCases;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Moq;

using SharpHorizons.Extensions.Query;
using SharpHorizons.Query.Parameters;
using SharpHorizons.Query.Result;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Xunit;

public class AddSharpHorizonsQuery_IConfiguration
{
    [Fact]
    public void Null_ArgumentNullException()
    {
        var services = GetServiceCollection();

        IConfiguration configuration = null!;

        var exception = Record.Exception(() => services.AddSharpHorizonsQuery(configuration));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Valid_ReturnsSameServiceCollectionInstance()
    {
        var expected = GetServiceCollection();

        var configuration = GetConfiguration();

        var actual = expected.AddSharpHorizonsQuery(configuration);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Valid_UsingCustomConfiguration()
    {
        var host = GetConfiguredHost();

        var queryResultOptions = host.Services.GetRequiredService<IQueryResultOptionsProvider>();

        Assert.Equal(CustomConfiguration.ExpectedQueryResultOptions.RawTextSource, queryResultOptions.RawTextSource);
        Assert.Equal(CustomConfiguration.ExpectedQueryResultOptions.RawTextVersion, queryResultOptions.RawTextVersion);

        var queryParameterIdentifierOptions = host.Services.GetRequiredService<IQueryParameterIdentifierProvider>();

        Assert.Equal(CustomConfiguration.ExpectedQueryParameterIdentifiers.Command.Identifier, queryParameterIdentifierOptions.Command.Identifier);
        Assert.Equal(CustomConfiguration.ExpectedQueryParameterIdentifiers.EphemerisType.Identifier, queryParameterIdentifierOptions.EphemerisType.Identifier);
        Assert.Equal(CustomConfiguration.ExpectedQueryParameterIdentifiers.EpochCollection.Identifier, queryParameterIdentifierOptions.EpochCollection.Identifier);
        Assert.Equal(CustomConfiguration.ExpectedQueryParameterIdentifiers.EpochCollectionFormat.Identifier, queryParameterIdentifierOptions.EpochCollectionFormat.Identifier);
        Assert.Equal(CustomConfiguration.ExpectedQueryParameterIdentifiers.GenerateEphemeris.Identifier, queryParameterIdentifierOptions.GenerateEphemeris.Identifier);
        Assert.Equal(CustomConfiguration.ExpectedQueryParameterIdentifiers.ObjectDataInclusion.Identifier, queryParameterIdentifierOptions.ObjectDataInclusion.Identifier);
        Assert.Equal(CustomConfiguration.ExpectedQueryParameterIdentifiers.Origin.Identifier, queryParameterIdentifierOptions.Origin.Identifier);
        Assert.Equal(CustomConfiguration.ExpectedQueryParameterIdentifiers.OriginCoordinate.Identifier, queryParameterIdentifierOptions.OriginCoordinate.Identifier);
        Assert.Equal(CustomConfiguration.ExpectedQueryParameterIdentifiers.OriginCoordinateType.Identifier, queryParameterIdentifierOptions.OriginCoordinateType.Identifier);
        Assert.Equal(CustomConfiguration.ExpectedQueryParameterIdentifiers.OutputFormat.Identifier, queryParameterIdentifierOptions.OutputFormat.Identifier);
        Assert.Equal(CustomConfiguration.ExpectedQueryParameterIdentifiers.OutputUnits.Identifier, queryParameterIdentifierOptions.OutputUnits.Identifier);
        Assert.Equal(CustomConfiguration.ExpectedQueryParameterIdentifiers.ReferencePlane.Identifier, queryParameterIdentifierOptions.ReferencePlane.Identifier);
        Assert.Equal(CustomConfiguration.ExpectedQueryParameterIdentifiers.ReferenceSystem.Identifier, queryParameterIdentifierOptions.ReferenceSystem.Identifier);
        Assert.Equal(CustomConfiguration.ExpectedQueryParameterIdentifiers.StartEpoch.Identifier, queryParameterIdentifierOptions.StartEpoch.Identifier);
        Assert.Equal(CustomConfiguration.ExpectedQueryParameterIdentifiers.StepSize.Identifier, queryParameterIdentifierOptions.StepSize.Identifier);
        Assert.Equal(CustomConfiguration.ExpectedQueryParameterIdentifiers.StopEpoch.Identifier, queryParameterIdentifierOptions.StopEpoch.Identifier);
        Assert.Equal(CustomConfiguration.ExpectedQueryParameterIdentifiers.TimeDeltaInclusion.Identifier, queryParameterIdentifierOptions.TimeDeltaInclusion.Identifier);
        Assert.Equal(CustomConfiguration.ExpectedQueryParameterIdentifiers.TimePrecision.Identifier, queryParameterIdentifierOptions.TimePrecision.Identifier);
        Assert.Equal(CustomConfiguration.ExpectedQueryParameterIdentifiers.ValueSeparation.Identifier, queryParameterIdentifierOptions.ValueSeparation.Identifier);
        Assert.Equal(CustomConfiguration.ExpectedQueryParameterIdentifiers.VectorCorrection.Identifier, queryParameterIdentifierOptions.VectorCorrection.Identifier);
        Assert.Equal(CustomConfiguration.ExpectedQueryParameterIdentifiers.VectorLabels.Identifier, queryParameterIdentifierOptions.VectorLabels.Identifier);
        Assert.Equal(CustomConfiguration.ExpectedQueryParameterIdentifiers.VectorTableContent.Identifier, queryParameterIdentifierOptions.VectorTableContent.Identifier);
        Assert.Equal(CustomConfiguration.ExpectedQueryParameterIdentifiers.CalendarType.Identifier, queryParameterIdentifierOptions.CalendarType.Identifier);
        Assert.Equal(CustomConfiguration.ExpectedQueryParameterIdentifiers.TimeSystem.Identifier, queryParameterIdentifierOptions.TimeSystem.Identifier);
        Assert.Equal(CustomConfiguration.ExpectedQueryParameterIdentifiers.TimeZone.Identifier, queryParameterIdentifierOptions.TimeZone.Identifier);
    }

    private static IServiceCollection GetServiceCollection() => new ServiceCollection();

    private static IConfiguration GetConfiguration()
    {
        var mock = new Mock<IConfiguration>();
        var sectionMock = new Mock<IConfigurationSection>();

        mock.Setup(static (configuration) => configuration.GetSection(It.IsAny<string>())).Returns(sectionMock.Object);
        sectionMock.Setup(static (section) => section.GetSection(It.IsAny<string>())).Returns(sectionMock.Object);

        return mock.Object;
    }

    private static IHost GetConfiguredHost()
    {
        var host = Host.CreateDefaultBuilder().ConfigureAppConfiguration(configureConfiguration).ConfigureServices(configureServices).Build();

        host.Start();

        return host;

        static void configureConfiguration(IConfigurationBuilder configuration) => configuration.AddInMemoryCollection(CustomConfiguration.Dictionary);
        static void configureServices(HostBuilderContext context, IServiceCollection services) => services.AddSharpHorizonsQuery(context.Configuration);
    }

    private static class CustomConfiguration
    {
        public static IReadOnlyDictionary<string, string?> Dictionary { get; }

        public static IQueryResultOptionsProvider ExpectedQueryResultOptions { get; }
        public static IQueryParameterIdentifierProvider ExpectedQueryParameterIdentifiers { get; }

        private static (string, Expression<Func<IQueryResultOptionsProvider, string>>)[] QueryResultKeys { get; } = new (string, Expression<Func<IQueryResultOptionsProvider, string>>)[]
        {
            ("Result:RawTextSource", (provider) => provider.RawTextSource),
            ("Result:RawTextVersion", (provider) => provider.RawTextVersion)
        };

        private static (string, Expression<Func<IQueryParameterIdentifierProvider, string>>)[] QueryParameterIdentifierKeys { get; } = new (string, Expression<Func<IQueryParameterIdentifierProvider, string>>)[]
        {
            ("ParameterIdentifiers:Command", (provider) => provider.Command.Identifier),
            ("ParameterIdentifiers:EphemerisType", (provider) => provider.EphemerisType.Identifier),
            ("ParameterIdentifiers:EpochCollection", (provider) => provider.EpochCollection.Identifier),
            ("ParameterIdentifiers:EpochCollectionFormat", (provider) => provider.EpochCollectionFormat.Identifier),
            ("ParameterIdentifiers:GenerateEphemeris", (provider) => provider.GenerateEphemeris.Identifier),
            ("ParameterIdentifiers:ObjectDataInclusion", (provider) => provider.ObjectDataInclusion.Identifier),
            ("ParameterIdentifiers:Origin", (provider) => provider.Origin.Identifier),
            ("ParameterIdentifiers:OriginCoordinate", (provider) => provider.OriginCoordinate.Identifier),
            ("ParameterIdentifiers:OriginCoordinateType", (provider) => provider.OriginCoordinateType.Identifier),
            ("ParameterIdentifiers:OutputFormat", (provider) => provider.OutputFormat.Identifier),
            ("ParameterIdentifiers:OutputUnits", (provider) => provider.OutputUnits.Identifier),
            ("ParameterIdentifiers:ReferencePlane", (provider) => provider.ReferencePlane.Identifier),
            ("ParameterIdentifiers:ReferenceSystem", (provider) => provider.ReferenceSystem.Identifier),
            ("ParameterIdentifiers:StartEpoch", (provider) => provider.StartEpoch.Identifier),
            ("ParameterIdentifiers:StepSize", (provider) => provider.StepSize.Identifier),
            ("ParameterIdentifiers:StopEpoch", (provider) => provider.StopEpoch.Identifier),
            ("ParameterIdentifiers:TimeDeltaInclusion", (provider) => provider.TimeDeltaInclusion.Identifier),
            ("ParameterIdentifiers:TimePrecision", (provider) => provider.TimePrecision.Identifier),
            ("ParameterIdentifiers:ValueSeparation", (provider) => provider.ValueSeparation.Identifier),
            ("ParameterIdentifiers:VectorCorrection", (provider) => provider.VectorCorrection.Identifier),
            ("ParameterIdentifiers:VectorLabels", (provider) => provider.VectorLabels.Identifier),
            ("ParameterIdentifiers:VectorTableContent", (provider) => provider.VectorTableContent.Identifier),
            ("ParameterIdentifiers:CalendarType", (provider) => provider.CalendarType.Identifier),
            ("ParameterIdentifiers:TimeSystem", (provider) => provider.TimeSystem.Identifier),
            ("ParameterIdentifiers:TimeZone", (provider) => provider.TimeZone.Identifier)
        };

        static CustomConfiguration()
        {
            Dictionary<string, string?> dictionary = new(QueryResultKeys.Length + QueryParameterIdentifierKeys.Length);

            Mock<IQueryResultOptionsProvider> queryResultOptionsMock = new();
            Mock<IQueryParameterIdentifierProvider> queryParameterIdentifiersMock = new();

            foreach (var (key, action) in QueryResultKeys)
            {
                var result = $"CustomValue-{key}";

                dictionary[key] = result;
                queryResultOptionsMock.SetupGet(action).Returns(result);
            }

            foreach (var (key, action) in QueryParameterIdentifierKeys)
            {
                var result = $"CustomValue-{key}";

                dictionary[key] = result;
                queryParameterIdentifiersMock.SetupGet(action).Returns(result);
            }

            Dictionary = dictionary;

            ExpectedQueryResultOptions = queryResultOptionsMock.Object;
            ExpectedQueryParameterIdentifiers = queryParameterIdentifiersMock.Object;
        }
    }
}
