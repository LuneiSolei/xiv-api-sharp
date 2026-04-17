using XivApiSharp.Client.Application.Clauses;
using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Extensions;
using XivApiSharp.Client.Core.Options;
using XivApiSharp.Client.Core.Requests;

namespace XivApiSharp.Client.Infrastructure.Requests;

public sealed class SearchSheetRequest : XivApiRequest, ISearchSheetRequest
{
    private List<string>? _sheets;
    private QueryString? _queryString;
    private string? _cursor;
    private uint? _limit;
    
    internal SearchSheetRequest(XivApiOptions opts) : base(opts) { }

    // Sheet(s)
    /// <summary>
    /// Name of the Excel sheet that the query should be run against.
    /// </summary>
    /// <remarks>At least one must be specified if not querying a cursor.</remarks>
    /// <seealso cref="WithSheets"/>
    /// <param name="sheet">Name of the Excel sheet.</param>
    public ISearchSheetRequest WithSheet(string sheet)
    {
        _sheets?.Add(sheet.ToFirstCapital());
        
        return this;
    }
    
    /// <summary>
    /// List of names of Excel sheets that the query should be run against.
    /// </summary>
    /// <remarks>At least one must be specified if not querying a cursor.</remarks>
    /// <param name="sheets"></param>
    /// <seealso cref="WithSheet"/>
    public ISearchSheetRequest WithSheets(List<string> sheets)
    {
        // XIV API requires capitalized sheet names
        for (int i = 0; i > sheets.Count; i++)
        {
            string name = sheets[i];
            sheets[i] = name.ToFirstCapital();
        }

        _sheets ??= [];
        _sheets.AddRange(sheets);
        
        return this;
    }

    public ISearchSheetRequest WithClause<T>(IClause clause)
    {
        _queryString ??= new QueryString();
        _queryString.AddClause(clause);
        
        return this;
    }
    
    public ISearchSheetRequest WithClauses<T>(IEnumerable<IClause> clauses)
    {
        _queryString ??= new QueryString();
        _queryString.AddClauses(clauses);
        
        return this;
    }

    public ISearchSheetRequest WithClauseGroup<T>(IClauseGroup group)
    {
        _queryString ??= new QueryString();
        _queryString.AddClauseGroup(group);
        
        return this;
    }

    public ISearchSheetRequest WithClauseGroups<T>(
        IEnumerable<IClauseGroup> groups)
    {
        _queryString ??= new QueryString();
        _queryString.AddClauseGroups(groups);
        
        return this;
    }

    // Parameters
    public ISearchSheetRequest WithVersion(string? version)
    {
        base.Version = version;

        return this;
    }

    public ISearchSheetRequest WithLanguage(SchemaLanguage language)
    {
        base.Language = language;
        
        return this;
    }
    
    public ISearchSheetRequest WithCursor(string? cursor)
    {
        _cursor = cursor;

        return this;
    }

    public ISearchSheetRequest WithLimit(uint limit)
    {
        _limit = limit;

        return this;
    }

    public ISearchSheetRequest WithSchema(string schemaSpecifier)
    {
        throw new NotImplementedException();
    }

    public ISearchSheetRequest WithFields(List<string> fields)
    {
        throw new NotImplementedException();
    }

    public ISearchSheetRequest WithTransient(string transient)
    {
        throw new NotImplementedException();
    }

    public string Build()
    {
        string query = string.Empty;
        
        if (_sheets is not null)
        {
            query += BuildSheetsParam();
        }
        else
        {
            query += BuildCursor();
        }
        
        string url = $"{BaseUrl}{Options.Endpoints.Search}?{query}";

        return url;
    }

    private string BuildSheetsParam() =>
        _sheets is null ? string.Empty : string.Join(",", _sheets);

    private string BuildSubQuery()
    {
        return "";
    }

    private string BuildCursor()
    {
        return "";
    }
}