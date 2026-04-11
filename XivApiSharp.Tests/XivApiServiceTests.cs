using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Options;
using XivApiSharp.Client.Services;
using Microsoft.Extensions.DependencyInjection;
using XivApiSharp.Client.Infrastructure.Requests.Steps;

namespace XivApiSharp.Tests;
public class XivApiServiceTests
{
    // Equal To (string) Clause Test:
    private const string EqualToSpecifier = "Name";
    private const string EqualToValue = "Tank You, Paladin I";
    private const string EqualToExpectedValue = 
        "Name=\"Tank+You%2c+Paladin+I\"";
    private const string EqualToSheet = "Achievement";
    
    // Partially Equal To (string) Clause Test:
    private const string PartiallyEqualToSpecifier = "Name";
    private const string PartiallyEqualToValue = "Tank You, Paladin";
    private const string PartiallyEqualToExpectedValue =
        "Name~\"Tank+You%2c+Paladin\"";
    private const string PartiallyEqualToSheet = "Achievement";
    
    // Greater Than (string) Clause Test:
    private const string GreaterThanSpecifier = "SomeField";
    private const string GreaterThanValue = "5";
    private const string GreaterThanExpectedValue =
        "SomeField>\"5\"";
    // TODO: Double check that strings are converted to ints in the actual API
    
    // Storage Variables
    private readonly IServiceCollection _serviceCollection = new ServiceCollection();
    private ServiceProvider _provider;
    private XivApiService _service;
    private XivApiOptions _options;
    private readonly HttpClient _client = new();
    
    [OneTimeSetUp]
    public void Setup()
    {
        _serviceCollection.AddXivApiService();
        _provider = _serviceCollection.BuildServiceProvider();
        _service = _provider.GetRequiredService<XivApiService>();
        _options = _provider.GetRequiredService<XivApiOptions>();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        _provider.Dispose();
        _client.Dispose();
    }

    [Test]
    public void NewClause_StringEqualTo_BuildsCorrectly()
    {
        Clause clause = XivApiService.NewClause()
            .WhereField(EqualToSpecifier)
            .Is()
            .EqualTo(EqualToValue);

        Assert.That(clause.ToString(), 
            Is.EqualTo(EqualToExpectedValue));
    }

    [Test]
    public void NewClause_StringPartiallyEqualTo_BuildsCorrectly()
    {
        Clause clause = XivApiService.NewClause()
            .WhereField(PartiallyEqualToSpecifier)
            .Is()
            .PartiallyEqualTo(PartiallyEqualToValue);

        Assert.That(clause.ToString(), 
            Is.EqualTo(PartiallyEqualToExpectedValue));
    }

    [Test]
    public void NewClause_StringGreaterThan_BuildsCorrectly()
    {
        Clause clause = XivApiService.NewClause()
            .WhereField(GreaterThanSpecifier)
            .Is()
            .PartiallyEqualTo(GreaterThanValue);
        
        Assert.That(clause.ToString(),
            Is.EqualTo(GreaterThanExpectedValue));
    }
    
    [Test]
    public void NewRequest_Search_BuildsCorrectly()
    {
        Clause clause = XivApiService.NewClause()
            .WhereField(EqualToSpecifier)
            .Is()
            .EqualTo(EqualToValue);

        ISearchSheetRequestStep request = _service.NewRequestBuilder()
            .AsSearch()
            .WithSheet(EqualToSheet);
    }
}