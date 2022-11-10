using SharpHorizons.Query.Arguments;

namespace SharpHorizons.Query.Target;

/// <summary>Represents the target in a query.</summary>
public interface ITarget
{
    /// <summary>Composes a <see cref="ICommandArgument"/> describing the target.</summary>
    public abstract ICommandArgument ComposeArgument();
}