using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace XivApiSharp.Client.Core.Options;

/// <summary>
/// Configuration for XivApiService.
/// </summary>
/// <remarks>
/// All options are required and validated at startup.
/// </remarks>
internal sealed class XivApiOptions
{
    /// <summary>
    /// Represents the base url for the XIV API.
    /// </summary>
    [Required(AllowEmptyStrings = false), ValidateObjectMembers]
    public required string BaseUrl { get; set; }
    
    /// <summary>
    /// Represents the URI scheme to use for requests.
    /// </summary>
    [Required(AllowEmptyStrings = false), ValidateObjectMembers]
    public required string Scheme { get; set; }
    
    /// <inheritdoc cref="XivApiSharp.Client.Core.Options.Endpoints"/>
    [Required(AllowEmptyStrings = false), ValidateObjectMembers]
    public required Endpoints Endpoints { get; set; }
}