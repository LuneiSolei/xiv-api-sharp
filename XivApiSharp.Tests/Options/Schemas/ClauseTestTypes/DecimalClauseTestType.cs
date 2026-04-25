namespace XivApiSharp.Tests.Options.Schemas.ClauseTestTypes;

public class DecimalClauseTestType : BaseClauseTestType<decimal>
{
    public required override decimal Value { get; set; }
}