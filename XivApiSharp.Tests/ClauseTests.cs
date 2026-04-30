using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Tests.Options.Schemas.ClauseTests;

namespace XivApiSharp.Tests;

[TestFixture]
public class ClauseTests
{
    [Test]
    public void Factory_CreateClauseString_Success()
    {
        // Get the options
        StringClauseOptions options = TestSetup
            .Options
            .ClauseTests
            .CreateClauseTest;

        // Test the clause
        IClause<string> clause = TestSetup.Service.NewClause<string>()
            .WithDecorator(options.Decorator)
            .WithSpecifier(options.Specifier)
            .WithLanguage(options.Language)
            .WithOperator(options.Operator)
            .WithValue(options.Value)
            .Build();

        Assert.That(clause.ToUnencodedString(),
            Is.EqualTo(options.ExpectedValue));
    }

    [Test]
    public void Clause_ToUriEncodedString_Success()
    {
        UIntClauseOptions options = TestSetup
            .Options
            .ClauseTests
            .ToUriEncodedStringTest;

        IClause<uint> clause = TestSetup.Service.NewClause<uint>()
            .WithDecorator(options.Decorator)
            .WithSpecifier(options.Specifier)
            .WithLanguage(options.Language)
            .WithOperator(options.Operator)
            .WithValue(options.Value)
            .Build();

        Assert.That(clause.ToUriEncodedString(), Is.EqualTo(options.ExpectedValue));
    }

    [Test]
    public void ClauseGroup_AddClause_Success()
    {
        // Get the options
        StringClauseOptions options = TestSetup
            .Options
            .ClauseTests
            .ClauseGroupAddClauseTest;

        // Create a new empty clause group, then add a new clause after
        IClauseGroup clauseGroup = TestSetup.Service.NewClauseGroup().Build();
        IClause<string> clause = TestSetup.BuildClause(options, options.Value);
        clauseGroup.AddClause(clause);

        Assert.That(clauseGroup.ToUnencodedString(), Is.EqualTo(options.ExpectedValue));
    }

    [Test]
    public void ClauseGroup_AddClauses_Success()
    {
        // Get the options
        ClauseGroupOptions options = TestSetup
            .Options
            .ClauseTests
            .ClauseGroupAddClausesTest;

        // Create a new empty clause group, then add new clauses after
        IClauseGroup clauseGroup = TestSetup.Service.NewClauseGroup().Build();
        IEnumerable<IBaseClause> clauses =
        [
            (TestSetup.BuildClause(options.FirstClause, options.FirstClause.Value)),
            (TestSetup.BuildClause(options.SecondClause, options.SecondClause.Value)),
            (TestSetup.BuildClause(options.ThirdClause, options.ThirdClause.Value))
        ];
        clauseGroup.AddClauses(clauses);

        Assert.That(clauseGroup.ToUriEncodedString(), Is.EqualTo(options.ExpectedValue));
    }
}