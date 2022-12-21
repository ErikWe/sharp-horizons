namespace SharpHorizons;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

/// <summary>Provides utility related to <see cref="InvalidEnumArgumentException"/></summary>
public static class InvalidEnumArgumentExceptionUtility
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
            throw InvalidEnumArgumentExceptionFactory.Create(value, argumentExpression);
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
                throw InvalidEnumArgumentExceptionFactory.Create(value, argumentExpression);
            }
        }

        var ulongValue = Convert.ToUInt64(value);
        var ulongAll = Convert.ToUInt64(all);

        if ((ulongValue & ulongAll) != ulongValue)
        {
            throw InvalidEnumArgumentExceptionFactory.Create(value, argumentExpression);
        }
    }

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
