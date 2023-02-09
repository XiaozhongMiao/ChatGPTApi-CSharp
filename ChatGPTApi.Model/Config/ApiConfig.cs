using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPTApi.Model.Config
{
    public class ApiConfig
    {
        public string? apiUrl { get; set; }
        public string? apiKey { get; set; }
        public int? limit { get; set; }
        public int? limitTime { get; set; }
    }
}
