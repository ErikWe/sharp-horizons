namespace SharpHorizons.Query.VectorTable;

using SharpHorizons.Vectors;

/// <summary>Specifies what <see cref="VectorTableQuantities"/> and associated <see cref="VectorTableUncertainties"/> are included in the result of a query for <see cref="OrbitalStateVectors"/>.</summary>
public readonly record struct VectorTableContent
{
    /// <summary>Specifies what <see cref="VectorTableQuantities"/> are included in the result of a query for <see cref="OrbitalStateVectors"/>.</summary>
    public VectorTableQuantities Quantities { get; }

    /// <summary>Specifies what <see cref="VectorTableUncertainties"/> are included in the result of a query for <see cref="OrbitalStateVectors"/>.</summary>
    /// <remarks>Any value other than <see cref="VectorTableUncertainties.None"/> requires <see cref="Quantities"/> to represent either <see cref="VectorTableQuantities.Position"/> or <see cref="VectorTableQuantities.StateVectors"/>.</remarks>
    public VectorTableUncertainties Uncertainties { get; }

    /// <summary>Specifies what <paramref name="quantities"/> and associated <paramref name="uncertainties"/> are included in the result of a query for <see cref="OrbitalStateVectors"/>.</summary>
    /// <param name="quantities"><inheritdoc cref="Quantities" path="/summary"/></param>
    /// <param name="uncertainties"><inheritdoc cref="Uncertainties" path="/summary"/>
    /// <para>Any value other than <see cref="VectorTableUncertainties.None"/> requires <paramref name="quantities"/> to represent either <see cref="VectorTableQuantities.Position"/> or <see cref="VectorTableQuantities.StateVectors"/>.</para></param>
    public VectorTableContent(VectorTableQuantities quantities, VectorTableUncertainties uncertainties)
    {
        Quantities = quantities;
        Uncertainties = uncertainties;
    }
}