namespace SharpHorizons.Query.Origin;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IBodyCentricOrigin"/>
internal sealed record class BodyCentricOrigin : IBodyCentricOrigin
{
    public required IOriginObject OriginObject { get; init; }

    /// <summary>Used to compose a <see cref="IOriginArgument"/> describing <see langword="this"/>.</summary>
    public required IOriginComposer<IBodyCentricOrigin> Composer { private get; init; }

    /// <inheritdoc cref="BodyCentricOrigin"/>
    public BodyCentricOrigin() { }

    /// <inheritdoc cref="BodyCentricOrigin"/>
    /// <param name="originObject"><inheritdoc cref="OriginObject" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
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
