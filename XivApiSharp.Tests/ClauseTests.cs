using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Client.Services;
using XivApiSharp.Client.Infrastructure.Requests.Clauses.Steps;
using XivApiSharp.Tests.Options;
using XivApiSharp.Tests.Options.ClauseConfigs.ClauseTestTypes;

namespace XivApiSharp.Tests;

[TestFixture]
public class ClauseTests
{
    private static IEnumerable<TestCaseData> StringClauseTestCases()
    {
        TestConfig config = ConfigSetup.TestConfig;
        
        // EqualTo
        yield return new TestCaseData(
                config.Clauses.EqualTo.StringTest,
                (Func<IOperatorStep, string, Clause<string>>)((step, value) => step.EqualTo(value)))
            .SetName("EqualTo (string)");
        
        // PartiallyEqualTo
        yield return new TestCaseData(
                config.Clauses.PartiallyEqualTo.StringTest,
                (Func<IOperatorStep, string, Clause<string>>)((step, value) => step.PartiallyEqualTo(value)))
            .SetName("PartiallyEqualTo (bool)");
    }
    
    private static IEnumerable<TestCaseData> BoolClauseTestCases()
    {
        TestConfig config = ConfigSetup.TestConfig;
        
        // EqualTo
        yield return new TestCaseData(
                config.Clauses.EqualTo.BoolTest,
                (Func<IOperatorStep, bool, Clause<bool>>)((step, value) => step.EqualTo(value)))
            .SetName("EqualTo (bool)");
    }

    private static IEnumerable<TestCaseData> IntClauseTestCases()
    {
        TestConfig config = ConfigSetup.TestConfig;
        
        // EqualTo
        yield return new TestCaseData(
                config.Clauses.EqualTo.IntTest, 
                (Func<IOperatorStep, int, Clause<int>>)((step, value) => step.EqualTo(value)))
            .SetName("EqualTo (int)");
        
        // GreaterThan
        yield return new TestCaseData(
                config.Clauses.GreaterThan.IntTest, 
                (Func<IOperatorStep, int, Clause<int>>)((step, value) => step.GreaterThan(value)))
            .SetName("GreaterThan (int)");
        
        // GreaterThanOrEqualTo
        yield return new TestCaseData(
                config.Clauses.GreaterThanOrEqualTo.IntTest, 
                (Func<IOperatorStep, int, Clause<int>>)((step, value) => step.GreaterThanOrEqualTo(value)))
            .SetName("GreaterThanOrEqualTo (int)");
        
        // LessThan
        yield return new TestCaseData(
                config.Clauses.LessThan.IntTest, 
                (Func<IOperatorStep, int, Clause<int>>)((step, value) => step.LessThan(value)))
            .SetName("LessThan (int)");
        
        // LessThanOrEqualTo
        yield return new TestCaseData(
                config.Clauses.LessThanOrEqualTo.IntTest, 
                (Func<IOperatorStep, int, Clause<int>>)((step, value) => step.LessThanOrEqualTo(value)))
            .SetName("LessThanOrEqualTo (int)");
    }

    private static IEnumerable<TestCaseData> DoubleClauseTestCases()
    {
        TestConfig config = ConfigSetup.TestConfig;
        
        // EqualTo
        yield return new TestCaseData(
                config.Clauses.EqualTo.DoubleTest,
                (Func<IOperatorStep, double, Clause<double>>)((step, value) => step.EqualTo(value)))
            .SetName("EqualTo (double)");
        
        // GreaterThan
        yield return new TestCaseData(
                config.Clauses.GreaterThan.DoubleTest, 
                (Func<IOperatorStep, double, Clause<double>>)((step, value) => step.GreaterThan(value)))
            .SetName("GreaterThan (double)");
        
        // GreaterThanOrEqualTo
        yield return new TestCaseData(
                config.Clauses.GreaterThanOrEqualTo.DoubleTest, 
                (Func<IOperatorStep, double, Clause<double>>)((step, value) => step.GreaterThanOrEqualTo(value)))
            .SetName("GreaterThanOrEqualTo (double)");
        
        // LessThan
        yield return new TestCaseData(
                config.Clauses.LessThan.DoubleTest, 
                (Func<IOperatorStep, double, Clause<double>>)((step, value) => step.LessThan(value)))
            .SetName("LessThan (double)");
        
        // LessThanOrEqualTo
        yield return new TestCaseData(
                config.Clauses.LessThanOrEqualTo.DoubleTest, 
                (Func<IOperatorStep, double, Clause<double>>)((step, value) => step.LessThanOrEqualTo(value)))
            .SetName("LessThanOrEqualTo (double)");
    }
    
