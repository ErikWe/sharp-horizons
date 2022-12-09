namespace SharpHorizons.Query.Arguments.Composers;

using SharpHorizons.Query.Vectors.Table;

using System.ComponentModel;
using System.Globalization;
using System.Text;

/// <inheritdoc cref="IVectorTableContentComposer"/>
internal sealed class VectorTableContentComposer : IVectorTableContentComposer
{
    /// <inheritdoc cref="IVectorTableContentValidator"/>
    private IVectorTableContentValidator ContentValidator { get; }

    /// <inheritdoc cref="VectorTableContentComposer"/>
    /// <param name="contentValidator"><inheritdoc cref="ContentValidator" path="/summary"/></param>
    public VectorTableContentComposer(IVectorTableContentValidator contentValidator)
    {
        ContentValidator = contentValidator;
    }

    IVectorTableContentArgument IArgumentComposer<IVectorTableContentArgument, VectorTableContent>.Compose(VectorTableContent obj)
    {
        ContentValidator.ThrowIfUnsupported(obj);

        try
        {
            return new QueryArgument($"{GetQuantitiesIdentifier(obj.Quantities)}{GetUncertaintyIdentifier(obj.Uncertainties)}");
        }
        catch (InvalidEnumArgumentException e)
        {
            throw ArgumentExceptionFactory.InvalidState<VectorTableContent>(nameof(obj), e);
        }
    }

    /// <summary>Retrieves a <see cref="string"/> identifier that describes <paramref name="quantities"/>.</summary>
    /// <param name="quantities">The retrieved identifier describes these <see cref="VectorTableQuantities"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static string GetQuantitiesIdentifier(VectorTableQuantities quantities) => (quantities switch
    {
        VectorTableQuantities.Position => 1,
        VectorTableQuantities.StateVectors => 2,
        VectorTableQuantities.All => 3,
        VectorTableQuantities.Position | VectorTableQuantities.Distance => 4,
        VectorTableQuantities.Velocity => 5,
        VectorTableQuantities.Distance => 6,
        _ => throw InvalidEnumArgumentExceptionFactory.Create(quantities)
    }).ToString(CultureInfo.InvariantCulture);

    /// <summary>Retrieves a <see cref="string"/> identifier that describes <paramref name="uncertainties"/>.</summary>
    /// <param name="uncertainties">The retrieved identifier describes these <see cref="VectorTableUncertainties"/>.</param>
    private static string GetUncertaintyIdentifier(VectorTableUncertainties uncertainties)
    {
        var uncertaintyBuilder = new StringBuilder(4);

        if (uncertainties.HasFlag(VectorTableUncertainties.XYZ))
        {
            uncertaintyBuilder.Append('x');
        }

        if (uncertainties.HasFlag(VectorTableUncertainties.ACN))
        {
            uncertaintyBuilder.Append('a');
        }

        if (uncertainties.HasFlag(VectorTableUncertainties.RTN))
        {
            uncertaintyBuilder.Append('r');
        }

        if (uncertainties.HasFlag(VectorTableUncertainties.POS))
        {
            uncertaintyBuilder.Append('p');
        }

        return uncertaintyBuilder.ToString();
    }
}
