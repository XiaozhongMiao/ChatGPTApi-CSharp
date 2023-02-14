using ChatGPTApi.Business;
using ChatGPTApi.Business.Impl;
using ChatGPTApi.Model.Config;
using ChatGPTAPI.Util;
using ChatGPTAPI.Util.Impl;

namespace ChatGPTApi.AppStart
{
    public static class DependencyInject
    {
        private static IServiceCollection _service;
        private static WebApplicationBuilder _builder;
        public static void Regist(WebApplicationBuilder builder)
        {
            _builder = builder;
            _service = _builder.Services;
            RegistConfig();
            RegistUtil();
            RegistBo();
            RegistDao();
          
        }
        //注册业务层
        private static void RegistBo()
        {
            _service.AddSingleton<IApiBu, ApiBu>();
        }
        //注册数据层
        private static void RegistDao()
        {
            
        }
        //注册配置文件
        private static void RegistConfig()
        {
            _service.AddOptions();
            _service.Configure<ApiConfig>(_builder.Configuration.GetSection("ApiConfig"));
            //_builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
            //{
            //    config.AddJsonFile("ratelimit.json", optional: true, reloadOnChange: true);
            //});
        }
        //注册工具
        private static void RegistUtil()
        {
            _service.AddSingleton<IHttpHelp, HttpHelp>();
            _service.AddHttpClient();
            _service.AddMemoryCache();
            
        }

     
    }
}
