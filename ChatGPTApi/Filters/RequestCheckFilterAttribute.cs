using ChatGPTApi.Model.Config;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

namespace ChatGPTApi.Filters
{
    public class RequestCheckFilterAttribute:ActionFilterAttribute
    {
        #region 参数
        public string alias { get; set; }//方法别名，备用
        #endregion
        //运行之前进行拦截
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //base.OnResultExecuting(context);

           




        }



        //private bool canReq(HttpContext httpContext)
        //{
        //    bool res = true;
        //    //暂时先这么获取了，实在不太清楚怎么通过Attribute传进来，我先直接在这读配置了
        //    IOptions<ApiConfig> options = httpContext.RequestServices.GetService(typeof(IOptions<ApiConfig>)) as IOptions<ApiConfig>;
        //    ApiConfig config = options.Value;
        //    if (config != null)
        //    {
        //        //我这里用一个笨办法去做，不用那个AspNetCoreLimit了
        //    }


        //    return res;
        //}
    }
}
