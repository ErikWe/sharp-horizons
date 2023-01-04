namespace SharpHorizons.Query.Origin;

using SharpHorizons.Query.Arguments;

/// <summary>Represents the coordinate of the <see cref="IOrigin"/>, relative to some <see cref="IOriginObject"/>.</summary>
public interface IOriginCoordinate
{
    /// <summary>Composes a <see cref="IOriginCoordinateArgument"/> describing the <see cref="IOriginCoordinate"/>.</summary>
    public abstract IOriginCoordinateArgument ComposeCoordinateArgument();

    /// <summary>Composes a <see cref="IOriginCoordinateTypeArgument"/> describing the type of the <see cref="IOriginCoordinateArgument"/>.</summary>
    public abstract IOriginCoordinateTypeArgument ComposeCoordinateTypeArgument();
}
