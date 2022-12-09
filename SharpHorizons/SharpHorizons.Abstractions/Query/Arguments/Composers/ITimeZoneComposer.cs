
using SharpHorizons.Query.Epoch;

using SharpMeasures;

namespace SharpHorizons.Query.Arguments.Composers;
/// <summary>Composes <see cref="ITimeZoneArgument"/> that describe a <see cref="Time"/> offset to some <see cref="TimeSystem"/>.</summary>
public interface ITimeZoneComposer : IArgumentComposer<ITimeZoneArgument, Time> { }
