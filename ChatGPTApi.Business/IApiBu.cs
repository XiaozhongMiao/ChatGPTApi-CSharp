using ChatGPTApi.Model;
using ChatGPTApi.Model.Resp;

namespace ChatGPTApi.Business
{
    public interface IApiBu
    {
        ResultMessage<GPTResponse> getText(string requestText);
    }
}