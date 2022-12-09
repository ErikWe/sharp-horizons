namespace SharpHorizons.Query.Origin;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>An identifier describing an <see cref="IOriginObject"/>.</summary>
public readonly record struct OriginObjectIdentifier
{
    /// <summary>The identifier describing the <see cref="IOriginObject"/>.</summary>
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

    /// <inheritdoc cref="OriginObjectIdentifier"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    [SetsRequiredMembers]
    public OriginObjectIdentifier(string value)
    {
        Value = value;
    }

    /// <summary>Retrieves the <see cref="Value"/> represented by the <see cref="OriginObjectIdentifier"/>.</summary>
    /// <exception cref="InvalidOperationException"/>
    public override string ToString() => Value;

    /// <summary>Backing field for <see cref="Value"/>. Should not be used elsewhere.</summary>
    private readonly string? valueField;

    /// <inheritdoc cref="OriginObjectIdentifier(string)"/>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public static explicit operator OriginObjectIdentifier(string value) => new(value);

    /// <summary>Retrieves the <see cref="Value"/> represented by <paramref name="originObject"/>.</summary>
    /// <param name="originObject"><inheritdoc cref="OriginObjectIdentifier" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    public static explicit operator string(OriginObjectIdentifier originObject)
    {
        Validate(originObject);

        return originObject.valueField!;
    }

    /// <summary>Validates that <paramref name="value"/> can be used to represent the identifier of an <see cref="IOriginObject"/>, and throws an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="value"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    private static void Validate(string? value, [CallerArgumentExpression(nameof(value))] string? argumentExpression = null) => ArgumentException.ThrowIfNullOrEmpty(value, argumentExpression);

    /// <summary>Validates the <see cref="OriginObjectIdentifier"/> <paramref name="identifier"/>, and throws an <see cref="Exception"/> of type <typeparamref name="TException"/> if invalid.</summary>
    /// <typeparam name="TException">The type of the <see cref="Exception"/> that is thrown if <paramref name="identifier"/> is invalid.</typeparam>
    /// <param name="identifier">This <see cref="OriginObjectIdentifier"/> is validated.</param>
    /// <param name="exceptionInstantiation">Handles instantiation of <typeparamref name="TException"/>.</param>
    private static void Validate<TException>(OriginObjectIdentifier identifier, ExceptionInstantiation<TException> exceptionInstantiation) where TException : Exception
    {
        try
        {
            Validate(identifier.valueField);
        }
        catch (ArgumentException e)
        {
            throw exceptionInstantiation(e);
        }
    }

    /// <summary>Validates the <see cref="OriginObjectIdentifier"/>, and throws an <see cref="InvalidOperationException"/> if invalid.</summary>
    /// <exception cref="InvalidOperationException"/>
    private void Validate() => Validate(this, InvalidOperationExceptionFactory.InvalidState<OriginObjectIdentifier>);

    /// <summary>Validates the <see cref="OriginObjectIdentifier"/> <paramref name="identifier"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="identifier">This <see cref="OriginObjectIdentifier"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="identifier"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(OriginObjectIdentifier identifier, [CallerArgumentExpression(nameof(identifier))] string? argumentExpression = null) => Validate(identifier, ArgumentExceptionFactory.InvalidStateDelegate<OriginObjectIdentifier>(argumentExpression));
}
