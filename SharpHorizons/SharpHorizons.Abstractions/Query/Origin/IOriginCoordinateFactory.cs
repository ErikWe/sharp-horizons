namespace SharpHorizons.Query.Origin;

using System;

/// <summary>Handles construction of <see cref="IOriginCoordinate"/>.</summary>
/// <typeparam name="T">Instances of this type are described as <see cref="IOriginCoordinate"/>.</typeparam>
public interface IOriginCoordinateFactory<T>
{
    /// <summary>Describes <paramref name="coordinate"/> as an <see cref="IOriginCoordinate"/>.</summary>
    /// <param name="coordinate">This <typeparamref name="T"/> is described as a <see cref="IOriginCoordinate"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOriginCoordinate Create(T coordinate);
}
