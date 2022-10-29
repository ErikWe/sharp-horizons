namespace SharpHorizons.Query.Arguments;

using System.ComponentModel;

/// <inheritdoc cref="IOutputFormatArgument"/>
internal sealed record class OutputFormatArgument : IOutputFormatArgument
{
    /// <inheritdoc/>
    public QueryArgument Value { get; }

    /// <summary><inheritdoc cref="OutputFormatArgument" path="/summary"/></summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    private OutputFormatArgument(QueryArgument value)
    {
        Value = value;
    }

    /// <summary>Composes an <see cref="IOutputFormatArgument"/> describing <paramref name="outputFormat"/>.</summary>
    /// <param name="outputFormat">An <see cref="IOutputFormatArgument"/> is composed based on this <see cref="OutputFormat"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public static IOutputFormatArgument Compose(OutputFormat outputFormat) => new OutputFormatArgument(outputFormat switch
    {
        OutputFormat.CommaSeparation => "YES",
        OutputFormat.WhitespaceSeparation => "NO",
        _ => throw new InvalidEnumArgumentException(nameof(outputFormat), (int)outputFormat, typeof(OutputUnits))
    });
}