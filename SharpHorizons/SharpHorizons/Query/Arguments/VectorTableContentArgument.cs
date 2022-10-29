namespace SharpHorizons.Query.Arguments;

using SharpHorizons.Query;

using System.Globalization;
using System.Text;

/// <inheritdoc cref="IVectorTableContentArgument"/>
internal sealed record class VectorTableContentArgument : IVectorTableContentArgument
{
    /// <inheritdoc/>
    public QueryArgument Value { get; }

    /// <summary><inheritdoc cref="VectorTableContentArgument" path="/summary"/></summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    private VectorTableContentArgument(QueryArgument value)
    {
        Value = value;
    }

    /// <summary>Composes a <see cref="IVectorTableContentArgument"/> describing <paramref name="vectorTableContent"/>.</summary>
    /// <param name="vectorTableContent">A <see cref="IVectorTableContentArgument"/> is composed based on this <see cref="VectorTableContent"/>.</param>
    /// <exception cref="UnsupportedVectorTableException"/>
    public static IVectorTableContentArgument Extract(VectorTableContent vectorTableContent)
    {
        if ((vectorTableContent.Uncertainties | VectorTableUncertainties.All) is not VectorTableUncertainties.All)
        {
            throw new UnsupportedVectorTableException();
        }

        if (vectorTableContent.Uncertainties is not VectorTableUncertainties.None && vectorTableContent.Quantities is not VectorTableQuantities.Position or VectorTableQuantities.StateVectors)
        {
            throw new UnsupportedVectorTableException();
        }

        var vectorTableContentCode = vectorTableContent.Quantities switch
        {
            VectorTableQuantities.Position => 1,
            VectorTableQuantities.StateVectors => 2,
            VectorTableQuantities.All => 3,
            VectorTableQuantities.Position | VectorTableQuantities.Distance => 4,
            VectorTableQuantities.Velocity => 5,
            VectorTableQuantities.Distance => 6,
            _ => throw new UnsupportedVectorTableException()
        };

        return new VectorTableContentArgument($"{vectorTableContentCode.ToString(CultureInfo.InvariantCulture)}{getUncertaintyString()}");

        string getUncertaintyString()
        {
            var uncertaintyBuilder = new StringBuilder(4);

            if (vectorTableContent.Uncertainties.HasFlag(VectorTableUncertainties.XYZ))
            {
                uncertaintyBuilder.Append('x');
            }

            if (vectorTableContent.Uncertainties.HasFlag(VectorTableUncertainties.ACN))
            {
                uncertaintyBuilder.Append('a');
            }

            if (vectorTableContent.Uncertainties.HasFlag(VectorTableUncertainties.RTN))
            {
                uncertaintyBuilder.Append('r');
            }

            if (vectorTableContent.Uncertainties.HasFlag(VectorTableUncertainties.POS))
            {
                uncertaintyBuilder.Append('p');
            }

            return uncertaintyBuilder.ToString();
        }
    }
}