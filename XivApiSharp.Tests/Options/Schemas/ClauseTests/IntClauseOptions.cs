using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace XivApiSharp.Tests.Options.Schemas.ClauseTests;

public class IntClauseOptions : BaseClauseOptions
{
    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public int Value { get; set; }
}