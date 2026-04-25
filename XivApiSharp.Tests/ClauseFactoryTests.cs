using Microsoft.Extensions.DependencyInjection;
using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Tests.Options.Schemas.ClauseFactoryTests;
using static System.Enum;

namespace XivApiSharp.Tests;

[TestFixture]
public class ClauseFactoryTests
{
    [Test]
    public void CreateClauseTest()
    {
        CreateClauseTest options = TestSetup
            .Options
            .ClauseFactoryTests
            .CreateClauseTest;
        
        IClauseFactory factory = TestSetup.ServiceContainer
            .GetRequiredService<IClauseFactory>();
        
        // Convert decorator option from string to type
        bool isDecorator = TryParse(options.Decorator, 
            out ClauseDecorators decorator);

        if (!isDecorator)
            Assert.Fail("The provided option 'Decorator' is not valid.");
        
        // Convert language option from string to type
        bool isSchemaLanguage = TryParse(options.Language,
            out SchemaLanguage language);
        
        if (!isSchemaLanguage)
            Assert.Fail(message: "The provided option 'Language' is not valid.");
        
        // Convert operator option from string to type
        bool isOperator = TryParse(
            value: options.Operator, 
            ignoreCase: true, 
            result: out ClauseOperators op);
        
        if (!isOperator)
            Assert.Fail("The provided option 'Operator' is not valid.");

        IClause<string> clause = factory.CreateClause(
            decorator: decorator,
            specifier: options.Specifier,
            language: language,
            op: op,
            value: options.Value);
        
        Assert.That(clause.ToUnencodedString(), 
            Is.EqualTo(options.ExpectedValue));
    }
}