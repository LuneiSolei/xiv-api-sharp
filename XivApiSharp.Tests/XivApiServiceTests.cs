using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.ClauseGroups;
using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Tests.Options.Schemas.ClauseTests;
using XivApiSharp.Tests.Options.Schemas.XivApiServiceTests;

namespace XivApiSharp.Tests;

[TestFixture]
public class XivApiServiceTests
{
    [Test]
    public void XivApiService_NewClause_Success()
    {
        NewClauseTest options = TestSetup.Options.XivApiServiceTests.NewClauseTest;

        // Parse language from string to type
        if (!Enum.TryParse(options.Language, out SchemaLanguage language))
            Assert.Fail("The provided option 'Language' is not valid.");

        // Parse value from string to type
        if (!int.TryParse(options.Value, out int parsedValue))
            Assert.Fail("The provided option 'Value' is not valid.");

        IClause<int> clause = TestSetup.Service.NewClause<int>()
            .WhereSpecifier(options.Specifier)
            .WithLanguage(language)
            .Must
            .Equal(parsedValue);

        Assert.That(clause.ToUriEncodedString(), Is.EqualTo(options.ExpectedValue));
    }

    [Test]
    public void XivApiService_NewClauseGroup_Success()
    {
        NewClauseGroupTest options = TestSetup.Options.XivApiServiceTests.NewClauseGroupTest;

        // Convert clause options into actual clauses
        List<IBaseClause> clauses = [];

        // Parse and add first clause options
        (ClauseDecorators firstDecorator,
            SchemaLanguage firstLanguage,
            ClauseOperators firstOperator) = ParseClauseOptions(options.FirstClause);

        clauses.Add(TestSetup.Service.NewClause<string>()
            .WithDecorator(firstDecorator)
            .WithSpecifier(options.FirstClause.Specifier)
            .WithLanguage(firstLanguage)
            .WithOperator(firstOperator)
            .WithValue(options.FirstClause.Value)
            .Build());

        // Parse and add second clause options
        (ClauseDecorators secondDecorator,
            SchemaLanguage secondLanguage,
            ClauseOperators secondOperator) = ParseClauseOptions(options.SecondClause);

        clauses.Add(TestSetup.Service.NewClause<int>()
            .WithDecorator(secondDecorator)
            .WithSpecifier(options.SecondClause.Specifier)
            .WithLanguage(secondLanguage)
            .WithOperator(secondOperator)
            .WithValue(options.SecondClause.Value)
            .Build());

        // Parse and add third clause options
        (ClauseDecorators thirdDecorator,
            SchemaLanguage thirdLanguage,
            ClauseOperators thirdOperator) = ParseClauseOptions(options.ThirdClause);

        clauses.Add(TestSetup.Service.NewClause<double>()
            .WithDecorator(thirdDecorator)
            .WithSpecifier(options.ThirdClause.Specifier)
            .WithLanguage(thirdLanguage)
            .WithOperator(thirdOperator)
            .WithValue(options.ThirdClause.Value)
            .Build());

        IClauseGroup clauseGroup = TestSetup.Service.NewClauseGroup()
            .WithClauses(clauses)
            .MustNotMatch
            .Build();

        Assert.That(clauseGroup.ToUriEncodedString(), Is.EqualTo(options.ExpectedValue));
    }

    private static (ClauseDecorators, SchemaLanguage, ClauseOperators)
        ParseClauseOptions<TClauseOptions>(TClauseOptions clauseOptions) where TClauseOptions : BaseClauseOptions
    {
        // Convert decorator option from string to type
        if (!Enum.TryParse(clauseOptions.Decorator, out ClauseDecorators decorator))
            Assert.Fail("The provided option 'Decorator' is not valid.");

        // Convert language option from string to type
        if (!Enum.TryParse(clauseOptions.Language, out SchemaLanguage language))
            Assert.Fail("The provided option 'Language' is not valid.");

        // Convert operator option from string to type
        if (!Enum.TryParse(clauseOptions.Operator, out ClauseOperators @operator))
            Assert.Fail("The provided option 'Operator' is not valid.");

        return (decorator, language, @operator);
    }
}