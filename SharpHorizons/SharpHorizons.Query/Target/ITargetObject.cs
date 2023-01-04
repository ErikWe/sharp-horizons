namespace SharpHorizons.Query.Target;

/// <summary>Represents an object, relative to which a <see cref="ITarget"/> is expressed.</summary>
public interface ITargetObject
{
    /// <summary>Composes a <see cref="TargetObjectIdentifier"/> describing the <see cref="ITargetObject"/>.</summary>
    public abstract TargetObjectIdentifier ComposeIdentifier();
}
