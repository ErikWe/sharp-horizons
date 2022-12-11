namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using Microsoft.Extensions.Configuration;

using SharpHorizons.Query.Vectors;

/// <summary>Specifies how the result of a <see cref="IVectorsQuery"/> is interpreted.</summary>
internal sealed class VectorsInterpretationOptions
{
    /// <summary>Describes the name of the <see cref="IConfigurationSection"/> which describes <see cref="VectorsInterpretationOptions"/>.</summary>
    internal static string Section { get; } = "Interpretation:Ephemeris:Vectors";

    /// <summary>The key corresponding to the <see cref="Query.OutputUnits"/>.</summary>
    public string OutputUnits { get; set; } = null!;

    /// <summary>The key corresponding to the <see cref="Query.Vectors.VectorCorrection"/>.</summary>
    public string VectorCorrection { get; set; } = null!;

    /// <summary>The key corresponding to the <see cref="Query.Vectors.Table.VectorTableContent"/>.</summary>
    public string VectorTableContent { get; set; } = null!;

    /// <summary>Applies the default values to <paramref name="options"/>.</summary>
    /// <param name="options">The default values are applied to these <see cref="VectorsInterpretationOptions"/>.</param>
    public static void ApplyDefaults(VectorsInterpretationOptions options)
    {
        options.OutputUnits = DefaultVectorsInterpretation.Default.OutputUnits;
        options.VectorCorrection = DefaultVectorsInterpretation.Default.VectorCorrection;
        options.VectorTableContent = DefaultVectorsInterpretation.Default.VectorTableContent;
    }
}
