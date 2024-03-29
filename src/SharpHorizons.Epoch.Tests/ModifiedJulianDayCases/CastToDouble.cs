﻿namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System;

using Xunit;

public class CastToDouble
{
    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDays))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDays))]
    public void Valid_ApproximateMatch(ModifiedJulianDay modifiedJulianDay)
    {
        var actual = (double)modifiedJulianDay;

        Asserter.Approximate(modifiedJulianDay.Day, actual);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => (double)(ModifiedJulianDay)null!);

        Assert.IsType<ArgumentNullException>(exception);
    }
}
