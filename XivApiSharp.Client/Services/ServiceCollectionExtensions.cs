using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using XivApiSharp.Client.Core.Options;

namespace XivApiSharp.Client.Services;

public static class ServiceCollectionExtensions
{
    private const string FileName = "appsettings.json";
    
    extension(IServiceCollection services)
    {
        public IServiceCollection AddXivApiService(IConfiguration config)
        {
            ArgumentNullException.ThrowIfNull(services);
            ArgumentNullException.ThrowIfNull(config);

            services.RegisterCommon(config);

            return services;
        }
        
        public IServiceCollection AddXivApiService()
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
            IConfiguration config = builder.Build();
            services.RegisterCommon(config);

            return services;
        }
        
        private void RegisterCommon(IConfiguration config)
        {
            // Bind and register options
            services.Configure<XivApiOptions>(config.GetSection("XivApiOptions"));
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<XivApiOptions>>().Value);
            
            // Configure typed HttpClient using options
            services.AddHttpClient<XivApiService>((sp, client) =>
            {
                XivApiOptions opts = sp.GetRequiredService<IOptions<XivApiOptions>>().Value;
            });
        }
    }
}