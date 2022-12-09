namespace SharpHorizons.Query.Vectors.Table;

using System;

/// <inheritdoc cref="IVectorTableContentValidator"/>
internal sealed class VectorTableContentValidator : IVectorTableContentValidator
{
    /// <inheritdoc cref="IVectorTableQuantitiesValidator"/>
    private IVectorTableQuantitiesValidator TableQuantitiesValidator { get; }

    /// <inheritdoc cref="VectorTableContentValidator"/>
    /// <param name="tableQuantitiesValidator"><inheritdoc cref="TableQuantitiesValidator" path="/summary"/></param>
    public VectorTableContentValidator(IVectorTableQuantitiesValidator? tableQuantitiesValidator = null)
    {
        TableQuantitiesValidator = tableQuantitiesValidator ?? new VectorTableQuantitiesValidator();
    }

    bool IVectorTableContentValidator.CheckSupport(VectorTableContent content) => CheckUncertaintiesValidity(content.Uncertainties) && TableQuantitiesValidator.CheckSupport(content.Quantities) && CheckCombinationSupport(content);

    void IVectorTableContentValidator.ThrowIfUnsupported(VectorTableContent content, string? argumentExpression)
    {
        VectorTableContent.Validate(content, argumentExpression);

        try
        {
            TableQuantitiesValidator.ThrowIfUnsupported(content.Quantities);
        }
        catch (ArgumentException e)
        {
            throw ArgumentExceptionFactory.InvalidState<VectorTableContent>(argumentExpression, e);
        }

        if (CheckCombinationSupport(content) is false)
        {
            throw ArgumentExceptionFactory.InvalidState<VectorTableContent>(argumentExpression, new UnsupportedVectorTableContentException(UnsupportedContentExceptionMessage));
        }
    }

    /// <summary>A <see cref="string"/> describing an <see cref="UnsupportedVectorTableContentException"/>.</summary>
    private static string UnsupportedContentExceptionMessage => $"The {nameof(VectorTableContent)} does not represent a configuration supported by Horizons. Including any {nameof(VectorTableUncertainties)} requires {nameof(VectorTableQuantities)} to be \"{VectorTableQuantities.Position}\" or \"{VectorTableQuantities.StateVectors}\".";

    /// <summary>Checks whether <paramref name="uncertainties"/> represents a valid <see cref="VectorTableUncertainties"/>.</summary>
    /// <param name="uncertainties">This <see cref="VectorTableUncertainties"/> is validated.</param>
    private static bool CheckUncertaintiesValidity(VectorTableUncertainties uncertainties) => (uncertainties & VectorTableUncertainties.All) == uncertainties;

    /// <summary>Checks whether the combination of <see cref="VectorTableQuantities"/> and <see cref="VectorTableUncertainties"/> represented by <paramref name="tableContent"/> is supported by Horizons.</summary>
    /// <param name="tableContent">The combination of <see cref="VectorTableQuantities"/> and <see cref="VectorTableUncertainties"/> represented by this <see cref="VectorTableContent"/> is validated.</param>
    private static bool CheckCombinationSupport(VectorTableContent tableContent)
    {
        if (tableContent.Uncertainties is VectorTableUncertainties.None)
        {
            return true;
        }

        return tableContent.Quantities is VectorTableQuantities.Position or VectorTableQuantities.StateVectors; 
    }
}
