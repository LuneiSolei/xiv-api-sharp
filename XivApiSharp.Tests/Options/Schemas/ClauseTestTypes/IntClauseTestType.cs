namespace XivApiSharp.Tests.Options.Schemas.ClauseTestTypes;

public class IntClauseTestType : BaseClauseTestType<int>
{
    public required override int Value { get; set; }
}