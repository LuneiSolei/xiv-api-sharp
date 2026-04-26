using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace XivApiSharp.Tests.Options.Schemas.ClauseTests;

public interface IBaseClauseOptions
{
    [Required(AllowEmptyStrings = false), UsedImplicitly]
    string Decorator { get; set; }

    [Required(AllowEmptyStrings = false), UsedImplicitly]
    string Specifier { get; set; }

    [Required(AllowEmptyStrings = false), UsedImplicitly]
    string Language { get; set; }

    [Required(AllowEmptyStrings = false), UsedImplicitly]
    string Operator { get; set; }

    [Required(AllowEmptyStrings = false), UsedImplicitly]
    string Value { get; set; }

    [Required(AllowEmptyStrings = false), UsedImplicitly]
    string ExpectedValue { get; set; }
}