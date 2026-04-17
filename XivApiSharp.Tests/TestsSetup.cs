using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XivApiSharp.Client.Application;
using XivApiSharp.Tests.Options;

namespace XivApiSharp.Tests;

[SetUpFixture]
public class TestsSetup
{
    public static TestConfig TestConfig { get; } = new();
    public readonly static IServiceProvider ServiceProvider;

    static TestsSetup()
    {
        ConfigureOptions();
        ServiceProvider = new ServiceCollection()
            .AddXivApiService()
            .BuildServiceProvider();
    }

    private static void ConfigureOptions()
    {
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        config.GetSection(nameof(TestConfig)).Bind(TestConfig);
        
        // Require all values be filled in appsettings.json
        List<ValidationResult> validationResults = [];
        bool isValid = Validator.TryValidateObject(
            TestConfig,
            new ValidationContext(TestConfig),
            validationResults,
            validateAllProperties: true);
        
        if (isValid) return;
        
        string errors = string.Join(", ", validationResults.Select(r => r.ErrorMessage));
        throw new InvalidOperationException($"TestConfig is invalid: {errors}");
    }
}