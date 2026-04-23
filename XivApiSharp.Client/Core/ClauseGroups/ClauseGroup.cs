using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Client.Core.Extensions;

namespace XivApiSharp.Client.Core.ClauseGroups;

/// <inheritdoc/>
internal sealed class ClauseGroup(IEnumerable<IClauseElement> clauses, 
    ClauseDecorators decorator) : IClauseGroup
{
    public string EncodedValue { get; set; }

    /// <inheritdoc cref="IClauseGroup.ToString"/>
    public override string ToString() => ToEncodedString();

    /// <inheritdoc/>
    public string ToEncodedString() =>
        $"{decorator}({string.Join(' ', clauses)})";

    /// <inheritdoc/>
    public string ToUnencodedString() =>
        throw new NotImplementedException();
}