namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using FakeTimeZone;

using System;

public abstract class ATimeZoneFixture : IDisposable
{
    private FakeLocalTimeZone Mock { get; }

    private bool IsDisposed { get; set; }

    protected ATimeZoneFixture(string timeZoneID)
    {
        Mock = new FakeLocalTimeZone(TimeZoneInfo.FindSystemTimeZoneById(timeZoneID));
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (IsDisposed)
        {
            return;
        }

        if (disposing)
        {
            Mock.Dispose();
        }

        IsDisposed = true;
    }
}
