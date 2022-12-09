namespace SharpHorizons;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

/// <summary>Handles construction of <see cref="InvalidEnumArgumentException"/></summary>
public static class InvalidEnumArgumentExceptionFactory
{
    /// <summary>Throws an <see cref="InvalidEnumArgumentException"/> if <paramref name="value"/> is not an explicitly defined member of <typeparamref name="TEnum"/>.</summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="value">The instance of <typeparamref name="TEnum"/> which is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="value"/>.</param>
    /// <remarks>For an enum used as a bit field, use <see cref="ThrowIfInvalid{TEnum}(TEnum, TEnum, string?)"/>.</remarks>
    /// <exception cref="InvalidEnumArgumentException"/>
    public static void ThrowIfUnlisted<TEnum>(TEnum value, [CallerArgumentExpression(nameof(value))] string? argumentExpression = null) where TEnum : Enum
    {
        if (Enum.IsDefined(typeof(TEnum), value) is false)
        {
            throw Create(value, argumentExpression);
        }
    }

    /// <summary>Throws an <see cref="InvalidEnumArgumentException"/> if the bit field <paramref name="value"/> consists of bits not present in <paramref name="all"/>.</summary>
    /// <typeparam name="TEnum">The type of the enum, used as a bit field.</typeparam>
    /// <param name="value">The instance of <typeparamref name="TEnum"/> which is validated.</param>
    /// <param name="all">The instance of <typeparamref name="TEnum"/> representing all available bits set to 1.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="value"/>.</param>
    /// <remarks>For an enum used as a bit field, use <see cref="ThrowIfInvalid{TEnum}(TEnum, TEnum, string?)"/>.</remarks>
    /// <exception cref="InvalidEnumArgumentException"/>
    public static void ThrowIfInvalid<TEnum>(TEnum value, TEnum all, [CallerArgumentExpression(nameof(value))] string? argumentExpression = null) where TEnum : Enum
    {
        var underlyingType = Enum.GetUnderlyingType(typeof(TEnum));

        if (SignedTypes.Contains(underlyingType))
        {
            var longValue = Convert.ToInt64(value);
            var longAll = Convert.ToInt64(all);

            if ((longValue & longAll) != longValue)
            {
                throw Create(value, argumentExpression);
            }
        }

        var ulongValue = Convert.ToUInt64(value);
        var ulongAll = Convert.ToUInt64(all);

        if ((ulongValue & ulongAll) != ulongValue)
        {
            throw Create(value, argumentExpression);
        }
    }

    /// <summary>Constructs a <see cref="InvalidEnumArgumentException"/> for an enum of type <typeparamref name="TEnum"/> having an invalid <paramref name="value"/>.</summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="value">The instance of <typeparamref name="TEnum"/> with an invalid value.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="value"/>.</param>
    public static InvalidEnumArgumentException Create<TEnum>(TEnum value, [CallerArgumentExpression(nameof(value))] string? argumentExpression = null) where TEnum : Enum => new($"The value of argument {argumentExpression} ({value}) is invalid for Enum type {typeof(TEnum).Name}.");

    /// <summary>The set of signed integral <see cref="Type"/>.</summary>
    private static HashSet<Type> SignedTypes { get; } = new(5)
    {
        typeof(sbyte),
        typeof(short),
        typeof(int),
        typeof(long),
        typeof(nint)
    };
}
