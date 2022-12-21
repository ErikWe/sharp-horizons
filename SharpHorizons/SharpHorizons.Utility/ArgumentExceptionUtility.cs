namespace SharpHorizons;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>Provides utility related to <see cref="ArgumentException"/></summary>
public static class ArgumentExceptionUtility
{
    /// <summary>Throws an <see cref="ArgumentException"/> if <paramref name="argument"/> is <see langword="null"/>, empty, or consisting only of white-space characters.</summary>
    /// <param name="argument">An <see cref="ArgumentException"/> is thrown if this <see cref="string"/> is <see langword="null"/>, empty, or consisting only of white-space characters.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="argument"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public static void ThrowIfNullOrWhiteSpace([NotNull] string? argument, [CallerArgumentExpression(nameof(argument))] string? argumentExpression = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(argument, argumentExpression);

        if (string.IsNullOrWhiteSpace(argument))
        {
            throw ArgumentExceptionFactory.WhiteSpace(argumentExpression);
        }
    }
}
