namespace SharpHorizons.Query.Arguments.Composers;

using System.ComponentModel;

/// <inheritdoc cref="IOutputUnitsComposer"/>
internal sealed class OutputUnitsComposer : IOutputUnitsComposer
{
    IOutputUnitsArgument IArgumentComposer<IOutputUnitsArgument, OutputUnits>.Compose(OutputUnits obj) => new QueryArgument(obj switch
    {
        OutputUnits.KilometresAndSeconds => "KM-S",
        OutputUnits.AstronomicalUnitsAndDays => "AU-D",
        OutputUnits.KilometresAndDays => "KM-D",
        _ => throw new InvalidEnumArgumentException(nameof(obj), (int)obj, typeof(OutputUnits))
    });
}
