namespace XivApiSharp.Tests.Options.ClauseConfigs.ClauseTestTypes;

public class IntClauseTestType : BaseClauseTestType<int>
{
    public required override int Value { get; set; }
}