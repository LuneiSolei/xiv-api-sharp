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

public static class ServiceCollectionExtensions
{
    private const string FileName = "appsettings.json";
    private static IConfiguration _config = null!;
    
    extension(IServiceCollection services)
    {
        public IServiceCollection AddXivApiService(IConfiguration config)
        {
            _config = config;
            services.RegisterCommon();
            
            return services;
        }
        
        public IServiceCollection AddXivApiService()
        {
            services.BuildConfig();
            services.RegisterCommon();

            return services;
        }

        private void BuildConfig()
        {
            // Get our current assembly
            Assembly assembly = Assembly.GetExecutingAssembly();
            
            // Using the default namespace, get the full resource name. Throw
            // exception if not found.
            string resourceName = assembly.GetManifestResourceNames()
                .FirstOrDefault(name => 
                    name.EndsWith(FileName, StringComparison.OrdinalIgnoreCase))
                ?? throw new MissingManifestResourceException(
                    $"No manifest resource ending with {FileName}' could be " +
                    $"found");

            // From the full resource name, get the file stream
            using Stream stream = assembly.GetManifestResourceStream(resourceName)
                ?? throw new MissingManifestResourceException(
                    $"Stream for required manifest resource '{resourceName}' " +
                    $"not found");
            
            // Load values
            _config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();
        }

        private void RegisterCommon()
        {
            services
                // Configure options
                .Configure<XivApiOptions>(_config.GetSection("XivApiOptions"))
                
                // Add HttpClient 
                .AddHttpClient<XivApiService>((sp, client) =>
                {
                    XivApiOptions opts = sp
                        .GetRequiredService<IOptions<XivApiOptions>>().Value;
                    
                    client.BaseAddress = new Uri($"{opts.Scheme}://{opts.BaseUrl}");
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                })
                .Services
                    
                // Inject dependencies
                .AddScoped<IClauseFactory, ClauseFactory>()
                .AddScoped<IInternalDependencies, InternalDependencies>(sp =>
                {
                    IClauseFactory clauseFactory = sp.GetRequiredService<IClauseFactory>();
                    return new InternalDependencies(clauseFactory);
                })
                .AddScoped<IClauseBuilder, ClauseBuilder>();
        }
    }
}