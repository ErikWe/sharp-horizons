namespace SharpHorizons.Query.Target;

using SharpHorizons.Identification;
using SharpHorizons.Query.Arguments;

/// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by an <see cref="MPCName"/>.</summary>
internal sealed record class MPCNameTarget : ITarget
{
    /// <summary>The <see cref="MPCName"/> of an object, the center of which represents the <see cref="ITarget"/> in a query.</summary>
    private MPCName Name { get; }

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by <paramref name="name"/>.</summary>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    public MPCNameTarget(MPCName name)
    {
        Name = name;
    }

    TargetArgument ITarget.ComposeIdentifier() => Name.Value;
}
