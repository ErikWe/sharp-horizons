namespace SharpHorizons.Query.Target;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>An identifier describing a <see cref="ITargetSite"/>.</summary>
public readonly record struct TargetSiteIdentifier
{
    /// <summary>The identifier describing the <see cref="ITargetSite"/>.</summary>
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

    /// <inheritdoc cref="TargetSiteIdentifier"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    [SetsRequiredMembers]
    public TargetSiteIdentifier(string value)
    {
        Value = value;
    }

    /// <summary>Retrieves the <see cref="Value"/> represented by the <see cref="TargetSiteIdentifier"/>.</summary>
    /// <exception cref="InvalidOperationException"/>
    public override string ToString() => Value;

    /// <summary>Backing field for <see cref="Value"/>. Should not be used elsewhere.</summary>
    private readonly string? valueField;

    /// <inheritdoc cref="TargetSiteIdentifier(string)"/>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public static explicit operator TargetSiteIdentifier(string value) => new(value);

    /// <summary>Retrieves the <see cref="Value"/> represented by <paramref name="targetSite"/>.</summary>
    /// <param name="targetSite"><inheritdoc cref="TargetSiteIdentifier" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    public static explicit operator string(TargetSiteIdentifier targetSite)
    {
        Validate(targetSite);

        return targetSite.valueField!;
    }

    /// <summary>Validates that <paramref name="value"/> can be used to represent the identifier of a <see cref="ITargetSite"/>, and throws an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="value"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    private static void Validate(string? value, [CallerArgumentExpression(nameof(value))] string? argumentExpression = null) => ArgumentException.ThrowIfNullOrEmpty(value, argumentExpression);

    /// <summary>Validates the <see cref="TargetSiteIdentifier"/> <paramref name="identifier"/>, and throws an <see cref="Exception"/> of type <typeparamref name="TException"/> if invalid.</summary>
    /// <typeparam name="TException">The type of the <see cref="Exception"/> that is thrown if <paramref name="identifier"/> is invalid.</typeparam>
    /// <param name="identifier">This <see cref="TargetSiteIdentifier"/> is validated.</param>
    /// <param name="exceptionInstantiation">Handles instantiation of <typeparamref name="TException"/>.</param>
    private static void Validate<TException>(TargetSiteIdentifier identifier, ExceptionInstantiation<TException> exceptionInstantiation) where TException : Exception
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

    /// <summary>Validates the <see cref="TargetSiteIdentifier"/>, and throws an <see cref="InvalidOperationException"/> if invalid.</summary>
    /// <exception cref="InvalidOperationException"/>
    private void Validate() => Validate(this, InvalidOperationExceptionFactory.InvalidState<TargetSiteIdentifier>);

    /// <summary>Validates the <see cref="TargetSiteIdentifier"/> <paramref name="identifier"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="identifier">This <see cref="TargetSiteIdentifier"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="identifier"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(TargetSiteIdentifier identifier, [CallerArgumentExpression(nameof(identifier))] string? argumentExpression = null) => Validate(identifier, ArgumentExceptionFactory.InvalidStateDelegate<TargetSiteIdentifier>(argumentExpression));
}
