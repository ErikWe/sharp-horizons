namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Ephemeris;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>Represents the <see cref="string"/> identifier of a quantity present in an <see cref="IEphemeris{TEntry}"/>.</summary>
public readonly record struct EphemerisQuantityIdentifier
{
    /// <summary>The <see cref="string"/> identifier of the quantity in an <see cref="IEphemeris{TEntry}"/>.</summary>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    public required string Identifier
    {
        get
        {
            try
            {
                Validate(identifierField);
            }
            catch (ArgumentException e)
            {
                throw InvalidOperationExceptionFactory.InvalidState<EphemerisQuantityIdentifier>(e);
            }

            return identifierField;
        }
        init
        {
            Validate(value);

            identifierField = value;
        }
    }

    /// <summary>The <see cref="int"/> character length of the field representing the <see cref="EphemerisQuantityIdentifier"/> in an <see cref="IEphemeris{TEntry}"/>, if relevant.</summary>
    /// <exception cref="ArgumentOutOfRangeException"/>
    /// <exception cref="InvalidOperationException"/>
    public int? CharacterLength
    {
        get
        {
            try
            {
                Validate(characterLengthField);
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw InvalidOperationExceptionFactory.InvalidState<EphemerisQuantityIdentifier>(e);
            }

            return characterLengthField;
        }
        init
        {
            Validate(value);

            characterLengthField = value;
        }
    }

    /// <inheritdoc cref="EphemerisQuantityIdentifier"/>
    public EphemerisQuantityIdentifier() { }

    /// <inheritdoc cref="EphemerisQuantityIdentifier"/>
    /// <param name="identifier"><inheritdoc cref="Identifier" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    [SetsRequiredMembers]
    public EphemerisQuantityIdentifier(string identifier)
    {
        Identifier = identifier;
    }

    /// <inheritdoc cref="EphemerisQuantityIdentifier"/>
    /// <param name="identifier"><inheritdoc cref="Identifier" path="/summary"/></param>
    /// <param name="characterLength"><inheritdoc cref="CharacterLength" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    [SetsRequiredMembers]
    public EphemerisQuantityIdentifier(string identifier, int? characterLength)
    {
        Identifier = identifier;
        CharacterLength = characterLength;
    }

    /// <summary>Backing field for <see cref="Identifier"/>. Should not be used elsewhere.</summary>
    private readonly string? identifierField;
    /// <summary>Backing field for <see cref="CharacterLength"/>. Should not be used elsewhere.</summary>
    private readonly int? characterLengthField;

    /// <summary>Validates that <paramref name="identifier"/> can be used to represent the identifier of an <see cref="EphemerisQuantityIdentifier"/>, and throws an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="identifier"><inheritdoc cref="Identifier" path="/summary"/></param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="identifier"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    private static void Validate([NotNull] string? identifier, [CallerArgumentExpression(nameof(identifier))] string? argumentExpression = null) => ArgumentException.ThrowIfNullOrEmpty(identifier, argumentExpression);

    /// <summary>Validates that <paramref name="characterLength"/> can be used to represent the character length of an <see cref="EphemerisQuantityIdentifier"/>, and throws an <see cref="ArgumentOutOfRangeException"/> otherwise.</summary>
    /// <param name="characterLength"><inheritdoc cref="CharacterLength" path="/summary"/></param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="characterLength"/>.</param>
    /// <exception cref="ArgumentOutOfRangeException"/>
    private static void Validate(int? characterLength, [CallerArgumentExpression(nameof(characterLength))] string? argumentExpression = null)
    {
        if (characterLength.HasValue && characterLength.Value <= 0)
        {
            throw new ArgumentOutOfRangeException(argumentExpression, characterLength.Value, $"A value greater than 0 should be used to describe the {nameof(CharacterLength)} of an {nameof(EphemerisQuantityIdentifier)}.");
        }
    }

    /// <summary>Validates the <see cref="EphemerisQuantityIdentifier"/> <paramref name="quantity"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="quantity">This <see cref="EphemerisQuantityIdentifier"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="quantity"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(EphemerisQuantityIdentifier quantity, [CallerArgumentExpression(nameof(quantity))] string? argumentExpression = null)
    {
        try
        {
            _ = quantity.Identifier;
            _ = quantity.CharacterLength;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<EphemerisQuantityIdentifier>(argumentExpression, e);
        }
    }
}
