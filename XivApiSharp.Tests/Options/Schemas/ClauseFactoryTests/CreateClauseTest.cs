using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace XivApiSharp.Tests.Options.Schemas.ClauseFactoryTests;


[UsedImplicitly]
public class CreateClauseTest
{
    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public required string Decorator { get; set; }

    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public required string Specifier { get; set; }

    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public required string Language { get; set; }

    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public required string Operator { get; set; }

    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public required string Value { get; set; }
    
    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public required string ExpectedValue { get; set; }
}