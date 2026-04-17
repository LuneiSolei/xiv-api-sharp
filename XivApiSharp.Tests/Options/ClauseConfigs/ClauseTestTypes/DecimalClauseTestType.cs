namespace XivApiSharp.Tests.Options.ClauseConfigs.ClauseTestTypes;

public class DecimalClauseTestType : BaseClauseTestType<decimal>
{
    public required override decimal Value { get; set; }
}