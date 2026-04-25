namespace XivApiSharp.Tests.Options.Schemas.ClauseTestTypes;

public class DoubleClauseTestType : BaseClauseTestType<double>
{
    public required override double Value { get; set; }
}