using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace XivApiSharp.Tests.Options.Schemas.ClauseTests;

public class UIntClauseOptions : BaseClauseOptions
{
    [Required, UsedImplicitly]
    public required uint Value { get; set; }
}