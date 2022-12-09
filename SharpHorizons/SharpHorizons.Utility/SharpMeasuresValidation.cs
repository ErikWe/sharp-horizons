namespace SharpHorizons;

using SharpMeasures;
using SharpMeasures.Astronomy;

using System;
using System.Runtime.CompilerServices;

/// <summary>Validates that SharpMeasures-types are compatible with Horizons.</summary>
public static class SharpMeasuresValidation
{
    /// <summary>Validates that <paramref name="value"/> represents a <typeparamref name="TScalar"/> supported by Horizons, and throws an <see cref="ArgumentException"/> otherwise.</summary>
    /// <typeparam name="TScalar">The type of the validated <see cref="IScalarQuantity"/>.</typeparam>
    /// <param name="value">This <typeparamref name="TScalar"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="value"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate<TScalar>(TScalar value, [CallerArgumentExpression(nameof(value))] string? argumentExpression = null) where TScalar : IScalarQuantity
    {
        if (value.Magnitude.IsNaN || value.Magnitude.IsInfinite)
        {
            throw new ArgumentException(ExceptionMessage<Time>(value.Magnitude), argumentExpression);
        }
    }

    /// <summary>Validates that <paramref name="coordinate"/> represents a <see cref="CylindricalCoordinate"/> supported by Horizons, and throws an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="coordinate">This <see cref="CylindricalCoordinate"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="coordinate"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(CylindricalCoordinate coordinate, [CallerArgumentExpression(nameof(coordinate))] string? argumentExpression = null)
    {
        try
        {
            Validate(coordinate.RadialDistance);
            Validate(coordinate.Azimuth);
            Validate(coordinate.Height);
        }
        catch (ArgumentException e)
        {
            throw ArgumentExceptionFactory.InvalidState<CylindricalCoordinate>(argumentExpression, e);
        }
    }

    /// <summary>Validates that <paramref name="coordinate"/> represents a <see cref="GeodeticCoordinate"/> supported by Horizons, and throws an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="coordinate">This <see cref="GeodeticCoordinate"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="coordinate"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(GeodeticCoordinate coordinate, [CallerArgumentExpression(nameof(coordinate))] string? argumentExpression = null)
    {
        try
        {
            Validate(coordinate.Longitude);
            Validate(coordinate.Latitude);
            Validate(coordinate.Height);
        }
        catch (ArgumentException e)
        {
            throw ArgumentExceptionFactory.InvalidState<GeodeticCoordinate>(argumentExpression, e);
        }
    }

    /// <summary>Creates a <see cref="string"/> message describing an invalid member, with <paramref name="value"/>, of a type <typeparamref name="TType"/>.</summary>
    /// <typeparam name="TType">The type containing the invalid member.</typeparam>
    /// <param name="value">The value of the invalid member.</param>
    private static string ExceptionMessage<TType>(Scalar value) => ExceptionMessage<TType>(value, "value");

    /// <summary>Creates a <see cref="string"/> message describing an invalid <paramref name="member"/>, with <paramref name="value"/>, of a type <typeparamref name="TType"/>.</summary>
    /// <typeparam name="TType">The type containing the invalid <paramref name="member"/>.</typeparam>
    /// <param name="value">The value of the invalid <paramref name="member"/>.</param>
    /// <param name="member">The name of the invalid member.</param>
    private static string ExceptionMessage<TType>(Scalar value, string member) => $"The {typeof(TType).Name} represents an invalid {member} ({value})";
}
