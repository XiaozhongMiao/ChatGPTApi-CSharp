using ChatGPTApi.Business;
using ChatGPTApi.Controllers.Base;
using ChatGPTApi.Model;
using ChatGPTApi.Model.Resp;
using Microsoft.AspNetCore.Mvc;

namespace ChatGPTApi.Controllers
{
    public class ChatGPTController : BaseController
    {
        private readonly IApiBu _apibu;
        public ChatGPTController(IApiBu apibu)
        {
            _apibu = apibu;
        }
        [HttpPost]
        public async Task<IActionResult> chat(string msg)
        {
            ResultMessage<GPTResponse> res =   _apibu.getText(msg);

            return Json(res);
        }
    }
}
