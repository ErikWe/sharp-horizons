namespace SharpHorizons.Tests.InterpretationCases.ExtensionsCases.IServiceCollectionExtensionsCases;

using Microsoft.Extensions.DependencyInjection;

using SharpHorizons.Extensions.Interpretation;
using SharpHorizons.Interpretation;
using SharpHorizons.Interpretation.Ephemeris;
using SharpHorizons.Interpretation.Ephemeris.Origin;
using SharpHorizons.Interpretation.Ephemeris.Target;
using SharpHorizons.Interpretation.Ephemeris.Vectors;

using Xunit;

public class AddSharpHorizonsInterpretation
{
    [Fact]
    public void ReturnsSameInstance()
    {
        var expected = GetServiceCollection();

        var actual = expected.AddSharpHorizonsInterpretation();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void UsingDefaultConfiguration()
    {
        var provider = GetServiceCollection().AddSharpHorizonsInterpretation().BuildServiceProvider();

        var interpretationOptions = provider.GetRequiredService<IInterpretationOptionsProvider>();

        Assert.Equal("US/Pacific", interpretationOptions.HorizonsTimeZoneID);
        Assert.Equal("unavailable", interpretationOptions.UnavailableText);

        var ephemerisInterpretationOptions = provider.GetRequiredService<IEphemerisInterpretationOptionsProvider>();

        Assert.Equal("Ephemeris", ephemerisInterpretationOptions.EphemerisDataStart);
        Assert.Equal(4, ephemerisInterpretationOptions.EphemerisDataBlockCount);
        Assert.Equal("West-longitude positive", ephemerisInterpretationOptions.WestPositiveLongitude);
        Assert.Equal("East-longitude positive", ephemerisInterpretationOptions.EastPositiveLongitude);
        Assert.Equal("B.C.", ephemerisInterpretationOptions.BoundaryEpochBCE);
        Assert.Equal("C.E.", ephemerisInterpretationOptions.BoundaryEpochCE);
        Assert.Equal("Start time", ephemerisInterpretationOptions.StartEpoch);
        Assert.Equal("Stop  time", ephemerisInterpretationOptions.StopEpoch);
        Assert.Equal("Start time", ephemerisInterpretationOptions.TimeSystem);
        Assert.Equal("Start time", ephemerisInterpretationOptions.TimeZoneOffset);
        Assert.Equal("Step-size", ephemerisInterpretationOptions.StepSize);
        Assert.Equal("Reference frame", ephemerisInterpretationOptions.ReferenceSystem);
        Assert.Equal("$$SOE", ephemerisInterpretationOptions.StartOfEphemeris);
        Assert.Equal("$$EOE", ephemerisInterpretationOptions.EndOfEphemeris);

        var originInterpretationOptions = provider.GetRequiredService<IOriginInterpretationOptionsProvider>();

        Assert.Equal("Center body name", originInterpretationOptions.BodyName);
        Assert.Equal("Center-site name", originInterpretationOptions.SiteName);
        Assert.Equal("GEOCENTRIC", originInterpretationOptions.GeocentricSite);
        Assert.Equal("(user defined site below)", originInterpretationOptions.CustomSite);
        Assert.Equal("Center geodetic", originInterpretationOptions.GeodeticCoordinate);
        Assert.Equal("Center cylindric", originInterpretationOptions.CylindricalCoordinate);
        Assert.Equal("Center pole/equ", originInterpretationOptions.ReferenceEllipsoid);
        Assert.Equal("Center radii", originInterpretationOptions.Radii);

        var targetInterpretationOptions = provider.GetRequiredService<ITargetInterpretationOptionsProvider>();

        Assert.Equal("Target body name", targetInterpretationOptions.BodyName);
        Assert.Equal("Target geodetic", targetInterpretationOptions.GeodeticCoordinate);
        Assert.Equal("Target cylindric", targetInterpretationOptions.CylindricalCoordinate);
        Assert.Equal("Target pole/equ", targetInterpretationOptions.ReferenceEllipsoid);
        Assert.Equal("Target radii", targetInterpretationOptions.Radii);

        var vectorsInterpretationOptions = provider.GetRequiredService<IVectorsInterpretationOptionsProvider>();

        Assert.Equal("Output units", vectorsInterpretationOptions.OutputUnits);
        Assert.Equal("Output type", vectorsInterpretationOptions.VectorCorrection);
        Assert.Equal("Output format", vectorsInterpretationOptions.VectorTableContent);
        Assert.Equal("Reference frame", vectorsInterpretationOptions.ReferencePlane);
        Assert.Equal("Small perturbers", vectorsInterpretationOptions.SmallPerturbers);
    }

    private static IServiceCollection GetServiceCollection() => new ServiceCollection();
}
