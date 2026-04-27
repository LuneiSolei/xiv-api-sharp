using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Microsoft.Extensions.Options;
using XivApiSharp.Tests.Options.Schemas.ClauseTests;

namespace XivApiSharp.Tests.Options.Schemas.XivApiServiceTests;

[UsedImplicitly]
public class NewClauseGroupTest
{
    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public required string Decorator { get; set; }

    [Required, ValidateObjectMembers, UsedImplicitly]
    public required StringClauseOptions FirstClause { get; set; }

    [Required, ValidateObjectMembers, UsedImplicitly]
    public required IntClauseOptions SecondClause { get; set; }

    [Required, ValidateObjectMembers, UsedImplicitly]
    public required DoubleClauseOptions ThirdClause { get; set; }

    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public required string ExpectedValue { get; set; }
}