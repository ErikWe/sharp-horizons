namespace SharpHorizons.Query.Origin;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="ICoordinateOrigin"/>
internal sealed record class CoordinateOrigin : ICoordinateOrigin
{
    public required IOriginObject OriginObject { get; init; }
    public required IOriginCoordinate OriginCoordinate { get; init; }

    /// <summary>Used to compose a <see cref="IOriginArgument"/> describing <see langword="this"/>.</summary>
    public required IOriginComposer<ICoordinateOrigin> Composer { private get; init; }

    /// <inheritdoc cref="CoordinateOrigin"/>
    public CoordinateOrigin() { }

    /// <inheritdoc cref="CoordinateOrigin"/>
    /// <param name="originObject">The <see cref="IOriginObject"/>, relative to which <paramref name="originCoordinate"/> is expressed.</param>
    /// <param name="originCoordinate">The <see cref="IOriginCoordinate"/> relative to <paramref name="originObject"/>.</param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
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