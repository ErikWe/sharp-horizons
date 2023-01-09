namespace SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IOutputUnitsComposer"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
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
