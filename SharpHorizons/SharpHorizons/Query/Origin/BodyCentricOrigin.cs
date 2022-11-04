namespace SharpHorizons.Query.Origin;

using SharpHorizons.Query.Arguments;

/// <inheritdoc cref="IBodyCentricOrigin"/>
internal sealed record class BodyCentricOrigin : IBodyCentricOrigin
{
    /// <inheritdoc/>
    public IOriginObject OriginObject { get; }

    /// <summary>Used to compose a <see cref="IOriginArgument"/> describing <see langword="this"/>.</summary>
    private IOriginComposer<IBodyCentricOrigin> Composer { get; }

    /// <summary>Describes the <see cref="IOrigin"/> in a query as a the center of <paramref name="originObject"/>.</summary>
    /// <param name="originObject"><inheritdoc cref="OriginObject" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public BodyCentricOrigin(IOriginObject originObject, IOriginComposer<IBodyCentricOrigin> composer)
    {
        OriginObject = originObject;

        Composer = composer;
    }

    bool IOrigin.UsesCoordinate => false;
    IOriginArgument IOrigin.ComposeArgument() => Composer.Compose(this);
    IOriginCoordinateArgument IOrigin.ComposeCoordinateArgument() => throw new OriginNotUsingCoordinateException();
    IOriginCoordinateTypeArgument IOrigin.ComposeCoordinateTypeArgument() => throw new OriginNotUsingCoordinateException();
}