    private static IEnumerable<TestCaseData> DecimalClauseTestCases()
    {
        TestConfig config = ConfigSetup.TestConfig;

        // EqualTo
        yield return new TestCaseData(
                config.Clauses.EqualTo.DecimalTest, 
                (Func<IOperatorStep, decimal, Clause<decimal>>)((step, value) => step.EqualTo(value)))
            .SetName("EqualTo (decimal)");
        
        // GreaterThan
        yield return new TestCaseData(
                config.Clauses.GreaterThan.DecimalTest, 
                (Func<IOperatorStep, decimal, Clause<decimal>>)((step, value) => step.GreaterThan(value)))
            .SetName("GreaterThan (decimal)");
        
        // GreaterThanOrEqualTo
        yield return new TestCaseData(
                config.Clauses.GreaterThanOrEqualTo.DecimalTest, 
                (Func<IOperatorStep, decimal, Clause<decimal>>)((step, value) => step.GreaterThanOrEqualTo(value)))
            .SetName("GreaterThanOrEqualTo (decimal)");
        
        // LessThan
        yield return new TestCaseData(
                config.Clauses.LessThan.DecimalTest, 
                (Func<IOperatorStep, decimal, Clause<decimal>>)((step, value) => step.LessThan(value)))
            .SetName("LessThan (int)");
        
        // LessThanOrEqualTo
        yield return new TestCaseData(
                config.Clauses.LessThanOrEqualTo.DecimalTest, 
                (Func<IOperatorStep, decimal, Clause<decimal>>)((step, value) => step.LessThanOrEqualTo(value)))
            .SetName("LessThanOrEqualTo (decimal)");
    }

    [TestCaseSource(nameof(StringClauseTestCases))]
    public void NewClause_BuildsStringCorrectly(
        StringClauseTestType opts,
        Func<IOperatorStep, string, Clause<string>> buildClause)
    {
        Clause<string> clause = buildClause(
            XivApiService.NewClause()
                .WhereSpecifier(opts.Specifier)
                .Is, 
            opts.Value);
        
        Assert.That(clause.ToString(), 
            Is.EqualTo(opts.ExpectedValue));
    }

    [TestCaseSource(nameof(BoolClauseTestCases))]
    public void NewClause_BuildsBoolCorrectly(
        BoolClauseTestType opts,
        Func<IOperatorStep, bool, Clause<bool>> buildClause)
    {
        Clause<bool> clause = buildClause(
            XivApiService.NewClause()
                .WhereSpecifier(opts.Specifier)
                .Is, opts.Value);
        
        Assert.That(clause.ToString(),
            Is.EqualTo(opts.ExpectedValue));
    }

    [TestCaseSource(nameof(IntClauseTestCases))]
    public void NewClause_BuildsNumberCorrectly(
        IntClauseTestType opts,
        Func<IOperatorStep, int, Clause<int>> buildClause)
    {
        Clause<int> clause = buildClause(
            XivApiService.NewClause()
                .WhereSpecifier(opts.Specifier)
                .Is, opts.Value);
        
        Assert.That(clause.ToString(),
            Is.EqualTo(opts.ExpectedValue));
    }

    [TestCaseSource(nameof(DoubleClauseTestCases))]
    public void NewClause_BuildsDoubleCorrectly(
        DoubleClauseTestType opts,
        Func<IOperatorStep, double, Clause<double>> buildClause)
    {
        Clause<double> clause = buildClause(
            XivApiService.NewClause()
                .WhereSpecifier(opts.Specifier)
                .Is, opts.Value);
        
        Assert.That(clause.ToString(),
            Is.EqualTo(opts.ExpectedValue));
    }    
    
    [TestCaseSource(nameof(DecimalClauseTestCases))]
    public void NewClause_BuildsDecimalCorrectly(
        DecimalClauseTestType opts,
        Func<IOperatorStep, decimal, Clause<decimal>> buildClause)
    {
        Clause<decimal> clause = buildClause(
            XivApiService.NewClause()
                .WhereSpecifier(opts.Specifier)
                .Is, opts.Value);
        
        Assert.That(clause.ToString(),
            Is.EqualTo(opts.ExpectedValue));
    }
    
    
}