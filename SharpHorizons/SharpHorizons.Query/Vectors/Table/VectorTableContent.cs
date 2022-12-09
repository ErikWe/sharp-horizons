namespace SharpHorizons.Query.Vectors.Table;

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>Specifies what <see cref="VectorTableQuantities"/> and associated <see cref="VectorTableUncertainties"/> are included in the result of a <see cref="IVectorsQuery"/>.</summary>
public readonly record struct VectorTableContent
{
    /// <summary>Specifies what <see cref="VectorTableQuantities"/> are included in the result of a <see cref="IVectorsQuery"/>.</summary>
    /// <exception cref="InvalidEnumArgumentException"/>
    /// <exception cref="InvalidOperationException"/>
    public required VectorTableQuantities Quantities
    {
        get
        {
            Validate();

            return quantities;
        }
        init
        {
            Validate(value);

            quantities = value;
        }
    }

    /// <summary>Specifies what <see cref="VectorTableUncertainties"/> are included in the result of a <see cref="IVectorsQuery"/>.</summary>
    /// <exception cref="InvalidEnumArgumentException"/>
    public VectorTableUncertainties Uncertainties
    {
        get => uncertainties;
        init
        {
            Validate(value);

            uncertainties = value;
        }
    }

    /// <inheritdoc cref="VectorTableContent"/>
    public VectorTableContent() { }

    /// <inheritdoc cref="VectorTableContent"/>
    /// <param name="quantities"><inheritdoc cref="Quantities" path="/summary"/></param>
    /// <exception cref="InvalidEnumArgumentException"/>
    [SetsRequiredMembers]
    public VectorTableContent(VectorTableQuantities quantities) : this(quantities, VectorTableUncertainties.None) { }

    /// <inheritdoc cref="VectorTableContent"/>
    /// <param name="quantities"><inheritdoc cref="Quantities" path="/summary"/></param>
    /// <param name="uncertainties"><inheritdoc cref="Uncertainties" path="/summary"/></param>
    /// <exception cref="InvalidEnumArgumentException"/>
    [SetsRequiredMembers]
    public VectorTableContent(VectorTableQuantities quantities, VectorTableUncertainties uncertainties)
    {
        Validate(quantities);
        Validate(uncertainties);

        Quantities = quantities;
        Uncertainties = uncertainties;
    }

    /// <summary>Backing field for <see cref="Quantities"/>. Should not be used elsewhere.</summary>
    private readonly VectorTableQuantities quantities;
    /// <summary>Backing field for <see cref="Uncertainties"/>. Should not be used elsewhere.</summary>
    private readonly VectorTableUncertainties uncertainties = VectorTableUncertainties.None;

    /// <summary>Validates that <paramref name="quantities"/> represents a valid <see cref="VectorTableQuantities"/>, and throws an <see cref="InvalidEnumArgumentException"/> otherwise.</summary>
    /// <param name="quantities">This <see cref="VectorTableQuantities"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="quantities"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static void Validate(VectorTableQuantities quantities, [CallerArgumentExpression(nameof(quantities))] string? argumentExpression = null)
    {
        if ((quantities & VectorTableQuantities.All) != quantities)
        {
            throw InvalidEnumArgumentExceptionFactory.Create(quantities, argumentExpression);
        }
    }

    /// <summary>Validates that <paramref name="uncertainties"/> represents a valid <see cref="VectorTableUncertainties"/>, and throws an <see cref="InvalidEnumArgumentException"/> otherwise.</summary>
    /// <param name="uncertainties">This <see cref="VectorTableUncertainties"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="uncertainties"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static void Validate(VectorTableUncertainties uncertainties, [CallerArgumentExpression(nameof(uncertainties))] string? argumentExpression = null)
    {
        if ((uncertainties & VectorTableUncertainties.All) != uncertainties)
        {
            throw InvalidEnumArgumentExceptionFactory.Create(uncertainties, argumentExpression);
        }
    }

    /// <summary>Validates the <see cref="VectorTableContent"/> <paramref name="content"/>, and throws an <see cref="Exception"/> of type <typeparamref name="TException"/> if invalid.</summary>
    /// <typeparam name="TException">The type of the <see cref="Exception"/> that is thrown if <paramref name="content"/> is invalid.</typeparam>
    /// <param name="content">This <see cref="VectorTableContent"/> is validated.</param>
    /// <param name="exceptionInstantiation">Handles instantiation of <typeparamref name="TException"/>.</param>
    private static void Validate<TException>(VectorTableContent content, ExceptionInstantiation<TException> exceptionInstantiation) where TException : Exception
    {
        try
        {
            Validate(content.quantities);
            Validate(content.uncertainties);
        }
        catch (InvalidEnumArgumentException e)
        {
            throw exceptionInstantiation(e);
        }
    }

    /// <summary>Validates the <see cref="VectorTableContent"/>, and throws an <see cref="InvalidOperationException"/> if invalid.</summary>
    /// <exception cref="InvalidOperationException"/>
    private void Validate() => Validate(this, InvalidOperationExceptionFactory.InvalidState<VectorTableContent>);

    /// <summary>Validates the <see cref="VectorTableContent"/> <paramref name="content"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="content">This <see cref="VectorTableContent"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="content"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(VectorTableContent content, [CallerArgumentExpression(nameof(content))] string? argumentExpression = null) => Validate(content, ArgumentExceptionFactory.InvalidStateDelegate<VectorTableContent>(argumentExpression));
}
