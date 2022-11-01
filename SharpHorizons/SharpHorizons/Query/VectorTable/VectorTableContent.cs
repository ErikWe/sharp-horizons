namespace SharpHorizons.Query.VectorTable;

using SharpHorizons.Vectors;

/// <summary>Specifies what quantities and associated uncertainties are included in the result of a query for <see cref="OrbitalStateVectors"/>.</summary>
public readonly record struct VectorTableContent
{
    /// <summary>Specifies what quantities are included in the result of a query for <see cref="OrbitalStateVectors"/>.</summary>
    public VectorTableQuantities Quantities { get; }

    /// <summary>Specifies what uncertainties are included in the result of a query for <see cref="OrbitalStateVectors"/>.</summary>
    /// <remarks>Any value other than <see cref="VectorTableUncertainties.None"/> requires <see cref="Quantities"/> to represent either <see cref="VectorTableQuantities.Position"/> or <see cref="VectorTableQuantities.StateVectors"/>.</remarks>
    public VectorTableUncertainties Uncertainties { get; }

    /// <summary>Specifies what <paramref name="quantities"/> and associated <paramref name="uncertainties"/> are included in the result of a query for <see cref="OrbitalStateVectors"/>.</summary>
    /// <param name="quantities">Specifies what quantities are included in the result of a query for <see cref="OrbitalStateVectors"/>.</param>
    /// <param name="uncertainties">Specifies what uncertainties are included in the result of a query for <see cref="OrbitalStateVectors"/>.
    /// <para>Any value other than <see cref="VectorTableUncertainties.None"/> requires <paramref name="quantities"/> to represent either <see cref="VectorTableQuantities.Position"/> or <see cref="VectorTableQuantities.StateVectors"/>.</para></param>
    public VectorTableContent(VectorTableQuantities quantities, VectorTableUncertainties uncertainties)
    {
        Quantities = quantities;
        Uncertainties = uncertainties;
    }
}