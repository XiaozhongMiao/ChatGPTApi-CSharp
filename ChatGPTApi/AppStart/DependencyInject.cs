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
            RegistBo();
            RegistDao();
            RegistConfig();
            RegistUtil();
        }

        private static void RegistBo()
        {
            _service.AddSingleton<IApiBu, ApiBu>();
        }
        private static void RegistDao()
        {
            
        }
        private static void RegistConfig()
        {
            _service.AddOptions();
            _service.Configure<ApiConfig>(_builder.Configuration.GetSection("ApiCOnfig"));

        }

        private static void RegistUtil()
        {
            _service.AddSingleton<IHttpHelp, HttpHelp>();
            _service.AddHttpClient();
        }
    }
}
