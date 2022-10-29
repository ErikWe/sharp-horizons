namespace SharpHorizons.Query.Arguments;

using System.ComponentModel;

/// <inheritdoc cref="IObjectDataInclusionArgument"/>
internal sealed record class ObjectDataInclusionArgument : IObjectDataInclusionArgument
{
    /// <inheritdoc/>
    public QueryArgument Value { get; }

    /// <summary><inheritdoc cref="ObjectDataInclusionArgument" path="/summary"/></summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    private ObjectDataInclusionArgument(QueryArgument value)
    {
        Value = value;
    }

    /// <summary>Composes an <see cref="IObjectDataInclusionArgument"/> describing <paramref name="objectDataInclusion"/>.</summary>
    /// <param name="objectDataInclusion">An <see cref="IObjectDataInclusionArgument"/> is composed based on this <see cref="ObjectDataInclusion"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public static IObjectDataInclusionArgument Compose(ObjectDataInclusion objectDataInclusion) => new ObjectDataInclusionArgument(objectDataInclusion switch
    {
        ObjectDataInclusion.Disable => "NO",
        ObjectDataInclusion.Enable => "YES",
        _ => throw new InvalidEnumArgumentException(nameof(objectDataInclusion), (int)objectDataInclusion, typeof(ObjectDataInclusion))
    });
}