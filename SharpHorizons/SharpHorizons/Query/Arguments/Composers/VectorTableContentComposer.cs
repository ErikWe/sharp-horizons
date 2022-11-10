namespace SharpHorizons.Query.Arguments.Composers;

using SharpHorizons.Query;
using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.VectorTable;

using System.Globalization;
using System.Text;

/// <summary>Composes <see cref="IVectorTableContentArgument"/> that describe <see cref="VectorTableContent"/>.</summary>
internal sealed class VectorTableContentComposer : IVectorTableContentComposer
{
    IVectorTableContentArgument IArgumentComposer<IVectorTableContentArgument, VectorTableContent>.Compose(VectorTableContent obj)
    {
        if ((obj.Uncertainties | VectorTableUncertainties.All) is not VectorTableUncertainties.All)
        {
            throw new UnsupportedVectorTableException($"{obj.Uncertainties} is not of a supported {typeof(VectorTableUncertainties).FullName}.");
        }

        if (obj.Uncertainties is not VectorTableUncertainties.None && obj.Quantities is not VectorTableQuantities.Position or VectorTableQuantities.StateVectors)
        {
            throw new UnsupportedVectorTableException($"{obj.Quantities} is not compatible with {obj.Uncertainties}.");
        }

        return new QueryArgument($"{GetQuantitiesIdentifier(obj.Quantities)}{GetUncertaintyIdentifier(obj.Uncertainties)}");
    }

    /// <summary>Retrieves a <see cref="string"/> identifier that describes <paramref name="quantities"/>.</summary>
    /// <param name="quantities">The retrieved identifier describes these <see cref="VectorTableQuantities"/>.</param>
    /// <exception cref="UnsupportedVectorTableException"></exception>
    private static string GetQuantitiesIdentifier(VectorTableQuantities quantities) => (quantities switch
    {
        VectorTableQuantities.Position => 1,
        VectorTableQuantities.StateVectors => 2,
        VectorTableQuantities.All => 3,
        VectorTableQuantities.Position | VectorTableQuantities.Distance => 4,
        VectorTableQuantities.Velocity => 5,
        VectorTableQuantities.Distance => 6,
        _ => throw new UnsupportedVectorTableException($"{quantities} was not of a supported {typeof(VectorTableQuantities).FullName}.")
    }).ToString(CultureInfo.InvariantCulture);

    /// <summary>Retrieves a <see cref="string"/> identifier that describes <paramref name="uncertainties"/>.</summary>
    /// <param name="uncertainties">The retrieved identifier describes these <see cref="VectorTableUncertainties"/>.</param>
    /// <exception cref="UnsupportedVectorTableException"></exception>
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
