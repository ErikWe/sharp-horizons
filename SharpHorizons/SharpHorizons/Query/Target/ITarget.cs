namespace SharpHorizons.Query.Target;

/// <summary>Represents the target in a query.</summary>
public interface ITarget
{
    /// <summary>Composes a <see cref="ITargetArgument"/> describing the target.</summary>
    public abstract ITargetArgument ComposeArgument();
}