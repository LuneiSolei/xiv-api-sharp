using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Tests.Options.Schemas.ClauseTests;

public class BaseClauseOptions
{
    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public required ClauseDecorators Decorator { get; set; }

    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public required string Specifier { get; set; }

    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public required SchemaLanguage Language { get; set; }

    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public required ClauseOperators Operator { get; set; }

    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public required string ExpectedValue { get; set; }
}