namespace SharpHorizons;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>Represents the name of a <see cref="MajorObject"/>.</summary>
public readonly record struct ObjectRadiiInterpretation
{
    /// <summary>The <see cref="string"/> name of the <see cref="MajorObject"/>.</summary>
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

    /// <inheritdoc cref="ObjectRadiiInterpretation"/>
    public ObjectRadiiInterpretation() { }

    /// <inheritdoc cref="ObjectRadiiInterpretation"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    [SetsRequiredMembers]
    public ObjectRadiiInterpretation(string value)
    {
        Value = value;
    }

    /// <summary>Retrieves the <see cref="Value"/> represented by the <see cref="ObjectRadiiInterpretation"/>.</summary>
    /// <exception cref="InvalidOperationException"/>
    public override string ToString() => Value;

    /// <summary>Backing field for <see cref="Value"/>. Should not be used elsewhere.</summary>
    private readonly string? valueField;

    /// <inheritdoc cref="ObjectRadiiInterpretation"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public static explicit operator ObjectRadiiInterpretation(string value) => new(value);

    /// <summary>Retrieves the <see cref="Value"/> represented by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName"><inheritdoc cref="ObjectRadiiInterpretation" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    public static explicit operator string(ObjectRadiiInterpretation majorObjectName)
    {
        Validate(majorObjectName);

        return majorObjectName.valueField!;
    }

    /// <summary>Validates that <paramref name="value"/> can be used to represent the name of a <see cref="MajorObject"/>, and throws an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="value"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    private static void Validate(string? value, [CallerArgumentExpression(nameof(value))] string? argumentExpression = null) => ArgumentException.ThrowIfNullOrEmpty(value, argumentExpression);

    /// <summary>Validates the <see cref="ObjectRadiiInterpretation"/> <paramref name="name"/>, and throws an <see cref="Exception"/> of type <typeparamref name="TException"/> if invalid.</summary>
    /// <typeparam name="TException">The type of the <see cref="Exception"/> that is thrown if <paramref name="name"/> is invalid.</typeparam>
    /// <param name="name">This <see cref="ObjectRadiiInterpretation"/> is validated.</param>
    /// <param name="exceptionInstantiation">Handles instantiation of <typeparamref name="TException"/>.</param>
    private static void Validate<TException>(ObjectRadiiInterpretation name, ExceptionInstantiation<TException> exceptionInstantiation) where TException : Exception
    {
        try
        {
            Validate(name.valueField);
        }
        catch (ArgumentException e)
        {
            throw exceptionInstantiation(e);
        }
    }

    /// <summary>Validates the <see cref="ObjectRadiiInterpretation"/>, and throws an <see cref="InvalidOperationException"/> if invalid.</summary>
    /// <exception cref="InvalidOperationException"/>
    private void Validate() => Validate(this, InvalidOperationExceptionFactory.InvalidState<ObjectRadiiInterpretation>);

    /// <summary>Validates the <see cref="ObjectRadiiInterpretation"/> <paramref name="name"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="name">This <see cref="ObjectRadiiInterpretation"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="name"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(ObjectRadiiInterpretation name, [CallerArgumentExpression(nameof(name))] string? argumentExpression = null) => Validate(name, ArgumentExceptionFactory.InvalidStateDelegate<ObjectRadiiInterpretation>(argumentExpression));
}
