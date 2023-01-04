namespace SharpHorizons.Query.Vectors.Table;

using System;
using System.Runtime.CompilerServices;

/// <summary>Validates that instances of <see cref="VectorTableContent"/> represent configurations supported by Horizons.</summary>
public interface IVectorTableContentValidator
{
    /// <summary>Checks whether <paramref name="content"/> represents a <see cref="VectorTableContent"/> supported by Horizons.</summary>
    /// <param name="content">The validity of this <see cref="VectorTableContent"/> is checked.</param>
    public abstract bool CheckSupport(VectorTableContent content);

    /// <summary>Validates that <paramref name="content"/> represents a <see cref="VectorTableContent"/> supported by Horizons, and throws an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="content">This <see cref="VectorTableContent"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="content"/>.</param>
    /// <exception cref="ArgumentException"/>
    public abstract void ThrowIfUnsupported(VectorTableContent content, [CallerArgumentExpression(nameof(content))] string? argumentExpression = null);
}
