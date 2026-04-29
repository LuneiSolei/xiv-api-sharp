using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Microsoft.Extensions.Options;
using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Tests.Options.Schemas.ClauseTests;

[UsedImplicitly]
public class ClauseGroupOptions
{
    [Required, UsedImplicitly]
    public required ClauseDecorators Decorator { get; set; }

    [Required, ValidateObjectMembers, UsedImplicitly]
    public required StringClauseOptions FirstClause { get; set; }

    [Required, ValidateObjectMembers, UsedImplicitly]
    public required IntClauseOptions SecondClause { get; set; }

    [Required, ValidateObjectMembers, UsedImplicitly]
    public required DoubleClauseOptions ThirdClause { get; set; }

    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public required string ExpectedValue { get; set; }
}