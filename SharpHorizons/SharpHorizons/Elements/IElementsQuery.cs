namespace SharpHorizons.Elements;

using SharpHorizons.Calendars;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;

/// <summary>Describes a query for <see cref="OsculatingOrbitalElements"/> of a <see cref="ITarget"/> relative to an <see cref="IOrigin"/>.</summary>
public interface IElementsQuery
{
    /// <summary>The <see cref="ITarget"/>, for which the <see cref="OsculatingOrbitalElements"/> are queried.</summary>
    public abstract ITarget Target { get; }

    /// <summary>The <see cref="IOrigin"/>, relative to which the <see cref="OsculatingOrbitalElements"/> of the <see cref="ITarget"/> are expressed.</summary>
    public abstract IOrigin Origin { get; }

    /// <summary>Determines the <see cref="IEpoch"/> of the <see cref="OsculatingOrbitalElements"/>.</summary>
    public abstract IEpochSelection Epochs { get; }
}
