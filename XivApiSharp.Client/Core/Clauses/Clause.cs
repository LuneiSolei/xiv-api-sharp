namespace XivApiSharp.Client.Core.Clauses;

/// <inheritdoc />
public class Clause<T> : IClause where T : notnull
{
    /// <inheritdoc />
    public string? Specifier { get; set; }

    /// <inheritdoc />
    public string? Operator { get; set; }
    
    /// <summary>
    /// See: <see cref="IClause.Value"/>
    /// </summary>
    public T? Value { get; set; }

    /// <inheritdoc />
    object? IClause.Value
    {
        get => Value;
        set => Value = (T?)value;
    }

    /// <inheritdoc cref="IClause.ToString" />
    public override string ToString()
    {
        return $"{Specifier}{Operator}{Value}";
    }
}