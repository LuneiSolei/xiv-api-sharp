using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Tests.Options.Schemas.ClauseTests;

namespace XivApiSharp.Tests;

[TestFixture]
public class XivApiServiceTests
{
    [Test]
    public void XivApiService_NewClause_Success()
    {
        IntClauseOptions options = TestSetup
            .Options
            .XivApiServiceTests
            .NewClauseTest;

        IClause<int> clause = TestSetup.Service.NewClause<int>()
            .WhereSpecifier(options.Specifier)
            .WithLanguage(options.Language)
            .Must
            .Equal(options.Value);

        Assert.That(clause.ToUriEncodedString(), Is.EqualTo(options.ExpectedValue));
    }

    [Test]
    public void XivApiService_NewClauseGroup_Success()
    {
        ClauseGroupOptions options = TestSetup.Options.XivApiServiceTests.NewClauseGroupTest;

        // Convert clause options into actual clauses
        List<IBaseClause> clauses = [];

        clauses.Add(TestSetup.BuildClause(options.FirstClause, options.FirstClause.Value));
        clauses.Add(TestSetup.BuildClause(options.SecondClause, options.SecondClause.Value));
        clauses.Add(TestSetup.BuildClause(options.ThirdClause, options.ThirdClause.Value));

        IClauseGroup clauseGroup = TestSetup.Service.NewClauseGroup()
            .WithClauses(clauses)
            .MustNotMatch
            .Build();

        Assert.That(clauseGroup.ToUriEncodedString(), Is.EqualTo(options.ExpectedValue));
    }
}