# C#重构的ChatGPT API


[![GitHub stars](https://img.shields.io/github/stars/XiaozhongMiao/ChatGPTApi-CSharp.svg)](https://github.com/XiaozhongMiao/ChatGPTApi-CSharp/stargazers)
[![GitHub forks](https://img.shields.io/github/forks/XiaozhongMiao/ChatGPTApi-CSharp.svg)](https://github.com/XiaozhongMiao/ChatGPTApi-CSharp/network)
[![GitHub license](https://img.shields.io/github/license/XiaozhongMiao/ChatGPTApi-CSharp.svg)](https://github.com/XiaozhongMiao/ChatGPTApi-CSharp/blob/master/LICENSE)


自己写着玩的，主要是解决了国内无法直接访问ChatGPT的问题

APIKey也放在了后端，防止API泄露被白嫖的风险~

2023-02-09 第一个版本，实现了简单的一些逻辑,基本的调用

user这个属性暂时可以随便写，我这个之后做用户的鉴权认证使用

记得做好接口防刷

另外，ApiKey请在appconfig.json里面配置一下，要不然无法使用哦，我才不会让你用我的Key呢~

启动报错的话，请下载.NET6.0 RunTime哦 https://dotnet.microsoft.com/en-us/download/dotnet/6.0

# 请求示例

Request URL:

https://example.com/api/test/ChatGPT?msg=requestText

Curl:

curl -X 'POST' \
  'https://example.com/api/test/ChatGPT?msg=requestText' \
  -H 'accept: */*' \
  -d ''

# 请求参数

| key    | 含义                                         |必填   |
| --------| -------------------------------------------|-----|
| user    | 用户的key，后续做认证使用，现在无用途         |   Y  |
| msg     | 要发送的文本，如：如何让自己变得更帅          |   Y  |

#返回值
| key     | 类型       | 含义                                       |
| --------|------------|-------------------------------------------|
| code    |Number      | 错误码                                     |
| msg     |String      | 报错信息                                   |
| timespan|Number      | 请求的时间戳（服务器时间）                   |
| data    |Object      | 数据结果                                   |

data里面的数据

| key     | 类型       | 含义                                       |
| --------|-----------|-------------------------------------------|
| texts   |Array      | 返回的字符串数组String类型                  |


# 错误代码

| 错误码    | 含义                                                 |
| ---------| -----------------------------------------------------|
| 0        | 请求成功                                              |
| -1000    | 输入参数为空                                          |
| -2001    | 代码里面的JSON解析报错了，记得踹我一脚                  |
| -2002    | OpenAI的返回值是空的，应该是服务器网络的问题             |
| -2003    | JSON结构我没有处理到，踹我的时候记得提供下返回值哦~       |
| -3000    | 接口那边拒绝了，报错信息在msg里面体现哦，和我没关系>_<    |

# 运行示例

使用的参数

| key    | value                                         |
| --------| -------------------------------------------|
| user    | asd                                        |
| msg     | 要怎样变得很有钱                            |

[![N|Solid](https://static.kkws.vip/github/chatgpt/demo.jpg)](https://github.com/XiaozhongMiao/ChatGPTApi-CSharp)

