using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace XivApiSharp.Tests.Options.Schemas.ClauseTests;

public class StringClauseOptions : BaseClauseOptions
{
    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public string Value { get; set; }
}