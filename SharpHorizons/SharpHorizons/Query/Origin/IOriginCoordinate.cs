namespace SharpHorizons.Query.Origin;

using SharpHorizons.Composers.Arguments;

/// <summary>Represents the coordinate, relative to some <see cref="IOriginObject"/>, in a query.</summary>
public interface IOriginCoordinate
{
    /// <summary>Composes a <see cref="IOriginCoordinateArgument"/> describing the <see cref="IOriginCoordinate"/>.</summary>
    public abstract IOriginCoordinateArgument ComposeCoordinateArgument();

    /// <summary>Composes a <see cref="IOriginCoordinateTypeArgument"/> describing the type of the <see cref="IOriginCoordinateArgument"/>.</summary>
    public abstract IOriginCoordinateTypeArgument ComposeCoordinateTypeArgument();
}