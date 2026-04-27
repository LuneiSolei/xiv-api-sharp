using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace XivApiSharp.Tests.Options.Schemas.ClauseTests;

public class DoubleClauseOptions : BaseClauseOptions
{
    [Required, UsedImplicitly]
    public required double Value { get; set; }
}