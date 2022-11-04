namespace SharpHorizons.Query.Origin;

using SharpHorizons.Query.Arguments;

/// <inheritdoc cref="ICoordinateOrigin"/>
internal sealed record class CoordinateOrigin : ICoordinateOrigin
{
    /// <summary>The <see cref="IOriginObject"/>, relative to which <see cref="OriginCoordinate"/> is expressed.</summary>
    public IOriginObject OriginObject { get; }

    /// <summary>The <see cref="IOriginCoordinate"/> relative to <see cref="OriginObject"/>.</summary>
    public IOriginCoordinate OriginCoordinate { get; }

    /// <summary>Used to compose a <see cref="IOriginArgument"/> describing <see langword="this"/>.</summary>
    private IOriginComposer<ICoordinateOrigin> Composer { get; }

    /// <summary>Describes the <see cref="IOrigin"/> in a query as a the center of <paramref name="originObject"/>.</summary>
    /// <param name="originObject">The <see cref="IOriginObject"/>, relative to which <paramref name="originCoordinate"/> is expressed.</param>
    /// <param name="originCoordinate">The <see cref="IOriginCoordinate"/> relative to <paramref name="originObject"/>.</param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public CoordinateOrigin(IOriginObject originObject, IOriginCoordinate originCoordinate, IOriginComposer<ICoordinateOrigin> composer)
    {
        OriginObject = originObject;
        OriginCoordinate = originCoordinate;

        Composer = composer;
    }

    bool IOrigin.UsesCoordinate => true;
    IOriginArgument IOrigin.ComposeArgument() => Composer.Compose(this);
    IOriginCoordinateArgument IOrigin.ComposeCoordinateArgument() => OriginCoordinate.ComposeCoordinateArgument();
    IOriginCoordinateTypeArgument IOrigin.ComposeCoordinateTypeArgument() => OriginCoordinate.ComposeCoordinateTypeArgument();
}