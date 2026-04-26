using XivApiSharp.Tests.Options.Schemas.ClauseTests;

namespace XivApiSharp.Tests.Options.Schemas.XivApiServiceTests;

public class NewClauseGroupTest
{
    public string Decorator { get; set; }
    public List<NewClauseTest> Clauses { get; set; }
}