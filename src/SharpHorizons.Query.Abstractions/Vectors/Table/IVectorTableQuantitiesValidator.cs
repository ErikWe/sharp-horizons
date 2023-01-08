namespace SharpHorizons.Query.Vectors.Table;

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

/// <summary>Validates that instances of <see cref="VectorTableQuantities"/> are supported by Horizons.</summary>
public interface IVectorTableQuantitiesValidator
{
    /// <summary>Determines whether the <see cref="VectorTableQuantities"/> <paramref name="quantities"/> is supported by Horizons.</summary>
    /// <param name="quantities">This <see cref="VectorTableQuantities"/> is validated.</param>
    public abstract bool CheckSupport(VectorTableQuantities quantities);

    /// <summary>Validates that the <see cref="VectorTableQuantities"/> <paramref name="quantities"/> is supported by Horizons, throwing an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="quantities">This <see cref="VectorTableQuantities"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="quantities"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ThrowIfUnsupported(VectorTableQuantities quantities, [CallerArgumentExpression(nameof(quantities))] string? argumentExpression = null);
}
