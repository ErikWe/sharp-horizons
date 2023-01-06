namespace SharpHorizons.Query.Vectors.Table;

using System;
using System.Runtime.CompilerServices;

/// <summary>Validates that instances of <see cref="VectorTableContent"/> are supported by Horizons.</summary>
public interface IVectorTableContentValidator
{
    /// <summary>Determines whether the <see cref="VectorTableContent"/> <paramref name="content"/> is supported by Horizons.</summary>
    /// <param name="content">This <see cref="VectorTableContent"/> is validated.</param>
    public abstract bool CheckSupport(VectorTableContent content);

    /// <summary>Validates that the <see cref="VectorTableContent"/> <paramref name="content"/> is supported by Horizons, throwing an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="content">This <see cref="VectorTableContent"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="content"/>.</param>
    /// <exception cref="ArgumentException"/>
    public abstract void ThrowIfUnsupported(VectorTableContent content, [CallerArgumentExpression(nameof(content))] string? argumentExpression = null);
}
