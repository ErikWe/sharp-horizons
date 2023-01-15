namespace SharpHorizons.Settings.Interpretation.Ephemeris.Vectors;

using Microsoft.Extensions.Configuration;

using SharpHorizons.Interpretation.Ephemeris.Vectors;
using SharpHorizons.Query.Vectors;

using System.Diagnostics.CodeAnalysis;

/// <summary>Allows options related to the interpretation of the result of <see cref="IVectorsQuery"/> to be specified.</summary>
/// <remarks>Once specified, a <see cref="IVectorsInterpretationOptionsProvider"/> should be used to access the options.</remarks>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class VectorsInterpretationOptions
{
    /// <summary>The identifier of the <see cref="IConfigurationSection"/> associated with <see cref="VectorsInterpretationOptions"/>.</summary>
    internal static string Section { get; } = "Ephemeris:Vectors";

    /// <inheritdoc cref="IVectorsInterpretationOptionsProvider.OutputUnits"/>
    public string OutputUnits { get; set; } = null!;

    /// <inheritdoc cref="IVectorsInterpretationOptionsProvider.VectorCorrection"/>
    public string VectorCorrection { get; set; } = null!;

    /// <inheritdoc cref="IVectorsInterpretationOptionsProvider.VectorTableContent"/>
    public string VectorTableContent { get; set; } = null!;

    /// <inheritdoc cref="IVectorsInterpretationOptionsProvider.ReferencePlane"/>
    public string ReferencePlane { get; set; } = null!;

    /// <inheritdoc cref="IVectorsInterpretationOptionsProvider.SmallPerturbers"/>
    public string SmallPerturbers { get; set; } = null!;

    /// <summary>Applies the default values to the <see cref="VectorsInterpretationOptions"/> <paramref name="options"/>.</summary>
    /// <param name="options">The default values are applied to this <see cref="VectorsInterpretationOptions"/>.</param>
    public static void ApplyDefaults(VectorsInterpretationOptions options)
    {
        options.OutputUnits = DefaultVectorsInterpretationSettings.Default.OutputUnits;
        options.VectorCorrection = DefaultVectorsInterpretationSettings.Default.VectorCorrection;
        options.VectorTableContent = DefaultVectorsInterpretationSettings.Default.VectorTableContent;
        options.ReferencePlane = DefaultVectorsInterpretationSettings.Default.ReferencePlane;
        options.SmallPerturbers = DefaultVectorsInterpretationSettings.Default.SmallPerturbers;
    }
}
