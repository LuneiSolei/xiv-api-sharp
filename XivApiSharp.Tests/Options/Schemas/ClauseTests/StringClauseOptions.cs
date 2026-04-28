using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace XivApiSharp.Tests.Options.Schemas.ClauseTests;

public class StringClauseOptions : BaseClauseOptions
{
    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public required string Value { get; set; }
}