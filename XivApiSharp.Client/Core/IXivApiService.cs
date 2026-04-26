using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Application;

public interface IXivApiService
{

    /// <summary>
    /// Creates a new instance of ClauseBuilder.
    /// </summary>
    /// <returns>
    /// The interface for ClauseBuilder.
    /// </returns>
    /// <seealso cref="IClauseBuilder"/>
    IClauseBuilder NewClause();
}