namespace SharpHorizons.Query.Origin;

using SharpHorizons.Query;
using SharpHorizons.Query.Target;

/// <summary>Represents an origin in a query, relative to which a <see cref="ITarget"/> is described.</summary>
public interface IOrigin
{
    /// <summary>Indicates whether the origin is specified using a coordinate.</summary>
    public abstract bool UsesCoordinate { get; }

    /// <summary>Composes a <see cref="IOriginArgument"/> describing the origin.</summary>
    public abstract IOriginArgument ComposeArgument();

    /// <summary>Composes a <see cref="IOriginCoordinateArgument"/> describing the coordinate, if one is used.</summary>
    /// <exception cref="OriginNotUsingCoordinateException"/>
    public abstract IOriginCoordinateArgument ComposeCoordinateArgument();

    /// <summary>Composes a <see cref="IOriginCoordinateTypeArgument"/> describing the type of the <see cref="IOriginCoordinateArgument"/>, if one is used.</summary>
    /// <exception cref="OriginNotUsingCoordinateException"/>
    public abstract IOriginCoordinateTypeArgument ComposeCoordinateTypeArgument();
}