using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Client.Infrastructure;
using XivApiSharp.Tests.Options.Schemas.ClauseTests;

namespace XivApiSharp.Tests;

[TestFixture]
public class QueryStringTests
{
    [Test]
    public void QueryString_AddClause_Success()
    {
        StringClauseOptions options = TestSetup.Options.QueryStringTests.AddClauseTest;

        // Create clauses to add
        IClause<string> firstClause = TestSetup.BuildClause(options, options.Value);

        // Create QueryString
        IQueryString queryString = new QueryString();
        queryString.AddClause(firstClause);

        Assert.That(queryString.ToUriEncodedString(), Is.EqualTo(options.ExpectedValue));

        // TODO: Finish implementing QueryString unit test
        //  Implement QueryString creation under IXivApiService
        //      Either repurpose IClauseFactory as a general factory or create a new one
        //  Test if GroupClauses work in QueryString
        //  Test if nested GroupClauses work
    }

    [Test]
    public void QueryString_AddClauses_Success()
    {
        ClauseGroupOptions options = TestSetup.Options.QueryStringTests.AddClausesTest;

        // Create clauses to add
        IClause<string> firstClause = TestSetup.BuildClause(options.FirstClause, options.FirstClause.Value);
        IClause<int> secondClause = TestSetup.BuildClause(options.SecondClause, options.SecondClause.Value);
        IClause<double> thirdClause = TestSetup.BuildClause(options.ThirdClause, options.ThirdClause.Value);

        // Create QueryString
        IQueryString queryString = new QueryString();
        queryString.AddClauses([firstClause, secondClause, thirdClause]);

        Assert.That(queryString.ToUriEncodedString(), Is.EqualTo(options.ExpectedValue));
    }

    [Test]
    public void QueryString_AddClauseGroup_Success()
    {
        ClauseGroupOptions options = TestSetup.Options.QueryStringTests.AddClauseGroupTest;

        // Create clauses to add
        IClause<string> firstClause = TestSetup.BuildClause(options.FirstClause, options.FirstClause.Value);
        IClause<int> secondClause = TestSetup.BuildClause(options.SecondClause, options.SecondClause.Value);
        IClause<double> thirdClause = TestSetup.BuildClause(options.ThirdClause, options.ThirdClause.Value);

        // Create QueryString with added clause group
        IClauseGroup clauseGroup = TestSetup.Service.NewClauseGroup()
            .WithDecorator(options.Decorator)
            .WithClauses([firstClause, secondClause, thirdClause])
            .Build();
        IQueryString queryString = new QueryString();
        queryString.AddClause(clauseGroup);

        Assert.That(queryString.ToUriEncodedString(), Is.EqualTo(options.ExpectedValue));
    }
}