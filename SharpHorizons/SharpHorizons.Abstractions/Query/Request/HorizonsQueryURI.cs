namespace SharpHorizons.Query.Request;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>Represents an <see cref="Uri"/> that describes a Horizons query.</summary>
public readonly record struct HorizonsQueryURI
{
    /// <summary>The <see cref="Uri"/> that describe a Horizons query.</summary>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    public required Uri Value
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

    /// <inheritdoc cref="HorizonsQueryURI"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    [SetsRequiredMembers]
    public HorizonsQueryURI(Uri value)
    {
        Value = value;
    }

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Uri"/> represented by the <see cref="HorizonsQueryURI"/>.</summary>
    /// <exception cref="InvalidOperationException"/>
    public override string ToString() => Value.ToString();

    /// <summary>Backing field for <see cref="Value"/>. Should not be used elsewhere.</summary>
    private readonly Uri? valueField;

    /// <inheritdoc cref="HorizonsQueryURI(Uri)"/>
    /// <exception cref="ArgumentNullException"/>
    public static explicit operator HorizonsQueryURI(Uri value) => new(value);

    /// <summary>Retrieves the <see cref="Value"/> represented by <paramref name="uri"/>.</summary>
    /// <param name="uri"><inheritdoc cref="HorizonsQueryURI" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    public static explicit operator Uri(HorizonsQueryURI uri)
    {
        Validate(uri);

        return uri.Value;
    }

    /// <summary>Validates that <paramref name="value"/> can be used to represent the <see cref="Uri"/> of a <see cref="HorizonsQueryURI"/>, and throws an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="value"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    private static void Validate(Uri? value, [CallerArgumentExpression(nameof(value))] string? argumentExpression = null) => ArgumentNullException.ThrowIfNull(value, argumentExpression);

    /// <summary>Validates the <see cref="HorizonsQueryURI"/> <paramref name="queryURI"/>, and throws an <see cref="Exception"/> of type <typeparamref name="TException"/> if invalid.</summary>
    /// <typeparam name="TException">The type of the <see cref="Exception"/> that is thrown if <paramref name="queryURI"/> is invalid.</typeparam>
    /// <param name="queryURI">This <see cref="HorizonsQueryURI"/> is validated.</param>
    /// <param name="exceptionInstantiation">Handles instantiation of <typeparamref name="TException"/>.</param>
    private static void Validate<TException>(HorizonsQueryURI queryURI, ExceptionInstantiation<TException> exceptionInstantiation) where TException : Exception
    {
        try
        {
            Validate(queryURI.valueField);
        }
        catch (ArgumentException e)
        {
            throw exceptionInstantiation(e);
        }
    }

    /// <summary>Validates the <see cref="HorizonsQueryURI"/>, and throws an <see cref="InvalidOperationException"/> if invalid.</summary>
    /// <exception cref="InvalidOperationException"/>
    private void Validate() => Validate(this, InvalidOperationExceptionFactory.InvalidState<HorizonsQueryURI>);

    /// <summary>Validates the <see cref="HorizonsQueryURI"/> <paramref name="queryURI"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="queryURI">This <see cref="HorizonsQueryURI"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="queryURI"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(HorizonsQueryURI queryURI, [CallerArgumentExpression(nameof(queryURI))] string? argumentExpression = null) => Validate(queryURI, ArgumentExceptionFactory.InvalidStateDelegate<HorizonsQueryURI>(argumentExpression));
}
