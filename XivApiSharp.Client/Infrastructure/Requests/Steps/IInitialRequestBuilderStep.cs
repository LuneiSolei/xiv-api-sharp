namespace XivApiSharp.Client.Infrastructure.Requests.Steps;

public interface IInitialRequestBuilderStep
{
    ISearchSheetRequestStep AsSearch();
}