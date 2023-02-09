# C#重构的ChatGPT API


[![GitHub stars](https://img.shields.io/github/stars/XiaozhongMiao/ChatGPTApi-CSharp.svg)](https://github.com/XiaozhongMiao/ChatGPTApi-CSharp/stargazers)
[![GitHub forks](https://img.shields.io/github/forks/XiaozhongMiao/ChatGPTApi-CSharp.svg)](https://github.com/XiaozhongMiao/ChatGPTApi-CSharp/network)
[![GitHub license](https://img.shields.io/github/license/XiaozhongMiao/ChatGPTApi-CSharp.svg)](https://github.com/XiaozhongMiao/ChatGPTApi-CSharp/blob/master/LICENSE)


自己写着玩的，主要是解决了国内无法直接访问ChatGPT的问题

APIKey也放在了后端，防止API泄露被白嫖的风险~

2023-02-09 第一个版本，实现了简单的一些逻辑

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

# 运行示例

使用的参数

| key    | value                                         |
| --------| -------------------------------------------|
| user    | asd                                        |
| msg     | 要怎样变得很有钱                            |

[![N|Solid](https://static.kkws.vip/github/chatgpt/demo.jpg)](https://github.com/XiaozhongMiao/ChatGPTApi-CSharp)

