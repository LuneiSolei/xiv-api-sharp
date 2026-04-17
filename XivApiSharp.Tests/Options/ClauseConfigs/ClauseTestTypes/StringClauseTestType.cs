namespace XivApiSharp.Tests.Options.ClauseConfigs.ClauseTestTypes;

public class StringClauseTestType : BaseClauseTestType<string>
{
    public required override string Value { get; set; } = null!;
}