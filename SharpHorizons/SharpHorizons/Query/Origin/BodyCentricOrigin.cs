namespace SharpHorizons.Query.Origin;

using SharpHorizons.Query.Arguments;

/// <summary>Describes the <see cref="IOrigin"/> in a query as a the center of some <see cref="IOriginObject"/>.</summary>
internal sealed record class BodyCentricOrigin : IOrigin
{
    /// <summary>The <see cref="IOriginObject"/>, the center of which represents the <see cref="IOrigin"/> in a query.</summary>
    private IOriginObject OriginObject { get; }

    /// <summary>Describes the <see cref="IOrigin"/> in a query as a the center of <paramref name="originObject"/>.</summary>
    /// <param name="originObject"><inheritdoc cref="OriginObject" path="/summary"/></param>
    public BodyCentricOrigin(IOriginObject originObject)
    {
        OriginObject = originObject;
    }

    bool IOrigin.UsesCoordinate => false;
    IOriginArgument IOrigin.ComposeArgument() => new OriginArgument($"g@{OriginObject.ComposeIdentifier()}");
    IOriginCoordinateArgument IOrigin.ComposeCoordinateArgument() => throw new OriginNotUsingCoordinateException();
    IOriginCoordinateTypeArgument IOrigin.ComposeCoordinateTypeArgument() => throw new OriginNotUsingCoordinateException();
}