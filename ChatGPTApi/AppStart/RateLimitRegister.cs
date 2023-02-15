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
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();//IP限制
            services.AddSingleton<IClientPolicyStore, MemoryCacheClientPolicyStore>();//客户端限制
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();//计数器
            services.AddInMemoryRateLimiting();

            //redis
            //services.AddSingleton<IIpPolicyStore, DistributedCacheIpPolicyStore>();//IP限制
            //services.AddSingleton<IClientPolicyStore, DistributedCacheClientPolicyStore>();//客户端限制
            //services.AddSingleton<IRateLimitCounterStore, DistributedCacheRateLimitCounterStore>();//计数器
            //services.AddRedisRateLimiting();

            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        }
    }
}
