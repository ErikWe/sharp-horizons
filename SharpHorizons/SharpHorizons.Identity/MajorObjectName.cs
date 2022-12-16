namespace SharpHorizons;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>Represents the name of a <see cref="MajorObject"/>.</summary>
public readonly record struct MajorObjectName
{
    /// <summary>The <see cref="string"/> name of the <see cref="MajorObject"/>.</summary>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    public required string Value
    {
        get
        {
            try
            {
                ArgumentException.ThrowIfNullOrEmpty(valueField);
            }
            catch (ArgumentException e)
            {
                throw InvalidOperationExceptionFactory.InvalidState<MajorObjectName>(e);
            }

            return valueField;
        }
        init
        {
            ArgumentException.ThrowIfNullOrEmpty(value);

            valueField = value;
        }
    }

    /// <inheritdoc cref="MajorObjectName"/>
    public MajorObjectName() { }

    /// <inheritdoc cref="MajorObjectName"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    [SetsRequiredMembers]
    public MajorObjectName(string value)
    {
        Value = value;
    }

    /// <summary>Retrieves the <see cref="Value"/> represented by the <see cref="MajorObjectName"/>.</summary>
    /// <exception cref="InvalidOperationException"/>
    public override string ToString() => Value;

    /// <summary>Backing field for <see cref="Value"/>. Should not be used elsewhere.</summary>
    private readonly string? valueField;

    /// <inheritdoc cref="MajorObjectName"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public static explicit operator MajorObjectName(string value) => new(value);

    /// <summary>Retrieves the <see cref="Value"/> represented by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName"><inheritdoc cref="MajorObjectName" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    public static explicit operator string(MajorObjectName majorObjectName)
    {
        try
        {
            return majorObjectName.Value;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<MajorObjectName>(nameof(majorObjectName), e);
        }
    }

    /// <summary>Validates the <see cref="MajorObjectName"/> <paramref name="name"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="name">This <see cref="MajorObjectName"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="name"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(MajorObjectName name, [CallerArgumentExpression(nameof(name))] string? argumentExpression = null)
    {
        try
        {
            _ = name.Value;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<MajorObjectName>(argumentExpression, e);
        }
    }
}
