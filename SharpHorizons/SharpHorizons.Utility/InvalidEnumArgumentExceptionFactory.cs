namespace SharpHorizons;

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

/// <summary>Handles construction of <see cref="InvalidEnumArgumentException"/></summary>
public static class InvalidEnumArgumentExceptionFactory
{
    /// <summary>Constructs a <see cref="InvalidEnumArgumentException"/> for an enum of type <typeparamref name="TEnum"/> having an invalid <paramref name="value"/>.</summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="value">The instance of <typeparamref name="TEnum"/> with an invalid value.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="value"/>.</param>
    public static InvalidEnumArgumentException Create<TEnum>(TEnum value, [CallerArgumentExpression(nameof(value))] string? argumentExpression = null) where TEnum : Enum => new($"The value of argument {argumentExpression} ({value}) is invalid for Enum type {typeof(TEnum).Name}.");
}
