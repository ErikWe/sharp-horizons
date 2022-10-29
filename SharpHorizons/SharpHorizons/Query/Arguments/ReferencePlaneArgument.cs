namespace SharpHorizons.Query.Arguments;

using System.ComponentModel;

/// <inheritdoc cref="IReferencePlaneArgument"/>
internal sealed record class ReferencePlaneArgument : IReferencePlaneArgument
{
    /// <inheritdoc/>
    public QueryArgument Value { get; }

    /// <summary><inheritdoc cref="ReferencePlaneArgument" path="/summary"/></summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    private ReferencePlaneArgument(QueryArgument value)
    {
        Value = value;
    }

    /// <summary>Composes a <see cref="IReferencePlaneArgument"/> describing <paramref name="referencePlane"/>.</summary>
    /// <param name="referencePlane">A <see cref="IReferencePlaneArgument"/> is composed based on this <see cref="ReferencePlane"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public static IReferencePlaneArgument Compose(ReferencePlane referencePlane) => new ReferencePlaneArgument(referencePlane switch
    {
        ReferencePlane.Ecliptic => "E",
        ReferencePlane.Frame => "F",
        ReferencePlane.BodyEquator => "B",
        _ => throw new InvalidEnumArgumentException(nameof(referencePlane), (int)referencePlane, typeof(ReferencePlane))
    });
}