namespace SharpHorizons.Query.Target;

using SharpHorizons.Identification;
using SharpHorizons.Query.Arguments;

using System.Globalization;

/// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by a <see cref="MajorObjectID"/>.</summary>
internal sealed record class MajorObjectIDTarget : ITarget, ITargetSiteObject
{
    /// <summary>The <see cref="MajorObjectID"/> of an object, the center of which represents the <see cref="ITarget"/> in a query.</summary>
    private MajorObjectID ID { get; }

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by <paramref name="id"/>.</summary>
    /// <param name="id"><inheritdoc cref="ID" path="/summary"/></param>
    public MajorObjectIDTarget(MajorObjectID id)
    {
        ID = id;
    }

    TargetArgument ITarget.ComposeIdentifier() => ID.Value.ToString(CultureInfo.InvariantCulture);
    TargetSiteObjectIdentifier ITargetSiteObject.ComposeIdentifier() => ID.Value.ToString(CultureInfo.InvariantCulture);
}
