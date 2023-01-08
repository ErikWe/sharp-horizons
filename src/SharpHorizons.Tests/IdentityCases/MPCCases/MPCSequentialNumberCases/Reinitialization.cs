namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCSequentialNumberCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Reinitialization
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCSequentialNumberInts))]
    public void Reinitialization_Valid_ExactMatch(int number)
    {
        var actual = InitialMPCSequentialNumber with { Value = number };

        Assert.Equal(number, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCSequentialNumberInts))]
    public void Renitialization_Invalid_ArgumentOutOfRangeException(int number)
    {
        var exception = Record.Exception(() => InitialMPCSequentialNumber with { Value = number });

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }

    private static MPCSequentialNumber InitialMPCSequentialNumber => new(1);
}
