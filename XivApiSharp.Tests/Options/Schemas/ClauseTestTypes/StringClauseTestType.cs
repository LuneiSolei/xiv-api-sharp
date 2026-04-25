namespace XivApiSharp.Tests.Options.Schemas.ClauseTestTypes;

public class StringClauseTestType : BaseClauseTestType<string>
{
    public required override string Value { get; set; } = null!;
}