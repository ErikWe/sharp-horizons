namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;

/// <summary>Represents the step size in a query when the <see cref="IEpochSelection"/> is done according to <see cref="EpochSelectionMode.Range"/>.</summary>
public interface IStepSize
{
    /// <summary>Composes a <see cref="IStepSizeArgument"/> describing the <see cref="IStepSize"/>.</summary>
    public abstract IStepSizeArgument ComposeArgument();
}