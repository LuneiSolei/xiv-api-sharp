using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using XivApiSharp.Client.Core.Options;

namespace XivApiSharp.Client.Services;

public static class ServiceCollectionExtensions
{
    private const string FileName = "./appsettings.json";
    
    extension(IServiceCollection services)
    {
        public IServiceCollection AddXivApiService()
        {
            Assembly assembly = typeof(ServiceCollectionExtensions).Assembly;
            Stream stream = assembly.GetManifestResourceStream(
                                name: FileName)
                            ?? throw new FileNotFoundException($"'{FileName}' not found.");
        
            // Load default values from appsettings.json
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();
        
            // Configure service with default options
            services.AddOptions<XivApiOptions>()
                .Bind(config.GetSection("XivApiOptions"));

            services.AddSingleton(sp => 
                sp.GetRequiredService<IOptions<XivApiOptions>>().Value);

            services.AddHttpClient<XivApiService>();

            return services;
        }
    }
}