using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Tests.Options;
using XivApiSharp.Tests.Options.ClauseConfigs.ClauseTestTypes;

namespace XivApiSharp.Tests;

[TestFixture]
public class ClauseTests
{
    private static IEnumerable<TestCaseData> StringClauseTestCases()
    {
        TestingOptions options = TestingSetup.TestingOptions;

        // EqualTo
        yield return new TestCaseData(
                options.Clauses.EqualTo.StringTest,
                (Func<IOperatorStep, string, IClause>)((step, value) =>
                    step.Equal(value)))
            .SetName("Equal (string)");

        // PartiallyEqualTo
        StringClauseTestType data = options.Clauses.PartiallyEqualTo.StringTest;
        Func<IOperatorStep, string, IClause> testFunc = (step, value) =>
            step.PartiallyEqual(value);
        
        yield return new TestCaseData(data, testFunc)
            .SetName("Partially Equal (bool)");
    }

    private static IEnumerable<TestCaseData> BoolClauseTestCases()
    {
        TestingOptions options = TestingSetup.TestingOptions;

        // EqualTo
        yield return new TestCaseData(
                options.Clauses.EqualTo.BoolTest,
                (Func<IOperatorStep, bool, IClause>)((step, value) =>
                    step.Equal(value)))
            .SetName("Equal (bool)");
    }

    private static IEnumerable<TestCaseData> IntClauseTestCases()
    {
        TestingOptions options = TestingSetup.TestingOptions;

        // EqualTo
        yield return new TestCaseData(
                options.Clauses.EqualTo.IntTest,
                (Func<IOperatorStep, int, IClause>)((step, value) =>
                    step.Equal(value)))
            .SetName("Equal (int)");

        // GreaterThan
        yield return new TestCaseData(
                options.Clauses.GreaterThan.IntTest,
                (Func<IOperatorStep, int, IClause>)((step, value) =>
                    step.GreaterThan(value)))
            .SetName("Greater Than (int)");

        // GreaterThanOrEqualTo
        yield return new TestCaseData(
                options.Clauses.GreaterThanOrEqualTo.IntTest,
                (Func<IOperatorStep, int, IClause>)((step, value) =>
                    step.GreaterThanOrEqual(value)))
            .SetName("Greater Than or Equal (int)");

        // LessThan
        yield return new TestCaseData(
                options.Clauses.LessThan.IntTest,
                (Func<IOperatorStep, int, IClause>)((step, value) =>
                    step.LessThan(value)))
            .SetName("Less Than (int)");

        // LessThanOrEqualTo
        yield return new TestCaseData(
                options.Clauses.LessThanOrEqualTo.IntTest,
                (Func<IOperatorStep, int, IClause>)((step, value) =>
                    step.LessThanOrEqual(value)))
            .SetName("Less 0Than or Equal (int)");
    }

    private static IEnumerable<TestCaseData> DoubleClauseTestCases()
    {
        TestingOptions options = TestingSetup.TestingOptions;

        // EqualTo
        yield return new TestCaseData(
                options.Clauses.EqualTo.DoubleTest,
                (Func<IOperatorStep, double, IClause>)((step, value) =>
                    step.Equal(value)))
            .SetName("EqualTo (double)");

        // GreaterThan
        yield return new TestCaseData(
                options.Clauses.GreaterThan.DoubleTest,
                (Func<IOperatorStep, double, IClause>)((step, value) =>
                    step.GreaterThan(value)))
            .SetName("GreaterThan (double)");

        // GreaterThanOrEqualTo
        yield return new TestCaseData(
                options.Clauses.GreaterThanOrEqualTo.DoubleTest,
                (Func<IOperatorStep, double, IClause>)((step, value) =>
                    step.GreaterThanOrEqual(value)))
            .SetName("GreaterThanOrEqualTo (double)");

        // LessThan
        yield return new TestCaseData(
                options.Clauses.LessThan.DoubleTest,
                (Func<IOperatorStep, double, IClause>)((step, value) =>
                    step.LessThan(value)))
            .SetName("LessThan (double)");

        // LessThanOrEqualTo
        yield return new TestCaseData(
                options.Clauses.LessThanOrEqualTo.DoubleTest,
                (Func<IOperatorStep, double, IClause>)((step, value) =>
                    step.LessThanOrEqual(value)))
            .SetName("LessThanOrEqualTo (double)");
    }

