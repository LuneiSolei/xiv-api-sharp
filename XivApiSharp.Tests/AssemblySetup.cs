using Microsoft.Extensions.Configuration;
using XivApiSharp.Tests.Options;

namespace XivApiSharp.Tests;

[SetUpFixture]
public class AssemblySetup
{
    public static TestConfig TestConfig { get; } = new();

    [OneTimeSetUp]
    public void Setup()
    {
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        config.GetSection(nameof(TestConfig)).Bind(TestConfig);
    }
}