namespace SharpHorizons.Query.Target;

using SharpHorizons.Identification;
using SharpHorizons.Query.Arguments;

using System.Globalization;

/// <summary>Describes the <see cref="ITarget"/> in a query as an object identified by an <see cref="MPCSequentialNumber"/>.</summary>
internal sealed record class MPCSequentialNumberTarget : ITarget
{
    /// <summary>The <see cref="MPCSequentialNumber"/> of an object, the center of which represents the <see cref="ITarget"/> in a query.</summary>
    private MPCSequentialNumber Number { get; }

    /// <summary>Describes the <see cref="ITarget"/> in a query as an object identified by <paramref name="number"/>.</summary>
    /// <param name="number"><inheritdoc cref="Number" path="/summary"/></param>
    public MPCSequentialNumberTarget(MPCSequentialNumber number)
    {
        Number = number;
    }

    ITargetArgument ITarget.ComposeArgument() => new TargetArgument(Number.Value.ToString(CultureInfo.InvariantCulture));
}