    private static IEnumerable<TestCaseData> DecimalClauseTestCases()
    {
        TestingOptions options = TestingSetup.TestingOptions;

        // EqualTo
        yield return new TestCaseData(
                options.Clauses.EqualTo.DecimalTest,
                (Func<IOperatorStep, decimal, IClause>)((step, value) =>
                    step.Equal(value)))
            .SetName("EqualTo (decimal)");

        // GreaterThan
        yield return new TestCaseData(
                options.Clauses.GreaterThan.DecimalTest,
                (Func<IOperatorStep, decimal, IClause>)((step, value) =>
                    step.GreaterThan(value)))
            .SetName("GreaterThan (decimal)");

        // GreaterThanOrEqualTo
        yield return new TestCaseData(
                options.Clauses.GreaterThanOrEqualTo.DecimalTest,
                (Func<IOperatorStep, decimal, IClause>)((step, value) =>
                    step.GreaterThanOrEqual(value)))
            .SetName("GreaterThanOrEqualTo (decimal)");

        // LessThan
        yield return new TestCaseData(
                options.Clauses.LessThan.DecimalTest,
                (Func<IOperatorStep, decimal, IClause>)((step, value) =>
                    step.LessThan(value)))
            .SetName("LessThan (int)");

        // LessThanOrEqualTo
        yield return new TestCaseData(
                options.Clauses.LessThanOrEqualTo.DecimalTest,
                (Func<IOperatorStep, decimal, IClause>)((step, value) =>
                    step.LessThanOrEqual(value)))
            .SetName("LessThanOrEqualTo (decimal)");
    }

    [TestCaseSource(nameof(StringClauseTestCases))]
    public void NewClause_BuildsStringCorrectly(
        StringClauseTestType opts,
        Func<IOperatorStep, string, IClause> buildClause)
    {
        IClauseBuilder builder = TestingSetup.ApiService.NewClause();

        IClause clause = buildClause(builder.WhereSpecifier(opts.Specifier)
            .Must, opts.Value);

        Assert.That(clause.ToString(),
            Is.EqualTo(opts.ExpectedValue));
    }

    [TestCaseSource(nameof(BoolClauseTestCases))]
    public void NewClause_BuildsMustBoolCorrectly(
        BoolClauseTestType opts,
        Func<IOperatorStep, bool, IClause> buildClause)
    {
        IClauseBuilder builder = TestingSetup.ApiService.NewClause();

        IClause clause = buildClause(builder.WhereSpecifier(opts.Specifier)
            .Must, opts.Value);

        Assert.That(clause.ToString(),
            Is.EqualTo(opts.ExpectedValue));
    }

    [TestCaseSource(nameof(IntClauseTestCases))]
    public void NewClause_BuildsMustNumberCorrectly(
        IntClauseTestType opts,
        Func<IOperatorStep, int, IClause> buildClause)
    {
        IClauseBuilder builder = TestingSetup.ApiService.NewClause();

        IClause clause = buildClause(builder.WhereSpecifier(opts.Specifier)
            .Must, opts.Value);

        Assert.That(clause.ToString(),
            Is.EqualTo(opts.ExpectedValue));
    }

    [TestCaseSource(nameof(DoubleClauseTestCases))]
    public void NewClause_BuildsMustDoubleCorrectly(
        DoubleClauseTestType opts,
        Func<IOperatorStep, double, IClause> buildClause)
    {
        IClauseBuilder builder = TestingSetup.ApiService.NewClause();

        IClause clause = buildClause(builder.WhereSpecifier(opts.Specifier)
            .Must, opts.Value);

        Assert.That(clause.ToString(),
            Is.EqualTo(opts.ExpectedValue));
    }

    [TestCaseSource(nameof(DecimalClauseTestCases))]
    public void NewClause_BuildsMustDecimalCorrectly(
        DecimalClauseTestType opts,
        Func<IOperatorStep, decimal, IClause> buildClause)
    {
        IClauseBuilder builder = TestingSetup.ApiService.NewClause();

        IClause clause = buildClause(builder.WhereSpecifier(opts.Specifier)
            .Must, opts.Value);

        Assert.That(clause.ToString(),
            Is.EqualTo(opts.ExpectedValue));
    }


}