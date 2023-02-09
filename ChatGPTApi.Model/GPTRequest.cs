using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPTApi.Model
{
    public class GPTRequest
    {
        public string prompt { get; set; }
        public int max_tokens
        {
            get
            {
                return 2048;
            }
        }
        public double temperature
        {
            get
            {
                return 0.5;
            }
        }
        public int top_p
        {
            get
            {
                return 1;
            }
        }

        public int frequency_penalty { get
            {
                return 0;
            }
        }

        public int presence_penalty { get
            {
                return 0;
            }
        }

        public string model { get
            {
                return "text-davinci-003";
            }
        }
    }
}
