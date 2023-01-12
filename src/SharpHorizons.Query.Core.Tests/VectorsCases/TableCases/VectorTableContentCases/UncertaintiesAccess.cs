namespace SharpHorizons.Tests.QueryCases.VectorsCases.TableCases.VectorTableContentCases;

using SharpHorizons.Query.Vectors.Table;

using Xunit;

public class UncertaintiesAccess
{
    [Theory]
    [ClassData(typeof(Datasets.ValidTableContents))]
    public void Valid_NoException(VectorTableContent tableContent)
    {
        var exception = Record.Exception(() => tableContent.Uncertainties);

        Assert.Null(exception);
    }
}
