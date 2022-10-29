namespace SharpHorizons.Query.Arguments;

using System.ComponentModel;

/// <inheritdoc cref="IOutputLabelsArgument"/>
internal sealed record class OutputLabelsArgument : IOutputLabelsArgument
{
    /// <inheritdoc/>
    public QueryArgument Value { get; }

    /// <summary><inheritdoc cref="OutputLabelsArgument" path="/summary"/></summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    private OutputLabelsArgument(QueryArgument value)
    {
        Value = value;
    }

    /// <summary>Composes an <see cref="IOutputLabelsArgument"/> describing <paramref name="outputLabels"/>.</summary>
    /// <param name="outputLabels">An <see cref="IOutputLabelsArgument"/> is composed based on this <see cref="OutputLabels"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public static IOutputLabelsArgument Compose(OutputLabels outputLabels) => new OutputLabelsArgument(outputLabels switch
    {
        OutputLabels.Disable => "NO",
        OutputLabels.Enable => "YES",
        _ => throw new InvalidEnumArgumentException(nameof(outputLabels), (int)outputLabels, typeof(OutputLabels))
    });
}