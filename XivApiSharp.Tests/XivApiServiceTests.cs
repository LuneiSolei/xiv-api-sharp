using System.Diagnostics;
using Microsoft.VisualBasic.CompilerServices;
using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.ClauseGroups;
using XivApiSharp.Client.Core.Clauses;
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

        IClause<int> clause = TestSetup.Service.NewClause()
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
        options.Clauses.ForEach(clauseOptions =>
        {
            // Convert language option from string to type
            if (!Enum.TryParse(clauseOptions.Language, out SchemaLanguage parsedLanguage))
                Assert.Fail("The provided option 'Language' is not valid.");

            // Convert decorator option from string to type
            if (!Enum.TryParse(clauseOptions.Decorator, out ClauseDecorators parsedDecorator))
                Assert.Fail("The provided option 'Decorator' is not valid.");

            // Convert operator option from string to type
            if (!Enum.TryParse(clauseOptions.Operator, out ClauseOperators parsedOperator))
                Assert.Fail("The provided option 'Operator' is not valid.");

            switch (parsedDecorator)
            {
                case ClauseDecorators.None:
                    clauses.Add(TestSetup.Service.NewClause()
                        .WithSpecifier(clauseOptions.Specifier)
                        .WithLanguage(parsedLanguage)
                        .WithOperator(parsedOperator)
                        .WithValue(clauseOptions.Value));
                    break;
                case ClauseDecorators.Must:
                case ClauseDecorators.MustNot:
                    clauses.Add(TestSetup.Service.NewClause()
                        .WithDecorator(parsedDecorator)
                        .WithSpecifier(clauseOptions.Specifier)
                        .WithLanguage(parsedLanguage)
                        .WithOperator(parsedOperator)
                        .WithValue(clauseOptions.Value));
                    break;
            }
        });

        IClauseGroup clauseGroup = TestSetup.Service.NewClauseGroup()
            .WithClauses(clauses)
            .MustNotMatch
            .Build();
    }
}