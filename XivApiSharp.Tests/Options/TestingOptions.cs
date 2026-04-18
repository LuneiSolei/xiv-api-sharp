using System.ComponentModel.DataAnnotations;

namespace XivApiSharp.Tests.Options;

public class TestingOptions
{
    [Required] 
    public ClauseOptions Clauses { get; set; } = null!;
}