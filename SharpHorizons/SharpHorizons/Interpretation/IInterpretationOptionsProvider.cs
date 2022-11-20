namespace SharpHorizons.Interpretation;

/// <summary>Provides options for how the result of a query is interpreted.</summary>
public interface IInterpretationOptionsProvider
{
    /// <inheritdoc cref="InterpretationOptions.RawTextSource"/>
    public abstract string RawTextSource { get; }

    /// <inheritdoc cref="InterpretationOptions.BlockSeparator"/>
    public abstract string BlockSeparator { get; }

    /// <inheritdoc cref="InterpretationOptions.RawTextVersion"/>
    public abstract string RawTextVersion { get; }

    /// <inheritdoc cref="InterpretationOptions.UnavailableText"/>
    public abstract string UnavailableText { get; }
}
