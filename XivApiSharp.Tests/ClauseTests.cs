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
                (Func<IWithDecorator, string, IClause>)((step, value) =>
                    step.Equal(value)))
            .SetName("EqualTo (string)");

        // PartiallyEqualTo
        yield return new TestCaseData(
                options.Clauses.PartiallyEqualTo.StringTest,
                (Func<IWithDecorator, string, IClause>)((step, value) =>
                    step.PartiallyEqual(value)))
            .SetName("PartiallyEqualTo (bool)");
    }

    private static IEnumerable<TestCaseData> BoolClauseTestCases()
    {
        TestingOptions options = TestingSetup.TestingOptions;

        // EqualTo
        yield return new TestCaseData(
                options.Clauses.EqualTo.BoolTest,
                (Func<IWithDecorator, bool, IClause>)((step, value) =>
                    step.Equal(value)))
            .SetName("EqualTo (bool)");
    }

    private static IEnumerable<TestCaseData> IntClauseTestCases()
    {
        TestingOptions options = TestingSetup.TestingOptions;

        // EqualTo
        yield return new TestCaseData(
                options.Clauses.EqualTo.IntTest,
                (Func<IWithDecorator, int, IClause>)((step, value) =>
                    step.Equal(value)))
            .SetName("EqualTo (int)");

        // GreaterThan
        yield return new TestCaseData(
                options.Clauses.GreaterThan.IntTest,
                (Func<IWithDecorator, int, IClause>)((step, value) =>
                    step.GreaterThan(value)))
            .SetName("GreaterThan (int)");

        // GreaterThanOrEqualTo
        yield return new TestCaseData(
                options.Clauses.GreaterThanOrEqualTo.IntTest,
                (Func<IWithDecorator, int, IClause>)((step, value) =>
                    step.GreaterThanOrEqual(value)))
            .SetName("GreaterThanOrEqualTo (int)");

        // LessThan
        yield return new TestCaseData(
                options.Clauses.LessThan.IntTest,
                (Func<IWithDecorator, int, IClause>)((step, value) =>
                    step.LessThan(value)))
            .SetName("LessThan (int)");

        // LessThanOrEqualTo
        yield return new TestCaseData(
                options.Clauses.LessThanOrEqualTo.IntTest,
                (Func<IWithDecorator, int, IClause>)((step, value) =>
                    step.LessThanOrEqual(value)))
            .SetName("LessThanOrEqualTo (int)");
    }

    private static IEnumerable<TestCaseData> DoubleClauseTestCases()
    {
        TestingOptions options = TestingSetup.TestingOptions;

        // EqualTo
        yield return new TestCaseData(
                options.Clauses.EqualTo.DoubleTest,
                (Func<IWithDecorator, double, IClause>)((step, value) =>
                    step.Equal(value)))
            .SetName("EqualTo (double)");

        // GreaterThan
        yield return new TestCaseData(
                options.Clauses.GreaterThan.DoubleTest,
                (Func<IWithDecorator, double, IClause>)((step, value) =>
                    step.GreaterThan(value)))
            .SetName("GreaterThan (double)");

        // GreaterThanOrEqualTo
        yield return new TestCaseData(
                options.Clauses.GreaterThanOrEqualTo.DoubleTest,
                (Func<IWithDecorator, double, IClause>)((step, value) =>
                    step.GreaterThanOrEqual(value)))
            .SetName("GreaterThanOrEqualTo (double)");

        // LessThan
        yield return new TestCaseData(
                options.Clauses.LessThan.DoubleTest,
                (Func<IWithDecorator, double, IClause>)((step, value) =>
                    step.LessThan(value)))
            .SetName("LessThan (double)");

        // LessThanOrEqualTo
        yield return new TestCaseData(
                options.Clauses.LessThanOrEqualTo.DoubleTest,
                (Func<IWithDecorator, double, IClause>)((step, value) =>
                    step.LessThanOrEqual(value)))
            .SetName("LessThanOrEqualTo (double)");
    }

    private static IEnumerable<TestCaseData> DecimalClauseTestCases()
    {
        TestingOptions options = TestingSetup.TestingOptions;

        // EqualTo
        yield return new TestCaseData(
                options.Clauses.EqualTo.DecimalTest,
                (Func<IWithDecorator, decimal, IClause>)((step, value) =>
                    step.Equal(value)))
            .SetName("EqualTo (decimal)");

        // GreaterThan
        yield return new TestCaseData(
                options.Clauses.GreaterThan.DecimalTest,
                (Func<IWithDecorator, decimal, IClause>)((step, value) =>
                    step.GreaterThan(value)))
            .SetName("GreaterThan (decimal)");

        // GreaterThanOrEqualTo
        yield return new TestCaseData(
                options.Clauses.GreaterThanOrEqualTo.DecimalTest,
                (Func<IWithDecorator, decimal, IClause>)((step, value) =>
                    step.GreaterThanOrEqual(value)))
            .SetName("GreaterThanOrEqualTo (decimal)");

        // LessThan
        yield return new TestCaseData(
                options.Clauses.LessThan.DecimalTest,
                (Func<IWithDecorator, decimal, IClause>)((step, value) =>
                    step.LessThan(value)))
            .SetName("LessThan (int)");

        // LessThanOrEqualTo
        yield return new TestCaseData(
                options.Clauses.LessThanOrEqualTo.DecimalTest,
                (Func<IWithDecorator, decimal, IClause>)((step, value) =>
                    step.LessThanOrEqual(value)))
            .SetName("LessThanOrEqualTo (decimal)");
    }

    [TestCaseSource(nameof(StringClauseTestCases))]
    public void NewClause_BuildsStringCorrectly(
        StringClauseTestType opts,
        Func<IWithDecorator, string, IClause> buildClause)
    {
        IClauseBuilder builder = TestingSetup.ApiService.NewClause();

        IClause clause = buildClause(builder.WhereSpecifier(opts.Specifier)
            .Must, opts.Value);

        Assert.That(clause.ToString(),
            Is.EqualTo(opts.ExpectedValue));
    }

    [TestCaseSource(nameof(BoolClauseTestCases))]
    public void NewClause_BuildsBoolCorrectly(
        BoolClauseTestType opts,
        Func<IWithDecorator, bool, IClause> buildClause)
    {
        IClauseBuilder builder = TestingSetup.ApiService.NewClause();

        IClause clause = buildClause(builder.WhereSpecifier(opts.Specifier)
            .Must, opts.Value);

        Assert.That(clause.ToString(),
            Is.EqualTo(opts.ExpectedValue));
    }

    [TestCaseSource(nameof(IntClauseTestCases))]
    public void NewClause_BuildsNumberCorrectly(
        IntClauseTestType opts,
        Func<IWithDecorator, int, IClause> buildClause)
    {
        IClauseBuilder builder = TestingSetup.ApiService.NewClause();

        IClause clause = buildClause(builder.WhereSpecifier(opts.Specifier)
            .Must, opts.Value);

        Assert.That(clause.ToString(),
            Is.EqualTo(opts.ExpectedValue));
    }

    [TestCaseSource(nameof(DoubleClauseTestCases))]
    public void NewClause_BuildsDoubleCorrectly(
        DoubleClauseTestType opts,
        Func<IWithDecorator, double, IClause> buildClause)
    {
        IClauseBuilder builder = TestingSetup.ApiService.NewClause();

        IClause clause = buildClause(builder.WhereSpecifier(opts.Specifier)
            .Must, opts.Value);

        Assert.That(clause.ToString(),
            Is.EqualTo(opts.ExpectedValue));
    }

    [TestCaseSource(nameof(DecimalClauseTestCases))]
    public void NewClause_BuildsDecimalCorrectly(
        DecimalClauseTestType opts,
        Func<IWithDecorator, decimal, IClause> buildClause)
    {
        IClauseBuilder builder = TestingSetup.ApiService.NewClause();

        IClause clause = buildClause(builder.WhereSpecifier(opts.Specifier)
            .Must, opts.Value);

        Assert.That(clause.ToString(),
            Is.EqualTo(opts.ExpectedValue));
    }


}