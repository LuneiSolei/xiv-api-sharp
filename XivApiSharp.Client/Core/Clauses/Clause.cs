namespace XivApiSharp.Client.Core.Clauses;

/// <inheritdoc />
internal class Clause<T> : IClause where T : notnull
{
    /// <inheritdoc />
    public string? Specifier { get; set; }

    /// <inheritdoc />
    public string? Operator { get; set; }
    
    /// <summary>
    /// See: <see cref="IClause.Value"/>
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