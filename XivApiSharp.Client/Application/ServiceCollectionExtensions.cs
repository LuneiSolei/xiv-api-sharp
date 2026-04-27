using System.Net.Http.Headers;
using System.Reflection;
using System.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Client.Core.InternalDependencies;
using XivApiSharp.Client.Core.Options;
using XivApiSharp.Client.Infrastructure.Clauses;

namespace XivApiSharp.Client.Application;

/// <summary>
/// Provides extension methods for configuring XIV API related services in the
/// dependency injection container.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// The name of the file used for storing configuration options.
    /// </summary>
    private const string FileName = "appsettings.json";

    /// <summary>
    /// Internal storage for the loaded configuration options.
    /// </summary>
    private static IConfiguration? _config;

    extension(IServiceCollection services)
    {
        /// <summary>
        /// Registers XivApiService using an optional, externally provided
        /// configuration.
        /// </summary>
        /// <param name="config">
        /// The configuration instance to load the options from.
        /// </param>
        /// <remarks>
        /// This is an optional overload intended for users to provide their own
        /// configuration instance in the event that the default one no longer
        /// works or does not meet the user's needs.
        /// </remarks>
        /// <returns>
        /// The application service collection for method chaining.
        /// </returns>
        /// <seealso cref="XivApiService"/>
        /// <seealso cref="XivApiOptions"/>
        public IServiceCollection AddXivApiService(IConfiguration config)
        {
            _config = config;
            services.RegisterCommon();

            return services;
        }

        /// <summary>
        /// Registers XivApiService using the built-in options.
        /// </summary>
        /// <returns>
        /// The application service collection for method chaining.
        /// </returns>
        /// <seealso cref="XivApiService"/>
        public IServiceCollection AddXivApiService()
        {
            IServiceCollection.BuildConfig();
            services.RegisterCommon();

            return services;
        }

        /// <summary>
        /// Helper for building the configuration options for XivApiService.
        /// </summary>
        /// <exception cref="MissingManifestResourceException">
        /// Thrown when the manifest resource for the configuration options
        /// could not be found in the assembly.
        /// </exception>
        /// <exception cref="FileLoadException">
        /// Thrown when the manifest resource file was found, but the stream
        /// could not be loaded.
        /// </exception>
        private static void BuildConfig()
        {
            // Get our current assembly
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Using the default namespace, get the full resource name. Throw
            // exception if not found.
            string resourceName = assembly.GetManifestResourceNames()
                .FirstOrDefault(name =>
                    name.EndsWith(FileName, StringComparison.OrdinalIgnoreCase))
                ?? throw new MissingManifestResourceException(
                    $"Required manifest resource ending with '{FileName}' " +
                    $"could not be found");

            // From the full resource name, get the file stream
            using Stream stream = assembly.GetManifestResourceStream(resourceName)
                ?? throw new FileLoadException(
                    $"Stream for required manifest resource '{resourceName}' " +
                    $"could not be loaded");

            // Load values
            _config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();
        }

        /// <summary>
        /// Helper for registering all common resources to the DI container
        /// regardless of configuration options source.
        /// </summary>
        /// <exception cref="NullReferenceException">
        /// Thrown when the IConfiguration options for XivApiService is null.
        /// </exception>
        private void RegisterCommon()
        {
            if (_config is null)
            {
                throw new NullReferenceException(
                    "The provided IConfiguration for XivApiService is null.");
            }

            services
                // Configure options
                .Configure<XivApiOptions>(_config.GetSection("XivApiOptions"))

                // Inject dependencies
                .AddScoped<IClauseFactory, ClauseFactory>()
                .AddTransient(typeof(IClauseBuilder<>), typeof(ClauseBuilder<>))
                .AddScoped<IInternalDependencies, InternalDependencies>(sp =>
                {
                    IClauseFactory clauseFactory = sp.GetRequiredService<IClauseFactory>();
                    return new InternalDependencies(clauseFactory);
                })

                // Add HttpClient
                .AddHttpClient<XivApiService>((sp, client) =>
                {
                    XivApiOptions opts = sp
                        .GetRequiredService<IOptions<XivApiOptions>>().Value;

                    client.BaseAddress =
                        new Uri($"{opts.Scheme}://{opts.BaseUrl}");
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue(
                            "application/json"));
                });
        }
    }
}