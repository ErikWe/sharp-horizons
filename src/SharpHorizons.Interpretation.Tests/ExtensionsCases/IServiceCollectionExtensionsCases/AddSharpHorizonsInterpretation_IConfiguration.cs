namespace SharpHorizons.Tests.InterpretationCases.ExtensionsCases.IServiceCollectionExtensionsCases;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Moq;

using SharpHorizons.Extensions.Interpretation;
using SharpHorizons.Interpretation;
using SharpHorizons.Interpretation.Ephemeris;
using SharpHorizons.Interpretation.Ephemeris.Origin;
using SharpHorizons.Interpretation.Ephemeris.Target;
using SharpHorizons.Interpretation.Ephemeris.Vectors;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;

using Xunit;

public class AddSharpHorizonsInterpretation_IConfiguration
{
    [Fact]
    public void Null_ArgumentNullException()
    {
        var services = GetServiceCollection();

        IConfiguration configuration = null!;

        var exception = Record.Exception(() => services.AddSharpHorizonsInterpretation(configuration));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Valid_ReturnsSameServiceCollectionInstance()
    {
        var expected = GetServiceCollection();

        var configuration = GetConfiguration();

        var actual = expected.AddSharpHorizonsInterpretation(configuration);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Valid_UsingCustomConfiguration()
    {
        var host = GetConfiguredHost();

        var interpretationOptions = host.Services.GetRequiredService<IInterpretationOptionsProvider>();

        Assert.Equal(CustomConfiguration.ExpectedInterpretationOptions.HorizonsTimeZoneID, interpretationOptions.HorizonsTimeZoneID);
        Assert.Equal(CustomConfiguration.ExpectedInterpretationOptions.UnavailableText, interpretationOptions.UnavailableText);

        var ephemerisInterpretationOptions = host.Services.GetRequiredService<IEphemerisInterpretationOptionsProvider>();

        Assert.Equal(CustomConfiguration.ExpectedEphemerisInterpretationOptions.EphemerisDataStart, ephemerisInterpretationOptions.EphemerisDataStart);
        Assert.Equal(CustomConfiguration.ExpectedEphemerisInterpretationOptions.EphemerisDataBlockCount, ephemerisInterpretationOptions.EphemerisDataBlockCount);
        Assert.Equal(CustomConfiguration.ExpectedEphemerisInterpretationOptions.WestPositiveLongitude, ephemerisInterpretationOptions.WestPositiveLongitude);
        Assert.Equal(CustomConfiguration.ExpectedEphemerisInterpretationOptions.EastPositiveLongitude, ephemerisInterpretationOptions.EastPositiveLongitude);
        Assert.Equal(CustomConfiguration.ExpectedEphemerisInterpretationOptions.BoundaryEpochBCE, ephemerisInterpretationOptions.BoundaryEpochBCE);
        Assert.Equal(CustomConfiguration.ExpectedEphemerisInterpretationOptions.BoundaryEpochCE, ephemerisInterpretationOptions.BoundaryEpochCE);
        Assert.Equal(CustomConfiguration.ExpectedEphemerisInterpretationOptions.StartEpoch, ephemerisInterpretationOptions.StartEpoch);
        Assert.Equal(CustomConfiguration.ExpectedEphemerisInterpretationOptions.StopEpoch, ephemerisInterpretationOptions.StopEpoch);
        Assert.Equal(CustomConfiguration.ExpectedEphemerisInterpretationOptions.TimeSystem, ephemerisInterpretationOptions.TimeSystem);
        Assert.Equal(CustomConfiguration.ExpectedEphemerisInterpretationOptions.TimeZoneOffset, ephemerisInterpretationOptions.TimeZoneOffset);
        Assert.Equal(CustomConfiguration.ExpectedEphemerisInterpretationOptions.StepSize, ephemerisInterpretationOptions.StepSize);
        Assert.Equal(CustomConfiguration.ExpectedEphemerisInterpretationOptions.ReferenceSystem, ephemerisInterpretationOptions.ReferenceSystem);
        Assert.Equal(CustomConfiguration.ExpectedEphemerisInterpretationOptions.StartOfEphemeris, ephemerisInterpretationOptions.StartOfEphemeris);
        Assert.Equal(CustomConfiguration.ExpectedEphemerisInterpretationOptions.EndOfEphemeris, ephemerisInterpretationOptions.EndOfEphemeris);

        var originInterpretationOptions = host.Services.GetRequiredService<IOriginInterpretationOptionsProvider>();

        Assert.Equal(CustomConfiguration.ExpectedOriginInterpretationOptions.BodyName, originInterpretationOptions.BodyName);
        Assert.Equal(CustomConfiguration.ExpectedOriginInterpretationOptions.SiteName, originInterpretationOptions.SiteName);
        Assert.Equal(CustomConfiguration.ExpectedOriginInterpretationOptions.GeocentricSite, originInterpretationOptions.GeocentricSite);
        Assert.Equal(CustomConfiguration.ExpectedOriginInterpretationOptions.CustomSite, originInterpretationOptions.CustomSite);
        Assert.Equal(CustomConfiguration.ExpectedOriginInterpretationOptions.GeodeticCoordinate, originInterpretationOptions.GeodeticCoordinate);
        Assert.Equal(CustomConfiguration.ExpectedOriginInterpretationOptions.CylindricalCoordinate, originInterpretationOptions.CylindricalCoordinate);
        Assert.Equal(CustomConfiguration.ExpectedOriginInterpretationOptions.ReferenceEllipsoid, originInterpretationOptions.ReferenceEllipsoid);
        Assert.Equal(CustomConfiguration.ExpectedOriginInterpretationOptions.Radii, originInterpretationOptions.Radii);

        var targetInterpretationOptions = host.Services.GetRequiredService<ITargetInterpretationOptionsProvider>();

        Assert.Equal(CustomConfiguration.ExpectedTargetInterpretationOptions.BodyName, targetInterpretationOptions.BodyName);
        Assert.Equal(CustomConfiguration.ExpectedTargetInterpretationOptions.GeodeticCoordinate, targetInterpretationOptions.GeodeticCoordinate);
        Assert.Equal(CustomConfiguration.ExpectedTargetInterpretationOptions.CylindricalCoordinate, targetInterpretationOptions.CylindricalCoordinate);
        Assert.Equal(CustomConfiguration.ExpectedTargetInterpretationOptions.ReferenceEllipsoid, targetInterpretationOptions.ReferenceEllipsoid);
        Assert.Equal(CustomConfiguration.ExpectedTargetInterpretationOptions.Radii, targetInterpretationOptions.Radii);

        var vectorsInterpretationOptions = host.Services.GetRequiredService<IVectorsInterpretationOptionsProvider>();

        Assert.Equal(CustomConfiguration.ExpectedVectorsInterpretationOptions.OutputUnits, vectorsInterpretationOptions.OutputUnits);
        Assert.Equal(CustomConfiguration.ExpectedVectorsInterpretationOptions.VectorCorrection, vectorsInterpretationOptions.VectorCorrection);
        Assert.Equal(CustomConfiguration.ExpectedVectorsInterpretationOptions.VectorTableContent, vectorsInterpretationOptions.VectorTableContent);
        Assert.Equal(CustomConfiguration.ExpectedVectorsInterpretationOptions.ReferencePlane, vectorsInterpretationOptions.ReferencePlane);
        Assert.Equal(CustomConfiguration.ExpectedVectorsInterpretationOptions.SmallPerturbers, vectorsInterpretationOptions.SmallPerturbers);
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
        static void configureServices(HostBuilderContext context, IServiceCollection services) => services.AddSharpHorizonsInterpretation(context.Configuration);
    }

    private static class CustomConfiguration
    {
        public static IReadOnlyDictionary<string, string?> Dictionary { get; }

        public static IInterpretationOptionsProvider ExpectedInterpretationOptions { get; }
        public static IEphemerisInterpretationOptionsProvider ExpectedEphemerisInterpretationOptions { get; }
        public static IOriginInterpretationOptionsProvider ExpectedOriginInterpretationOptions { get; }
        public static ITargetInterpretationOptionsProvider ExpectedTargetInterpretationOptions { get; }
        public static IVectorsInterpretationOptionsProvider ExpectedVectorsInterpretationOptions { get; }

        private static (string, Expression<Func<IInterpretationOptionsProvider, string>>)[] InterpretationKeys { get; } = new (string, Expression<Func<IInterpretationOptionsProvider, string>>)[]
        {
            ("HorizonsTimeZoneID", (provider) => provider.HorizonsTimeZoneID),
            ("UnavailableText", (provider) => provider.UnavailableText)
        };

        private static (string, Expression<Func<IEphemerisInterpretationOptionsProvider, string>>)[] StringEphemerisInterpretationKeys { get; } = new (string, Expression<Func<IEphemerisInterpretationOptionsProvider, string>>)[]
        {
            ("Ephemeris:EphemerisDataStart", (provider) => provider.EphemerisDataStart),
            ("Ephemeris:WestPositiveLongitude", (provider) => provider.WestPositiveLongitude),
            ("Ephemeris:EastPositiveLongitude", (provider) => provider.EastPositiveLongitude),
            ("Ephemeris:BoundaryEpochBCE", (provider) => provider.BoundaryEpochBCE),
            ("Ephemeris:BoundaryEpochCE", (provider) => provider.BoundaryEpochCE),
            ("Ephemeris:StartEpoch", (provider) => provider.StartEpoch),
            ("Ephemeris:StopEpoch", (provider) => provider.StopEpoch),
            ("Ephemeris:TimeSystem", (provider) => provider.TimeSystem),
            ("Ephemeris:TimeZoneOffset", (provider) => provider.TimeZoneOffset),
            ("Ephemeris:StepSize", (provider) => provider.StepSize),
            ("Ephemeris:ReferenceSystem", (provider) => provider.ReferenceSystem),
            ("Ephemeris:StartOfEphemeris", (provider) => provider.StartOfEphemeris),
            ("Ephemeris:EndOfEphemeris", (provider) => provider.EndOfEphemeris)
        };

        private static (string, Expression<Func<IEphemerisInterpretationOptionsProvider, int>>)[] IntEphemerisInterpretationKeys { get; } = new (string, Expression<Func<IEphemerisInterpretationOptionsProvider, int>>)[]
        {
            ("Ephemeris:EphemerisDataBlockCount", (provider) => provider.EphemerisDataBlockCount)
        };

        private static (string, Expression<Func<IOriginInterpretationOptionsProvider, string>>)[] OriginInterpretationKeys { get; } = new (string, Expression<Func<IOriginInterpretationOptionsProvider, string>>)[]
        {
            ("Ephemeris:Origin:BodyName", (provider) => provider.BodyName),
            ("Ephemeris:Origin:SiteName", (provider) => provider.SiteName),
            ("Ephemeris:Origin:GeocentricSite", (provider) => provider.GeocentricSite),
            ("Ephemeris:Origin:CustomSite", (provider) => provider.CustomSite),
            ("Ephemeris:Origin:GeodeticCoordinate", (provider) => provider.GeodeticCoordinate),
            ("Ephemeris:Origin:CylindricalCoordinate", (provider) => provider.CylindricalCoordinate),
            ("Ephemeris:Origin:ReferenceEllipsoid", (provider) => provider.ReferenceEllipsoid),
            ("Ephemeris:Origin:Radii", (provider) => provider.Radii)
        };

        private static (string, Expression<Func<ITargetInterpretationOptionsProvider, string>>)[] TargetInterpretationKeys { get; } = new (string, Expression<Func<ITargetInterpretationOptionsProvider, string>>)[]
        {
            ("Ephemeris:Target:BodyName", (provider) => provider.BodyName),
            ("Ephemeris:Target:GeodeticCoordinate", (provider) => provider.GeodeticCoordinate),
            ("Ephemeris:Target:CylindricalCoordinate", (provider) => provider.CylindricalCoordinate),
            ("Ephemeris:Target:ReferenceEllipsoid", (provider) => provider.ReferenceEllipsoid),
            ("Ephemeris:Target:Radii", (provider) => provider.Radii)
        };

        private static (string, Expression<Func<IVectorsInterpretationOptionsProvider, string>>)[] VectorsInterpretationKeys { get; } = new (string, Expression<Func<IVectorsInterpretationOptionsProvider, string>>)[]
        {
            ("Ephemeris:Vectors:OutputUnits", (provider) => provider.OutputUnits),
            ("Ephemeris:Vectors:VectorCorrection", (provider) => provider.VectorCorrection),
            ("Ephemeris:Vectors:VectorTableContent", (provider) => provider.VectorTableContent),
            ("Ephemeris:Vectors:ReferencePlane", (provider) => provider.ReferencePlane),
            ("Ephemeris:Vectors:SmallPerturbers", (provider) => provider.SmallPerturbers)
        };

        static CustomConfiguration()
        {
            Dictionary<string, string?> dictionary = new();

            Mock<IInterpretationOptionsProvider> interpretationOptionsMock = new();
            Mock<IEphemerisInterpretationOptionsProvider> ephemerisInterpretationOptionsMock = new();
            Mock<IOriginInterpretationOptionsProvider> originInterpretationOptionsMock = new();
            Mock<ITargetInterpretationOptionsProvider> targetInterpretationOptionsMock = new();
            Mock<IVectorsInterpretationOptionsProvider> vectorsInterpretationOptionsMock = new();

            foreach (var (key, action) in InterpretationKeys)
            {
                var result = $"CustomValue-{key}";

                dictionary[key] = result;
                interpretationOptionsMock.SetupGet(action).Returns(result);
            }

            foreach (var (key, action) in StringEphemerisInterpretationKeys)
            {
                var result = $"CustomValue-{key}";

                dictionary[key] = result;
                ephemerisInterpretationOptionsMock.SetupGet(action).Returns(result);
            }

            var value = 42;

            foreach (var (key, action) in IntEphemerisInterpretationKeys)
            {
                dictionary[key] = value.ToString(CultureInfo.InvariantCulture);
                ephemerisInterpretationOptionsMock.SetupGet(action).Returns(value);

                value = (value * 2) + 9;
            }

            foreach (var (key, action) in OriginInterpretationKeys)
            {
                var result = $"CustomValue-{key}";

                dictionary[key] = result;
                originInterpretationOptionsMock.SetupGet(action).Returns(result);
            }

            foreach (var (key, action) in TargetInterpretationKeys)
            {
                var result = $"CustomValue-{key}";

                dictionary[key] = result;
                targetInterpretationOptionsMock.SetupGet(action).Returns(result);
            }

            foreach (var (key, action) in VectorsInterpretationKeys)
            {
                var result = $"CustomValue-{key}";

                dictionary[key] = result;
                vectorsInterpretationOptionsMock.SetupGet(action).Returns(result);
            }

            Dictionary = dictionary;

            ExpectedInterpretationOptions = interpretationOptionsMock.Object;
            ExpectedEphemerisInterpretationOptions = ephemerisInterpretationOptionsMock.Object;
            ExpectedOriginInterpretationOptions = originInterpretationOptionsMock.Object;
            ExpectedTargetInterpretationOptions = targetInterpretationOptionsMock.Object;
            ExpectedVectorsInterpretationOptions = vectorsInterpretationOptionsMock.Object;
        }
    }
}
