using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using XivApiSharp.Client.Application;
using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Tests.Options;
using XivApiSharp.Tests.Options.Schemas.ClauseTests;

namespace XivApiSharp.Tests;

[SetUpFixture]
internal static class TestSetup
{
    private const string FileName = "appsettings.json";
    private static IConfiguration _config = null!;
    internal static readonly IServiceProvider ServiceContainer;
    internal static TopLevelOptions Options { get; }
    internal static readonly IXivApiService Service;

    static TestSetup()
    {
        // Create dependency injection container with configure custom testing
        // options
        ConfigureOptions();
        ServiceContainer = new ServiceCollection()
            .Configure<TopLevelOptions>(_config.GetSection("TestingOptions"))
            .AddXivApiService()
            .BuildServiceProvider();

        // Store and validate options from DI container
        Options = ServiceContainer
            .GetRequiredService<IOptions<TopLevelOptions>>().Value;
        ValidateOptions();

        // Store XivApiService
        Service = ServiceContainer.GetRequiredService<XivApiService>();
    }

    private static void ConfigureOptions()
    {
        // Get our current assembly
        var assembly = Assembly.GetExecutingAssembly();

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
            Options,
            new ValidationContext(Options),
            validationResults,
            validateAllProperties: true);

        if (isValid) return;

        string errors = string.Join(", ", validationResults.Select(r => r.ErrorMessage));
        throw new InvalidOperationException($"TestingOptions is invalid: {errors}");
    }

    internal static IClause<TValue> BuildClause<TOptions, TValue>(TOptions options, TValue value)
        where TOptions : BaseClauseOptions
    {
        return Service.NewClause<TValue>()
            .WithDecorator(options.Decorator)
            .WithSpecifier(options.Specifier)
            .WithLanguage(options.Language)
            .WithOperator(options.Operator)
            .WithValue(value)
            .Build();
    }
}