namespace SharpHorizons.Query.Arguments;

using System.ComponentModel;

/// <inheritdoc cref="IGenerateEphemeridesArgument"/>
internal sealed record class GenerateEphemeridesArgument : IGenerateEphemeridesArgument
{
    /// <inheritdoc/>
    public QueryArgument Value { get; }

    /// <summary><inheritdoc cref="GenerateEphemeridesArgument" path="/summary"/></summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    private GenerateEphemeridesArgument(QueryArgument value)
    {
        Value = value;
    }

    /// <summary>Composes an <see cref="IGenerateEphemeridesArgument"/> describing <paramref name="generateEphemerides"/>.</summary>
    /// <param name="generateEphemerides">An <see cref="IGenerateEphemeridesArgument"/> is composed based on this <see cref="GenerateEphemerides"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public static IGenerateEphemeridesArgument Compose(GenerateEphemerides generateEphemerides) => new GenerateEphemeridesArgument(generateEphemerides switch
    {
        GenerateEphemerides.Disable => "NO",
        GenerateEphemerides.Enable => "YES",
        _ => throw new InvalidEnumArgumentException(nameof(generateEphemerides), (int)generateEphemerides, typeof(GenerateEphemerides))
    });
}