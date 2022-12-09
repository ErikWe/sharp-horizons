namespace SharpHorizons.Query.Vectors.Table;

using System.Collections.Generic;

/// <inheritdoc cref="IVectorTableQuantitiesValidator"/>
internal sealed class VectorTableQuantitiesValidator : IVectorTableQuantitiesValidator
{
    /// <summary>The set of <see cref="VectorTableQuantities"/> not supported by Horizons.</summary>
    private static HashSet<VectorTableQuantities> UnsupportedQuantities { get; } = new(2)
    {
        VectorTableQuantities.None,
        VectorTableQuantities.Velocity | VectorTableQuantities.Distance
    };

    bool IVectorTableQuantitiesValidator.CheckSupport(VectorTableQuantities quantities) => CheckValidity(quantities) && CheckSupport(quantities);

    void IVectorTableQuantitiesValidator.ThrowIfUnsupported(VectorTableQuantities quantities, string? argumentExpression)
    {
        if (CheckValidity(quantities) is false)
        {
            throw InvalidEnumArgumentExceptionFactory.Create(quantities);
        }

        if (CheckSupport(quantities) is false)
        {
            throw ArgumentExceptionFactory.InvalidState<VectorTableQuantities>(argumentExpression, new UnsupportedVectorTableQuantitiesException(UnsupportedQuantitiesExceptionMessage));
        }
    }

    /// <summary>A <see cref="string"/> describing an <see cref="UnsupportedVectorTableQuantitiesException"/>.</summary>
    private static string UnsupportedQuantitiesExceptionMessage => $"The {nameof(VectorTableQuantities)} does not represent a configuration supported by Horizons. Try using \"{VectorTableQuantities.All}\".";

    /// <summary>Checks whether <paramref name="quantities"/> represents a valid <see cref="VectorTableQuantities"/>.</summary>
    /// <param name="quantities">This <see cref="VectorTableQuantities"/> is validated.</param>
    private static bool CheckValidity(VectorTableQuantities quantities) => (quantities & VectorTableQuantities.All) == quantities;

    /// <summary>Checks whether <paramref name="quantities"/> represents a <see cref="VectorTableQuantities"/> supported by Horizons.</summary>
    /// <param name="quantities">This <see cref="VectorTableQuantities"/> is validated.</param>
    private static bool CheckSupport(VectorTableQuantities quantities) => UnsupportedQuantities.Contains(quantities) is false;
}
