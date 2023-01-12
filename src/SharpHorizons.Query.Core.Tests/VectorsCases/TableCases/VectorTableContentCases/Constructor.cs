namespace SharpHorizons.Tests.QueryCases.VectorsCases.TableCases.VectorTableContentCases;

using SharpHorizons.Query.Vectors.Table;

using System.ComponentModel;

using Xunit;

public class Constructor
{
    [Theory]
    [ClassData(typeof(Datasets.ValidTableContentTuples))]
    public void Valid_Both_ExactMatch(VectorTableQuantities quantities, VectorTableUncertainties uncertainties)
    {
        VectorTableContent actual = new(quantities, uncertainties);

        Assert.Equal(quantities, actual.Quantities);
        Assert.Equal(uncertainties, actual.Uncertainties);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidTableContentTuples))]
    public void Invalid_Both_InvalidEnumArgumentException(VectorTableQuantities quantities, VectorTableUncertainties uncertainties)
    {
        var exception = Record.Exception(() => new VectorTableContent(quantities, uncertainties));

        Assert.IsType<InvalidEnumArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidVectorTableQuantities))]
    public void Valid_JustQuantities_ExactMatch(VectorTableQuantities quantities)
    {
        VectorTableContent actual = new(quantities);

        Assert.Equal(quantities, actual.Quantities);
        Assert.Equal(VectorTableUncertainties.None, actual.Uncertainties);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidVectorTableQuantities))]
    public void Invalid_JustQuantities_InvalidEnumArgumentException(VectorTableQuantities quantities)
    {
        var exception = Record.Exception(() => new VectorTableContent(quantities));

        Assert.IsType<InvalidEnumArgumentException>(exception);
    }
}
