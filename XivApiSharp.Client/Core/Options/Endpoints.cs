using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace XivApiSharp.Client.Core.Options;

/// <summary>
/// Represents XivApiService options for the XIV API endpoints.
/// </summary>
/// <remarks>
/// This is populated from the "XivApiService:Endpoints" section of the
/// XivApiService configuration. All endpoints are required and validated at
/// startup.
/// </remarks>
[UsedImplicitly]
internal sealed class Endpoints
{
    /// <summary>
    /// Represents the endpoint for the search sheet API.
    /// </summary>
    [Required(AllowEmptyStrings = false)]
    public required string Search { get; set; }
}