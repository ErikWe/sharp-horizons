namespace SharpHorizons.Query.Target;

using SharpHorizons.Identification;
using SharpHorizons.Query.Arguments;

/// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by a <see cref="MajorObjectName"/>.</summary>
internal sealed record class MajorObjectNameTarget : ITarget, ITargetSiteObject
{
    /// <summary>The <see cref="MajorObjectName"/> of an object, the center of which represents the <see cref="ITarget"/> in a query.</summary>
    private MajorObjectName Name { get; }

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by <paramref name="name"/>.</summary>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    public MajorObjectNameTarget(MajorObjectName name)
    {
        Name = name;
    }

    TargetArgument ITarget.ComposeIdentifier() => Name.Value;
    TargetSiteObjectIdentifier ITargetSiteObject.ComposeIdentifier() => Name.Value;
}
