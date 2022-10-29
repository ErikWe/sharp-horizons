namespace SharpHorizons.Query.Arguments;

using System.ComponentModel;

/// <inheritdoc cref="IOutputUnitsArgument"/>
internal sealed record class OutputUnitsArgument : IOutputUnitsArgument
{
    /// <inheritdoc/>
    public QueryArgument Value { get; }

    /// <summary><inheritdoc cref="OutputUnitsArgument" path="/summary"/></summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    private OutputUnitsArgument(QueryArgument value)
    {
        Value = value;
    }

    /// <summary>Composes an <see cref="IOutputUnitsArgument"/> describing <paramref name="outputUnits"/>.</summary>
    /// <param name="outputUnits">An <see cref="IOutputUnitsArgument"/> is composed based on this <see cref="OutputUnits"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public static IOutputUnitsArgument Compose(OutputUnits outputUnits) => new OutputUnitsArgument(outputUnits switch
    {
        OutputUnits.KilometresAndSeconds => "KM-S",
        OutputUnits.AstronomicalUnitsAndDays => "AU-D",
        OutputUnits.KilometresAndDays => "KM-D",
        _ => throw new InvalidEnumArgumentException(nameof(outputUnits), (int)outputUnits, typeof(OutputUnits))
    });
}