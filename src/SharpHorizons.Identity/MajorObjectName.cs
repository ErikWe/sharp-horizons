namespace SharpHorizons;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>Represents the <see cref="string"/> name of a <see cref="MajorObject"/>.</summary>
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
                ArgumentExceptionUtility.ThrowIfNullOrWhiteSpace(valueField);
            }
            catch (ArgumentException e)
            {
                throw InvalidOperationExceptionFactory.InvalidState<MajorObjectName>(e);
            }

            return valueField;
        }
        init
        {
            ArgumentExceptionUtility.ThrowIfNullOrWhiteSpace(value);

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

    /// <summary>Retrieves the <see cref="string"/> <see cref="Value"/> represented by the <see cref="MajorObjectName"/>.</summary>
    /// <exception cref="InvalidOperationException"/>
    public override string ToString() => Value;

    /// <summary>Backing field for <see cref="Value"/>. Should not be used elsewhere.</summary>
    private readonly string? valueField;

    /// <summary>Constructs a <see cref="MajorObjectName"/>, representing the <see cref="string"/> <paramref name="value"/>.</summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public static MajorObjectName FromString(string value) => new(value);

    /// <inheritdoc cref="MajorObjectName"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public static explicit operator MajorObjectName(string value) => FromString(value);

    /// <summary>Retrieves the <see cref="string"/> <see cref="Value"/> represented by <paramref name="majorObjectName"/>.</summary>
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

    /// <summary>Validates the <see cref="MajorObjectName"/> <paramref name="name"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
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
