namespace SharpHorizons.Query.Origin;

using SharpHorizons.Query.Arguments;

/// <summary>Describes the <see cref="IOrigin"/> in a query as a <see cref="IOriginCoordinate"/> relative to an <see cref="IOriginObject"/>.</summary>
internal sealed record class CoordinateOrigin : IOrigin
{
    /// <summary>The <see cref="IOriginObject"/>, relative to which <see cref="OriginCoordinate"/> is expressed.</summary>
    private IOriginObject OriginObject { get; }

    /// <summary>The <see cref="IOriginCoordinate"/> relative to <see cref="OriginObject"/>.</summary>
    private IOriginCoordinate OriginCoordinate { get; }

    /// <summary>Describes the <see cref="IOrigin"/> in a query as a the center of <paramref name="originObject"/>.</summary>
    /// <param name="originObject">The <see cref="IOriginObject"/>, relative to which <paramref name="originCoordinate"/> is expressed.</param>
    /// <param name="originCoordinate">The <see cref="IOriginCoordinate"/> relative to <paramref name="originObject"/>.</param>
    public CoordinateOrigin(IOriginObject originObject, IOriginCoordinate originCoordinate)
    {
        OriginObject = originObject;
        OriginCoordinate = originCoordinate;
    }

    bool IOrigin.UsesCoordinate => true;
    IOriginArgument IOrigin.ComposeArgument() => new OriginArgument($"c@{OriginObject.ComposeIdentifier()}");
    IOriginCoordinateArgument IOrigin.ComposeCoordinateArgument() => OriginCoordinate.ComposeCoordinateArgument();
    IOriginCoordinateTypeArgument IOrigin.ComposeCoordinateTypeArgument() => OriginCoordinate.ComposeCoordinateTypeArgument();
}