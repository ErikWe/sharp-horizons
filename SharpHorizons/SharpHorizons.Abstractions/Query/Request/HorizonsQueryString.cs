namespace SharpHorizons.Query.Request;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>Represents a <see cref="string"/> that describes a Horizons query.</summary>
public readonly record struct HorizonsQueryString
{
    /// <summary>The <see cref="string"/> that describe a Horizons query.</summary>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    public required string Value
    {
        get
        {
            Validate();

            return valueField!;
        }
        init
        {
            Validate(value);

            valueField = value;
        }
    }

    /// <inheritdoc cref="HorizonsQueryString"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    [SetsRequiredMembers]
    public HorizonsQueryString(string value)
    {
        Value = value;
    }

    /// <summary>Retrieves the <see cref="Value"/> represented by the <see cref="HorizonsQueryString"/>.</summary>
    /// <exception cref="InvalidOperationException"/>
    public override string ToString() => Value;

    /// <summary>Backing field for <see cref="Value"/>. Should not be used elsewhere.</summary>
    private readonly string? valueField;

    /// <inheritdoc cref="HorizonsQueryString(string)"/>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public static explicit operator HorizonsQueryString(string value) => new(value);

    /// <summary>Retrieves the <see cref="Value"/> represented by <paramref name="queryString"/>.</summary>
    /// <param name="queryString"><inheritdoc cref="HorizonsQueryString" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    public static explicit operator string(HorizonsQueryString queryString)
    {
        Validate(queryString);

        return queryString.valueField!;
    }

    /// <summary>Validates that <paramref name="value"/> can be used to represent the value of a <see cref="HorizonsQueryString"/>, and throws an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="value"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    private static void Validate(string? value, [CallerArgumentExpression(nameof(value))] string? argumentExpression = null) => ArgumentException.ThrowIfNullOrEmpty(value, argumentExpression);

    /// <summary>Validates the <see cref="HorizonsQueryString"/> <paramref name="queryString"/>, and throws an <see cref="Exception"/> of type <typeparamref name="TException"/> if invalid.</summary>
    /// <typeparam name="TException">The type of the <see cref="Exception"/> that is thrown if <paramref name="queryString"/> is invalid.</typeparam>
    /// <param name="queryString">This <see cref="HorizonsQueryString"/> is validated.</param>
    /// <param name="exceptionInstantiation">Handles instantiation of <typeparamref name="TException"/>.</param>
    private static void Validate<TException>(HorizonsQueryString queryString, ExceptionInstantiation<TException> exceptionInstantiation) where TException : Exception
    {
        try
        {
            Validate(queryString.valueField);
        }
        catch (ArgumentException e)
        {
            throw exceptionInstantiation(e);
        }
    }

    /// <summary>Validates the <see cref="HorizonsQueryString"/>, and throws an <see cref="InvalidOperationException"/> if invalid.</summary>
    /// <exception cref="InvalidOperationException"/>
    private void Validate() => Validate(this, InvalidOperationExceptionFactory.InvalidState<HorizonsQueryString>);

    /// <summary>Validates the <see cref="HorizonsQueryString"/> <paramref name="queryString"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="queryString">This <see cref="HorizonsQueryString"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="queryString"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(HorizonsQueryString queryString, [CallerArgumentExpression(nameof(queryString))] string? argumentExpression = null) => Validate(queryString, ArgumentExceptionFactory.InvalidStateDelegate<HorizonsQueryString>(argumentExpression));
}
