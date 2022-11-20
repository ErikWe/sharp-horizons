namespace SharpHorizons.Query.VectorTable;

using SharpHorizons.Ephemeris.Vectors;

using System.Diagnostics.CodeAnalysis;

/// <summary>Specifies what <see cref="VectorTableQuantities"/> and associated <see cref="VectorTableUncertainties"/> are included in the result of a query for <see cref="IOrbitalStateVectors"/>.</summary>
public readonly record struct VectorTableContent
{
    /// <summary>Specifies what <see cref="VectorTableQuantities"/> are included in the result of a query for <see cref="IOrbitalStateVectors"/>.</summary>
    public required VectorTableQuantities Quantities { get; init; }

    /// <summary>Specifies what <see cref="VectorTableUncertainties"/> are included in the result of a query for <see cref="IOrbitalStateVectors"/>.</summary>
    /// <remarks>Any value other than <see cref="VectorTableUncertainties.None"/> requires <see cref="Quantities"/> to represent either <see cref="VectorTableQuantities.Position"/> or <see cref="VectorTableQuantities.StateVectors"/>.</remarks>
    public required VectorTableUncertainties Uncertainties { get; init; }

    /// <inheritdoc cref="VectorTableContent"/>
    public VectorTableContent() { }

    /// <inheritdoc cref="VectorTableContent"/>
    /// <param name="quantities"><inheritdoc cref="Quantities" path="/summary"/></param>
    /// <param name="uncertainties"><inheritdoc cref="Uncertainties" path="/summary"/>
    /// <para>Any value other than <see cref="VectorTableUncertainties.None"/> requires <paramref name="quantities"/> to represent either <see cref="VectorTableQuantities.Position"/> or <see cref="VectorTableQuantities.StateVectors"/>.</para></param>
    [SetsRequiredMembers]
    public VectorTableContent(VectorTableQuantities quantities, VectorTableUncertainties uncertainties)
    {
        Quantities = quantities;
        Uncertainties = uncertainties;
    }
}