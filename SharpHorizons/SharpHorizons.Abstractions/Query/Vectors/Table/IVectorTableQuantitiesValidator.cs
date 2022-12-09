namespace SharpHorizons.Query.Vectors.Table;

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

/// <summary>Validates that instances of <see cref="VectorTableQuantities"/> represent configurations supported by Horizons.</summary>
public interface IVectorTableQuantitiesValidator
{
    /// <summary>Checks whether <paramref name="quantities"/> represents a <see cref="VectorTableQuantities"/> supported by Horizons.</summary>
    /// <param name="quantities">The validity of this <see cref="VectorTableQuantities"/> is checked.</param>
    public abstract bool CheckSupport(VectorTableQuantities quantities);

    /// <summary>Validates that <paramref name="quantities"/> represents a <see cref="VectorTableQuantities"/> supported by Horizons, and throws an exception otherwise.</summary>
    /// <param name="quantities">This <see cref="VectorTableQuantities"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="quantities"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ThrowIfUnsupported(VectorTableQuantities quantities, [CallerArgumentExpression(nameof(quantities))] string? argumentExpression = null);
}
