namespace SharpHorizons.Query.Arguments.Composers;

/// <inheritdoc cref="IOutputUnitsComposer"/>
internal sealed class OutputUnitsComposer : IOutputUnitsComposer
{
    IOutputUnitsArgument IArgumentComposer<IOutputUnitsArgument, OutputUnits>.Compose(OutputUnits obj) => new QueryArgument(obj switch
    {
        OutputUnits.Unknown => throw ArgumentExceptionFactory.UnsupportedEnumValue(obj),
        OutputUnits.KilometresAndSeconds => "KM-S",
        OutputUnits.AstronomicalUnitsAndDays => "AU-D",
        OutputUnits.KilometresAndDays => "KM-D",
        _ => throw InvalidEnumArgumentExceptionFactory.Create(obj)
    });
}
