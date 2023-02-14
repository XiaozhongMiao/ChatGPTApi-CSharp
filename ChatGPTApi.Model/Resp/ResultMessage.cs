using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPTApi.Model.Resp
{
    public class ResultMessage<T>
    {
        public int code { get; set; }
        public string msg { get; set; }
        public long timestamp { get
            {
                TimeSpan timeSpan = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                return Convert.ToInt64(timeSpan.TotalMilliseconds);
            }
        }
        public T data { get; set; }
    }

    public class ResultMessage
    {
        public int code { get; set; }
        public string msg { get; set; }
        public long timespan
        {
            get
            {
                TimeSpan timeSpan = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                return Convert.ToInt64(timeSpan.TotalMilliseconds);
            }
        }
        public object data { get
            {
                return null;
            }
        }

    }
}
