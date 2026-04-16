using System.Net.Http.Headers;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Client.Core.Options;
using XivApiSharp.Client.Infrastructure.Clauses;

namespace XivApiSharp.Client.Services;

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
            ConfigurationBuilder builder = new();

            if (File.Exists(FileName))
            {
                builder.AddJsonFile(FileName, optional: true, reloadOnChange: true);
            }
            else
            {
                Assembly assembly = typeof(ServiceCollectionExtensions).Assembly;
                string? resourceName = assembly.GetManifestResourceNames()
                    .FirstOrDefault(n => n.EndsWith(FileName, StringComparison.OrdinalIgnoreCase));

                if (resourceName is not null)
                {
                    Stream stream = assembly.GetManifestResourceStream(resourceName)
                                    ?? throw new FileNotFoundException($"Embedded resource '{resourceName}' not found.");
                    builder.AddJsonStream(stream);
                }
            }
            
            // Load default values from appsettings.json
            _config = builder.Build();
        }

        private void RegisterCommon()
        {
            services.Configure<XivApiOptions>(_config.GetSection("XivApiOptions"));
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<XivApiOptions>>().Value);
            services.ConfigureHttpClient();
            services.AddTransient<IClauseBuilder, ClauseBuilder>();
        }
        
        private void ConfigureHttpClient()
        {
            services.AddHttpClient<XivApiService>((sp, client) =>
            {
                XivApiOptions opts = sp.GetRequiredService<IOptions<XivApiOptions>>().Value;
                client.BaseAddress = new Uri(opts.BaseUrl);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            });
        }
    }
}