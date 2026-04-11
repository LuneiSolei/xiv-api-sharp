using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace XivApiSharp.Client.Core.Options;

public class XivApiOptions
{
    [Required, ValidateObjectMembers]
    public required string BaseUrl { get; set; }
    
    [Required, ValidateObjectMembers]
    public required string Scheme { get; set; }
    
    [Required, ValidateObjectMembers]
    public required Endpoints Endpoints { get; set; }
}