using System.ComponentModel.DataAnnotations;

namespace XivApiSharp.Client.Core.Options;

public class Endpoints
{
    [Required]
    public required string Search { get; set; }
}