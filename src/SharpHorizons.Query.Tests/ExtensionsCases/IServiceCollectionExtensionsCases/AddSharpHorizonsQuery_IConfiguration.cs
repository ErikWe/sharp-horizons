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

        Assert.Equal(CustomConfiguration.RawTextSource, queryResultOptions.RawTextSource);
        Assert.Equal(CustomConfiguration.RawTextVersion, queryResultOptions.RawTextVersion);

        var queryParameterIdentifierOptions = host.Services.GetRequiredService<IQueryParameterIdentifierProvider>();

        Assert.Equal(CustomConfiguration.Command, queryParameterIdentifierOptions.Command.Identifier);
        Assert.Equal(CustomConfiguration.EphemerisType, queryParameterIdentifierOptions.EphemerisType.Identifier);
        Assert.Equal(CustomConfiguration.EpochCollection, queryParameterIdentifierOptions.EpochCollection.Identifier);
        Assert.Equal(CustomConfiguration.EpochCollectionFormat, queryParameterIdentifierOptions.EpochCollectionFormat.Identifier);
        Assert.Equal(CustomConfiguration.GenerateEphemeris, queryParameterIdentifierOptions.GenerateEphemeris.Identifier);
        Assert.Equal(CustomConfiguration.ObjectDataInclusion, queryParameterIdentifierOptions.ObjectDataInclusion.Identifier);
        Assert.Equal(CustomConfiguration.Origin, queryParameterIdentifierOptions.Origin.Identifier);
        Assert.Equal(CustomConfiguration.OriginCoordinate, queryParameterIdentifierOptions.OriginCoordinate.Identifier);
        Assert.Equal(CustomConfiguration.OriginCoordinateType, queryParameterIdentifierOptions.OriginCoordinateType.Identifier);
        Assert.Equal(CustomConfiguration.OutputFormat, queryParameterIdentifierOptions.OutputFormat.Identifier);
        Assert.Equal(CustomConfiguration.OutputUnits, queryParameterIdentifierOptions.OutputUnits.Identifier);
        Assert.Equal(CustomConfiguration.ReferencePlane, queryParameterIdentifierOptions.ReferencePlane.Identifier);
        Assert.Equal(CustomConfiguration.ReferenceSystem, queryParameterIdentifierOptions.ReferenceSystem.Identifier);
        Assert.Equal(CustomConfiguration.StartEpoch, queryParameterIdentifierOptions.StartEpoch.Identifier);
        Assert.Equal(CustomConfiguration.StepSize, queryParameterIdentifierOptions.StepSize.Identifier);
        Assert.Equal(CustomConfiguration.StopEpoch, queryParameterIdentifierOptions.StopEpoch.Identifier);
        Assert.Equal(CustomConfiguration.TimeDeltaInclusion, queryParameterIdentifierOptions.TimeDeltaInclusion.Identifier);
        Assert.Equal(CustomConfiguration.TimePrecision, queryParameterIdentifierOptions.TimePrecision.Identifier);
        Assert.Equal(CustomConfiguration.ValueSeparation, queryParameterIdentifierOptions.ValueSeparation.Identifier);
        Assert.Equal(CustomConfiguration.VectorCorrection, queryParameterIdentifierOptions.VectorCorrection.Identifier);
        Assert.Equal(CustomConfiguration.VectorLabels, queryParameterIdentifierOptions.VectorLabels.Identifier);
        Assert.Equal(CustomConfiguration.VectorTableContent, queryParameterIdentifierOptions.VectorTableContent.Identifier);
        Assert.Equal(CustomConfiguration.CalendarType, queryParameterIdentifierOptions.CalendarType.Identifier);
        Assert.Equal(CustomConfiguration.TimeSystem, queryParameterIdentifierOptions.TimeSystem.Identifier);
        Assert.Equal(CustomConfiguration.TimeZone, queryParameterIdentifierOptions.TimeZone.Identifier);
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

        static void configureConfiguration(IConfigurationBuilder configuration) => configuration.AddInMemoryCollection(keyValuePairOptions());
        static void configureServices(HostBuilderContext context, IServiceCollection services) => services.AddSharpHorizonsQuery(context.Configuration);

        static IEnumerable<KeyValuePair<string, string?>> keyValuePairOptions()
        {
            foreach (var (key, value) in tupleOptions())
            {
                yield return new KeyValuePair<string, string?>(key, value);
            }
        }

        static IEnumerable<(string Key, string? Value)> tupleOptions() => new (string, string?)[]
        {
            ("Result:RawTextSource", CustomConfiguration.RawTextSource),
            ("Result:RawTextVersion", CustomConfiguration.RawTextVersion),
            ("ParameterIdentifiers:Command", CustomConfiguration.Command),
            ("ParameterIdentifiers:EphemerisType", CustomConfiguration.EphemerisType),
            ("ParameterIdentifiers:EpochCollection", CustomConfiguration.EpochCollection),
            ("ParameterIdentifiers:EpochCollectionFormat", CustomConfiguration.EpochCollectionFormat),
            ("ParameterIdentifiers:GenerateEphemeris", CustomConfiguration.GenerateEphemeris),
            ("ParameterIdentifiers:ObjectDataInclusion", CustomConfiguration.ObjectDataInclusion),
            ("ParameterIdentifiers:Origin", CustomConfiguration.Origin),
            ("ParameterIdentifiers:OriginCoordinate", CustomConfiguration.OriginCoordinate),
            ("ParameterIdentifiers:OriginCoordinateType", CustomConfiguration.OriginCoordinateType),
            ("ParameterIdentifiers:OutputFormat", CustomConfiguration.OutputFormat),
            ("ParameterIdentifiers:OutputUnits", CustomConfiguration.OutputUnits),
            ("ParameterIdentifiers:ReferencePlane", CustomConfiguration.ReferencePlane),
            ("ParameterIdentifiers:ReferenceSystem", CustomConfiguration.ReferenceSystem),
            ("ParameterIdentifiers:StartEpoch", CustomConfiguration.StartEpoch),
            ("ParameterIdentifiers:StepSize", CustomConfiguration.StepSize),
            ("ParameterIdentifiers:StopEpoch", CustomConfiguration.StopEpoch),
            ("ParameterIdentifiers:TimeDeltaInclusion", CustomConfiguration.TimeDeltaInclusion),
            ("ParameterIdentifiers:TimePrecision", CustomConfiguration.TimePrecision),
            ("ParameterIdentifiers:ValueSeparation", CustomConfiguration.ValueSeparation),
            ("ParameterIdentifiers:VectorCorrection", CustomConfiguration.VectorCorrection),
            ("ParameterIdentifiers:VectorLabels", CustomConfiguration.VectorLabels),
            ("ParameterIdentifiers:VectorTableContent", CustomConfiguration.VectorTableContent),
            ("ParameterIdentifiers:CalendarType", CustomConfiguration.CalendarType),
            ("ParameterIdentifiers:TimeSystem", CustomConfiguration.TimeSystem),
            ("ParameterIdentifiers:TimeZone", CustomConfiguration.TimeZone)
        };
    }

    private static class CustomConfiguration
    {
        public static string RawTextSource => "Result-RawTextSource";
        public static string RawTextVersion => "Result-RawTextVersion";

        public static string Command => "ParameterIdentifiers-Command";
        public static string EphemerisType => "ParameterIdentifiers-EphemerisType";
        public static string EpochCollection => "ParameterIdentifiers-EpochCollection";
        public static string EpochCollectionFormat => "ParameterIdentifiers-EpochCollectionFormat";
        public static string GenerateEphemeris => "ParameterIdentifiers-GenerateEphemeris";
        public static string ObjectDataInclusion => "ParameterIdentifiers-ObjectDataInclusion";
        public static string Origin => "ParameterIdentifiers-Origin";
        public static string OriginCoordinate => "ParameterIdentifiers-OriginCoordinate";
        public static string OriginCoordinateType => "ParameterIdentifiers-OriginCoordinateType";
        public static string OutputFormat => "ParameterIdentifiers-OutputFormat";
        public static string OutputUnits => "ParameterIdentifiers-OutputUnits";
        public static string ReferencePlane => "ParameterIdentifiers-ReferencePlane";
        public static string ReferenceSystem => "ParameterIdentifiers-ReferenceSystem";
        public static string StartEpoch => "ParameterIdentifiers-StartEpoch";
        public static string StepSize => "ParameterIdentifiers-StepSize";
        public static string StopEpoch => "ParameterIdentifiers-StopEpoch";
        public static string TimeDeltaInclusion => "ParameterIdentifiers-TimeDeltaInclusion";
        public static string TimePrecision => "ParameterIdentifiers-TimePrecision";
        public static string ValueSeparation => "ParameterIdentifiers-ValueSeparation";
        public static string VectorCorrection => "ParameterIdentifiers-VectorCorrection";
        public static string VectorLabels => "ParameterIdentifiers-VectorLabels";
        public static string VectorTableContent => "ParameterIdentifiers-VectorTableContent";
        public static string CalendarType => "ParameterIdentifiers-CalendarType";
        public static string TimeSystem => "ParameterIdentifiers-TimeSystem";
        public static string TimeZone => "ParameterIdentifiers-TimeZone";
    }
}
