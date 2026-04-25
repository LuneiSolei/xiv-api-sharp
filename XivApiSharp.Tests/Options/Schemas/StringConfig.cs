using System.ComponentModel.DataAnnotations;
using XivApiSharp.Tests.Options.Schemas.ClauseTestTypes;

namespace XivApiSharp.Tests.Options.Schemas;

public class StringConfig
{
    [Required(AllowEmptyStrings = false)]
    public StringClauseTestType StringTest { get; set; } = null!;
}