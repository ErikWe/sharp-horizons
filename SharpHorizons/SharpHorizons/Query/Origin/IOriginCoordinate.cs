namespace SharpHorizons.Query.Origin;

using SharpHorizons.Query.Arguments;

/// <summary>Represents the coordinate, relative to some <see cref="IOriginObject"/>, in a query.</summary>
internal interface IOriginCoordinate
{
    /// <summary>Composes a <see cref="IOriginCoordinateArgument"/> describing the coordinate.</summary>
    internal abstract IOriginCoordinateArgument ComposeCoordinateArgument();

    /// <summary>Composes a <see cref="IOriginCoordinateTypeArgument"/> describing the type of the <see cref="IOriginCoordinateArgument"/>.</summary>
    internal abstract IOriginCoordinateTypeArgument ComposeCoordinateTypeArgument();
}