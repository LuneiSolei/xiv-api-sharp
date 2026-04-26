using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using XivApiSharp.Tests.Options.Schemas.ClauseTests;

namespace XivApiSharp.Tests.Options.Schemas.XivApiServiceTests;

public class NewClauseTest : IBaseClauseOptions
{
    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public string Decorator { get; set; }

    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public string Specifier { get; set; }

    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public string Language { get; set; }

    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public string Operator { get; set; }

    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public string Value { get; set; }

    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public string ExpectedValue { get; set; }
}