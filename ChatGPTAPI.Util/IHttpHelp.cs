using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPTAPI.Util
{
    public interface IHttpHelp
    {
        string Post(string url, string parameter, string token);
    }
}
