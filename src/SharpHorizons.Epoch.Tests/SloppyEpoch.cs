namespace SharpHorizons.Tests.EpochCases;

using Moq;

using SharpMeasures;

public record class SloppyEpoch : IEpoch<SloppyEpoch>
{
    public static SloppyEpoch GetExceptionThrowingSloppyEpoch()
    {
        Mock<SloppyEpoch> mock = new();

        mock.Setup((epoch) => epoch.ToJulianDay()).Throws<EpochOutOfBoundsException>();

        mock.Setup((epoch) => epoch.Add(It.IsAny<Time>())).Throws<EpochOutOfBoundsException>();
        mock.Setup((epoch) => epoch.Subtract(It.IsAny<Time>())).Throws<EpochOutOfBoundsException>();

        return mock.Object;
    }

    public JulianDay Backing { get; init; } = null!;

    public static SloppyEpoch FromJulianDay(JulianDay julianDay) => new();
    public virtual JulianDay ToJulianDay() => Backing;

    public virtual SloppyEpoch Add(Time difference) => new() { Backing = Backing.Add(difference) };
    public virtual SloppyEpoch Subtract(Time difference) => new() { Backing = Backing.Subtract(difference) };
    public virtual Time Difference(IEpoch initial) => Backing.Difference(initial);

    public virtual int CompareTo(IEpoch? other) => Backing.CompareTo(other);

    public static SloppyEpoch operator +(SloppyEpoch initial, Time difference) => initial.Add(difference);
    public static SloppyEpoch operator -(SloppyEpoch initial, Time difference) => initial.Subtract(difference);
    public static Time operator -(SloppyEpoch final, SloppyEpoch initial) => final.Difference(initial);

    public static bool operator >(SloppyEpoch lhs, SloppyEpoch rhs) => lhs.Backing > rhs.Backing;
    public static bool operator <(SloppyEpoch lhs, SloppyEpoch rhs) => lhs.Backing < rhs.Backing;
    public static bool operator >=(SloppyEpoch lhs, SloppyEpoch rhs) => lhs.Backing >= rhs.Backing;
    public static bool operator <=(SloppyEpoch lhs, SloppyEpoch rhs) => lhs.Backing <= rhs.Backing;
}
