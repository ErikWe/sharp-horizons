namespace SharpHorizons;

using System;
using System.Runtime.CompilerServices;

/// <summary>Handles construction of <see cref="ArgumentException"/></summary>
public static class ArgumentExceptionFactory
{
    /// <summary>Constructs a <see cref="ArgumentException"/> describing an argument of type <typeparamref name="TEnum"/> having an unsupported <paramref name="value"/>.</summary>
    /// <typeparam name="TEnum">The type of the <paramref name="value"/>, an <see cref="Enum"/> type.</typeparam>
    /// <param name="value">The instance of <typeparamref name="TEnum"/> with an unsupported value.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="value"/>.</param>
    public static ArgumentException UnsupportedEnumValue<TEnum>(TEnum value, [CallerArgumentExpression(nameof(value))] string? argumentExpression = null) where TEnum : Enum => new($"The value \"{value}\" of {typeof(TEnum).Name} is not supported.", argumentExpression);

    /// <summary>Constructs a <see cref="ArgumentException"/> describing an instance of <typeparamref name="T"/> representing an invalid state.</summary>
    /// <typeparam name="T">The type of the instance that represents an invalid state.</typeparam>
    /// <param name="argumentExpression">The expression used as the argument which caused the <see cref="ArgumentException"/>.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="ArgumentException"/>.</param>
    public static ArgumentException InvalidState<T>(string? argumentExpression, Exception? innerException = null) => new($"The {typeof(T).Name} does not represent a valid state.", argumentExpression, innerException);

    /// <summary>Constructs a <see cref="ArgumentException"/> describing an internal error of an argument of type <typeparamref name="T"/>.</summary>
    /// <typeparam name="T">The type of the instance within which the internal error occurred.</typeparam>
    /// <param name="argumentExpression">The expression used as the argument which caused the <see cref="ArgumentException"/>.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="ArgumentException"/>.</param>
    public static ArgumentException InternalException<T>(string? argumentExpression, Exception innerException) => new($"An exception occurred within the {typeof(T).Name}.", argumentExpression, innerException);

    /// <summary>Constructs a <see cref="ArgumentException"/> describing a <see cref="string"/> that unexpectedly consisted of only white-space characters.</summary>
    /// <param name="argumentExpression">The expression used as the argument which caused the <see cref="ArgumentException"/>.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="ArgumentException"/>.</param>
    public static ArgumentException WhiteSpace(string? argumentExpression, Exception? innerException = null) => new($"The {nameof(String)} should not consist of only white-space characters.", argumentExpression, innerException);
}
