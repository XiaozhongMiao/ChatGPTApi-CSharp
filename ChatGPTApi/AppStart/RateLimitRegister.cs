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

            //注入日配置
            services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));

            //注入计数器和规则存储

            //内存
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IClientPolicyStore, MemoryCacheClientPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();//计数器
            services.AddInMemoryRateLimiting();

            //redis
            //services.AddSingleton<IRateLimitCounterStore, DistributedCacheRateLimitCounterStore>();
            //services.AddSingleton<IIpPolicyStore, DistributedCacheIpPolicyStore>();
            //services.AddSingleton<IClientPolicyStore, DistributedCacheClientPolicyStore>();
            //services.AddRedisRateLimiting();

            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        }
    }
}
