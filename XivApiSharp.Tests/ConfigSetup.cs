using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using XivApiSharp.Tests.Options;

namespace XivApiSharp.Tests;

[SetUpFixture]
public class ConfigSetup
{
    public static TestConfig TestConfig { get; } = new();

    static ConfigSetup()
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