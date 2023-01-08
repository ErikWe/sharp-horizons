namespace SharpHorizons.Query.Vectors.Table;

using System.Collections.Generic;

/// <inheritdoc cref="IVectorTableQuantitiesValidator"/>
public sealed class VectorTableQuantitiesValidator : IVectorTableQuantitiesValidator
{
    /// <summary>The set of <see cref="VectorTableQuantities"/> not supported by Horizons.</summary>
    private static HashSet<VectorTableQuantities> UnsupportedQuantities { get; } = new(2)
    {
        VectorTableQuantities.None,
        VectorTableQuantities.Velocity | VectorTableQuantities.Distance
    };

    /// <inheritdoc/>
    public bool CheckSupport(VectorTableQuantities quantities) => CheckValidity(quantities) && CheckSupportForValid(quantities);

    /// <inheritdoc/>
    public void ThrowIfUnsupported(VectorTableQuantities quantities, string? argumentExpression)
    {
        if (CheckValidity(quantities) is false)
        {
            throw InvalidEnumArgumentExceptionFactory.Create(quantities);
        }

        if (CheckSupportForValid(quantities) is false)
        {
            throw ArgumentExceptionFactory.InvalidState<VectorTableQuantities>(argumentExpression, new UnsupportedVectorTableQuantitiesException(UnsupportedQuantitiesExceptionMessage));
        }
    }

    /// <summary>A <see cref="string"/> describing an <see cref="UnsupportedVectorTableQuantitiesException"/>.</summary>
    private static string UnsupportedQuantitiesExceptionMessage => $"The {nameof(VectorTableQuantities)} does not represent a configuration supported by Horizons. Try using \"{VectorTableQuantities.All}\".";

    /// <summary>Determines the validity of the <see cref="VectorTableQuantities"/> <paramref name="quantities"/>.</summary>
    /// <param name="quantities">This <see cref="VectorTableQuantities"/> is validated.</param>
    private static bool CheckValidity(VectorTableQuantities quantities) => (quantities & VectorTableQuantities.All) == quantities;

    /// <summary>Determines whether the validated <see cref="VectorTableQuantities"/> <paramref name="quantities"/> is supported by Horizons.</summary>
    /// <param name="quantities">The support for this validated <see cref="VectorTableQuantities"/> is determined.</param>
    private static bool CheckSupportForValid(VectorTableQuantities quantities) => UnsupportedQuantities.Contains(quantities) is false;
}
