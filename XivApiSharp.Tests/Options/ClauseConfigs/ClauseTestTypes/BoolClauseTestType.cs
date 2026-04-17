namespace XivApiSharp.Tests.Options.ClauseConfigs.ClauseTestTypes;

public class BoolClauseTestType : BaseClauseTestType<bool>
{
    public required override bool Value { get; set; }
}