using XivApiSharp.Client.Application.Clauses;

namespace XivApiSharp.Client.Core.Clauses;

/// <inheritdoc />
internal sealed class Clause<T> : IClause where T : notnull
{
    /// <inheritdoc />
    public string? Specifier { get; set; }

    /// <inheritdoc />
    public string? Operator { get; set; }
    
    /// <summary>
    /// The value of clause to be compared./>
    /// </summary>
    public T? Value { get; set; }

    /// <inheritdoc cref="IClause.ToString" />
    public override string ToString()
    {
        // Convert boolean values to lowercase because .NET capitalizes them by default.
        string newValue = Value is bool b
            ? b.ToString().ToLowerInvariant()
            : Value?.ToString() ?? string.Empty;
            
        return $"{Specifier}{Operator}{newValue}";
    }
}