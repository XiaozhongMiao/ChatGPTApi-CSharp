using ChatGPTApi.Model;
using ChatGPTApi.Model.Config;
using ChatGPTApi.Model.Resp;
using ChatGPTAPI.Util;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPTApi.Business.Impl
{
    public class ApiBu:IApiBu
    {
        private readonly IHttpHelp _httpHelp;
        private readonly ApiConfig _config;
        public ApiBu(IHttpHelp httpHelp,IOptions<ApiConfig> options)
        {
            _httpHelp = httpHelp;
            _config = options.Value;
        }
        public ResultMessage<GPTResponse> getText(string requestText)
        {
            ResultMessage<GPTResponse> res = new ResultMessage<GPTResponse>();
            if (!string.IsNullOrEmpty(requestText))
            {
                GPTRequest reqParam = new GPTRequest();
                reqParam.prompt = requestText;
                reqParam.model = string.IsNullOrEmpty(_config.model)? "text-davinci-003":_config.model;
                string jsonParam = JsonConvert.SerializeObject(reqParam) ;
                string resp = _httpHelp.Post(_config.apiUrl, jsonParam, _config.apiKey);
                //string resp = "{\"id\":\"cmpl - 6ht7grnaRlQMqNzqCtyxu8iE4ZWP0\",\"object\":\"text_completion\",\"created\":1675918016,\"model\":\"text - davinci - 003\",\"choices\":[{\"text\":\"\n\n今天，我和家人一起去公园玩。天气很好，阳光明媚，空气清新。我们在公园里散步，走到一片绿草地上，我们就坐下来，欣赏着美丽的风景。我们还在湖边捡贝壳，在树下采摘果实，在草地上追逐着蝴蝶。我们玩得很开心，时间过得很快。当我们累了，就坐在草地上，看着云朵在天上飘，看着鸟儿在树上唱歌，看着蝴蝶在花丛中飞舞。我们玩得很开心，美好的一天就这样结束了。\",\"index\":0,\"logprobs\":null,\"finish_reason\":\"stop\"}],\"usage\":{\"prompt_tokens\":14,\"completion_tokens\":371,\"total_tokens\":385}}";
                //string resp = "{\"error\": {\"message\": \"Incorrect API key provided: sk-FwK4e***************************************ooHs. You can find your API key at https://platform.openai.com/account/api-keys.\", \"type\": \"invalid_request_error\", \"param\": null,\"code\": \"invalid_api_key\" } } ";
                //防止JSON返回数据处理不到位，返回一些奇怪的东西，我这直接给处理一下，反正成功的肯定会返回一个标准的json
                try
                {
                    if (!string.IsNullOrEmpty(resp))
                    {
                        JObject joAll = (JObject)JsonConvert.DeserializeObject(resp);
                        JArray choicesArr = joAll["choices"] == null ? null : (JArray)joAll["choices"];
                        JObject errorObj= joAll["error"] == null ? null : (JObject)joAll["error"];
                        if (choicesArr != null)
                        {
                            GPTResponse gResp= new GPTResponse();
                            gResp.texts = new List<string>();
                            foreach (JObject choice in choicesArr)
                            {
                                string txt = choice["text"] == null ? null : choice["text"].ToString();
                                if (!string.IsNullOrEmpty(txt))
                                {
                                    gResp.texts.Add(txt);

                                }
                                
                            }
                            res.code = 0;
                            res.msg = "success";
                            res.data = gResp;
                        }
                        else if (errorObj != null)
                        {
                            res.code = -3000;
                            res.msg = errorObj["message"]==null?"API error": errorObj["message"].ToString();
                        }
                        else
                        {
                            res.code = -2003;
                            res.msg = "Unvailable JSON Object";
                        }


                    }
                    else
                    {
                        res.code = -2002;
                        res.msg = "OpenAI Response is Empty";
                    }
                    

                }
                catch (Exception e)
                {
                    res.code = -2001;
                    res.msg = "OpenAI Response Exception";
                }
               
            }
            else
            {
                res.code = -1000;
                res.msg = "Parameter is not null";
            }

            return res;
        }
    }
}
