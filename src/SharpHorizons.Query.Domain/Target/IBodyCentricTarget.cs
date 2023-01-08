namespace SharpHorizons.Query.Target;

/// <summary>Describes the <see cref="ITarget"/> in a query as the center of some <see cref="ITargetObject"/>.</summary>
public interface IBodyCentricTarget : ITarget
{
    /// <summary>Some <see cref="ITargetObject"/>, the center of which represents the <see cref="ITarget"/> in a query.</summary>
    public abstract ITargetObject TargetObject { get; }
}
