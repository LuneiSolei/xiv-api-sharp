using XivApiSharp.Client.Application.Clauses;

namespace XivApiSharp.Client.Core.Requests;

public interface ISearchSheetRequest
{
    // Sheets
    ISearchSheetRequest WithSheet(string sheet);
    ISearchSheetRequest WithSheets(List<string> sheets);
    
    // Query
    ISearchSheetRequest WithClause<T>(IClause clause);
    ISearchSheetRequest WithClauses<T>(IEnumerable<IClause> clauses);
    ISearchSheetRequest WithClauseGroup<T>(IClauseGroup group);
    ISearchSheetRequest WithClauseGroups<T>(IEnumerable<IClauseGroup> groups);
    
    // Parameters
    ISearchSheetRequest WithVersion(string version);
    ISearchSheetRequest WithCursor(string cursor);
    ISearchSheetRequest WithLimit(uint limit);
    ISearchSheetRequest WithLanguage(SchemaLanguage lang); 
    ISearchSheetRequest WithSchema(string schemaSpecifier);
    ISearchSheetRequest WithFields(List<string> fields);
    ISearchSheetRequest WithTransient(string transient);

    string Build();

    /*
     * TODO: Define SchemaLanguage, SchemaSpecifier, and FilterString as used
     * by XIV API
     */
}