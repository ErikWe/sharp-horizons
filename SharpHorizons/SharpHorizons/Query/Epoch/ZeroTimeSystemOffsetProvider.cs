namespace SharpHorizons.Query.Epoch;

using SharpMeasures;

/// <summary>Acts as a <see cref="ITimeSystemOffsetProvider"/> that always provides the value <see cref="Time.Zero"/>.</summary>
internal sealed class ZeroTimeSystemOffsetProvider : ITimeSystemOffsetProvider
{
    Time ITimeSystemOffsetProvider.Offset(IEpoch epoch, TimeSystem origin, TimeSystem target) => Time.Zero;
}
