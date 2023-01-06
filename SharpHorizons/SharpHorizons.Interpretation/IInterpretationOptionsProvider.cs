namespace SharpHorizons.Interpretation;

using SharpHorizons.Query.Result;
using SharpHorizons.Settings.Interpretation;

/// <summary>Provides options related to the interpretation of <see cref="QueryResult"/>.</summary>
public interface IInterpretationOptionsProvider
{
    /// <inheritdoc cref="InterpretationOptions.HorizonsTimeZoneID"/>
    public abstract string HorizonsTimeZoneID { get; }

    /// <inheritdoc cref="InterpretationOptions.BlockSeparator"/>
    public abstract string BlockSeparator { get; }

    /// <inheritdoc cref="InterpretationOptions.UnavailableText"/>
    public abstract string UnavailableText { get; }
}
