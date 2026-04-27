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
        IClause<string> clause = TestSetup.SetUpClause(options, options.Value);
        Assert.That(clause.ToUnencodedString(),
            Is.EqualTo(options.ExpectedValue));
    }

    [Test]
    public void Clause_ToUriEncodedString_Succeeds()
    {
        StringClauseOptions options = TestSetup
            .Options
            .ClauseTests
            .ToUriEncodedStringTest;

        if (!uint.TryParse(options.Value, out uint parsedValue))
            Assert.Fail("The provided option 'Value' is not a 'uint'.");

        IClause<uint> clause = TestSetup.SetUpClause(options, parsedValue);
        Assert.That(clause.ToUriEncodedString(), Is.EqualTo(options.ExpectedValue));
    }
}