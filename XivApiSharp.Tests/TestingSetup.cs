using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using XivApiSharp.Client.Application;
using XivApiSharp.Tests.Options;

namespace XivApiSharp.Tests;

[SetUpFixture]
internal class TestingSetup
{
    private const string FileName = "appsettings.json";
    private static IConfiguration _config = null!;
    internal static TestingOptions TestingOptions { get; set; }
    internal readonly static XivApiService ApiService;

    static TestingSetup()
    {
        ConfigureOptions();
        IServiceProvider serviceProvider = new ServiceCollection()
            .Configure<TestingOptions>(_config.GetSection("TestingOptions"))
            .AddXivApiService()
            .BuildServiceProvider();
        
        // Store and validate options from DI container
        TestingOptions = serviceProvider
            .GetRequiredService<IOptions<TestingOptions>>().Value;
        ValidateOptions();
        
        // Store XivApiService
        ApiService = serviceProvider.GetRequiredService<XivApiService>();
    }

    private static void ConfigureOptions()
    {
        // Get our current assembly
        Assembly assembly = Assembly.GetExecutingAssembly();
        
        // Using the default namespace, get the full resource name. Throw 
        // exception if not found.
        string resourceName = assembly.GetManifestResourceNames()
            .FirstOrDefault(name => 
                name.EndsWith(FileName, StringComparison.OrdinalIgnoreCase))
            ?? throw new MissingManifestResourceException(
                $"No manifest resource ending with '{FileName}' could be " + 
                $"found.");
        
        // From the full resource name, get the file stream
        using Stream stream = assembly.GetManifestResourceStream(resourceName)
            ?? throw new MissingManifestResourceException(
                $"Stream for required manifest resource '{resourceName}' " +
                $"not found");
        
        _config = new ConfigurationBuilder()
            .AddJsonStream(stream)
            .Build();
    }

    private static void ValidateOptions()
    {
        // Require all values be filled in appsettings.json
        List<ValidationResult> validationResults = [];
        bool isValid = Validator.TryValidateObject(
            TestingOptions,
            new ValidationContext(TestingOptions),
            validationResults,
            validateAllProperties: true);
        
        if (isValid) return;
        
        string errors = string.Join(", ", validationResults.Select(r => r.ErrorMessage));
        throw new InvalidOperationException($"TestingOptions is invalid: {errors}");
    }
}