namespace SharpHorizons.Tests.QueryCases.ExtensionsCases.IServiceCollectionExtensionsCases;

using Microsoft.Extensions.DependencyInjection;

using SharpHorizons.Extensions.Query;
using SharpHorizons.Query.Parameters;
using SharpHorizons.Query.Result;

using Xunit;

public class AddSharpHorizonsQuery
{
    [Fact]
    public void ReturnsSameInstance()
    {
        var expected = GetServiceCollection();

        var actual = expected.AddSharpHorizonsQuery();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void UsingDefaultConfiguration()
    {
        var provider = GetServiceCollection().AddSharpHorizonsQuery().BuildServiceProvider();

        var queryResultOptions = provider.GetRequiredService<IQueryResultOptionsProvider>();

        Assert.Equal("API SOURCE", queryResultOptions.RawTextSource);
        Assert.Equal("API VERSION", queryResultOptions.RawTextVersion);

        var queryParameterIdentifierOptions = provider.GetRequiredService<IQueryParameterIdentifierProvider>();

        Assert.Equal("COMMAND", queryParameterIdentifierOptions.Command.Identifier);
        Assert.Equal("EPHEM_TYPE", queryParameterIdentifierOptions.EphemerisType.Identifier);
        Assert.Equal("TLIST", queryParameterIdentifierOptions.EpochCollection.Identifier);
        Assert.Equal("TLIST_TYPE", queryParameterIdentifierOptions.EpochCollectionFormat.Identifier);
        Assert.Equal("MAKE_EPHEM", queryParameterIdentifierOptions.GenerateEphemeris.Identifier);
        Assert.Equal("OBJ_DATA", queryParameterIdentifierOptions.ObjectDataInclusion.Identifier);
        Assert.Equal("CENTER", queryParameterIdentifierOptions.Origin.Identifier);
        Assert.Equal("SITE_COORD", queryParameterIdentifierOptions.OriginCoordinate.Identifier);
        Assert.Equal("COORD_TYPE", queryParameterIdentifierOptions.OriginCoordinateType.Identifier);
        Assert.Equal("format", queryParameterIdentifierOptions.OutputFormat.Identifier);
        Assert.Equal("OUT_UNITS", queryParameterIdentifierOptions.OutputUnits.Identifier);
        Assert.Equal("REF_PLANE", queryParameterIdentifierOptions.ReferencePlane.Identifier);
        Assert.Equal("REF_SYSTEM", queryParameterIdentifierOptions.ReferenceSystem.Identifier);
        Assert.Equal("START_TIME", queryParameterIdentifierOptions.StartEpoch.Identifier);
        Assert.Equal("STEP_SIZE", queryParameterIdentifierOptions.StepSize.Identifier);
        Assert.Equal("STOP_TIME", queryParameterIdentifierOptions.StopEpoch.Identifier);
        Assert.Equal("VEC_DELTA_T", queryParameterIdentifierOptions.TimeDeltaInclusion.Identifier);
        Assert.Equal("TIME_DIGITS", queryParameterIdentifierOptions.TimePrecision.Identifier);
        Assert.Equal("CSV_FORMAT", queryParameterIdentifierOptions.ValueSeparation.Identifier);
        Assert.Equal("VEC_CORR", queryParameterIdentifierOptions.VectorCorrection.Identifier);
        Assert.Equal("VEC_LABELS", queryParameterIdentifierOptions.VectorLabels.Identifier);
        Assert.Equal("VEC_TABLE", queryParameterIdentifierOptions.VectorTableContent.Identifier);
        Assert.Equal("CAL_TYPE", queryParameterIdentifierOptions.CalendarType.Identifier);
        Assert.Equal("TIME_TYPE", queryParameterIdentifierOptions.TimeSystem.Identifier);
        Assert.Equal("TIME_ZONE", queryParameterIdentifierOptions.TimeZone.Identifier);
    }

    private static IServiceCollection GetServiceCollection() => new ServiceCollection();
}
