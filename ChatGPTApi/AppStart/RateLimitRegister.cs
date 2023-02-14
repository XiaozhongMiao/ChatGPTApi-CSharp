using AspNetCoreRateLimit;

namespace ChatGPTApi.AppStart
{
    public static class RateLimitRegister
    {
        public static void Regist(WebApplicationBuilder builder)
        {
            IServiceCollection services = builder.Services;
            builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("ratelimit.json", optional: true, reloadOnChange: true);//拦截单独的配置
            });
            services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));

            services.AddInMemoryRateLimiting();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        }
    }
}
