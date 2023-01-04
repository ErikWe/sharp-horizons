namespace SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;

/// <summary>Acts as a <see cref="ITimeSystemOffsetProvider"/> that always provides the value <see cref="Time.Zero"/>.</summary>
internal sealed class ZeroTimeSystemOffsetProvider : ITimeSystemOffsetProvider
{
    Time ITimeSystemOffsetProvider.Offset(IEpoch epoch, TimeSystem origin, TimeSystem target)
    {
        ArgumentNullException.ThrowIfNull(epoch);

        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(origin);
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(target);

        if (origin is TimeSystem.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(origin);
        }

        if (target is TimeSystem.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(target);
        }

        return Time.Zero;
    }
}
