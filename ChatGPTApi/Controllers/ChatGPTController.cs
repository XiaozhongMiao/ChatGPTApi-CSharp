using ChatGPTApi.Business;
using ChatGPTApi.Controllers.Base;
using ChatGPTApi.Filters;
using ChatGPTApi.Model;
using ChatGPTApi.Model.Resp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ChatGPTApi.Controllers
{
    
    public class ChatGPTController : BaseController
    {
        private readonly IApiBu _apibu;
        public ChatGPTController(IApiBu apibu)
        {
            _apibu = apibu;
        }
        [HttpPost, RequestCheckFilterAttribute(alias = "chat")]
        public async Task<ResultMessage<GPTResponse>> chat([FromBody] ChatApiModel param)
        {
            ResultMessage<GPTResponse> res =   _apibu.getText(param.msg);

            return res;
        }
    }
}
