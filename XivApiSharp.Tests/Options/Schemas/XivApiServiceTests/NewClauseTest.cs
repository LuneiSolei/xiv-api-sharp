using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using XivApiSharp.Tests.Options.Schemas.ClauseTests;

namespace XivApiSharp.Tests.Options.Schemas.XivApiServiceTests;

public class NewClauseTest : BaseClauseOptions
{
    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public required string Value { get; set; }

}