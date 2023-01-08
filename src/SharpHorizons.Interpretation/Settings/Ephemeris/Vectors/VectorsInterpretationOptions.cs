namespace SharpHorizons.Settings.Interpretation.Ephemeris.Vectors;

using Microsoft.Extensions.Configuration;

using SharpHorizons.Query.Vectors;

/// <summary>Allows options related to the interpretation of the result of <see cref="IVectorsQuery"/> to be specified.</summary>
internal sealed class VectorsInterpretationOptions
{
    /// <summary>The identifier of the <see cref="IConfigurationSection"/> associated with <see cref="VectorsInterpretationOptions"/>.</summary>
    internal static string Section { get; } = "Interpretation:Ephemeris:Vectors";

    /// <summary>The key corresponding to the <see cref="SharpHorizons.Query.OutputUnits"/>.</summary>
    public string OutputUnits { get; set; } = null!;

    /// <summary>The key corresponding to the <see cref="SharpHorizons.Query.Vectors.VectorCorrection"/>.</summary>
    public string VectorCorrection { get; set; } = null!;

    /// <summary>The key corresponding to the <see cref="SharpHorizons.Query.Vectors.Table.VectorTableContent"/>.</summary>
    public string VectorTableContent { get; set; } = null!;

    /// <summary>The key corresponding to the <see cref="SharpHorizons.Query.ReferencePlane"/>.</summary>
    public string ReferencePlane { get; set; } = null!;

    /// <summary>Applies the default values to the <see cref="VectorsInterpretationOptions"/> <paramref name="options"/>.</summary>
    /// <param name="options">The default values are applied to this <see cref="VectorsInterpretationOptions"/>.</param>
    public static void ApplyDefaults(VectorsInterpretationOptions options)
    {
        options.OutputUnits = DefaultVectorsInterpretationSettings.Default.OutputUnits;
        options.VectorCorrection = DefaultVectorsInterpretationSettings.Default.VectorCorrection;
        options.VectorTableContent = DefaultVectorsInterpretationSettings.Default.VectorTableContent;
        options.ReferencePlane = DefaultVectorsInterpretationSettings.Default.ReferencePlane;
    }
}
