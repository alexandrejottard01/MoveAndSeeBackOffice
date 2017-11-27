using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveAndSeeBackOffice.Model
{
    class Token
    {
        public static Token tokenCurrent;

        [JsonProperty("access_token")]
        public string  TokenString { get; set; }

        [JsonProperty("expires_in")]
        public int TimeExpiration { get; set; }
    }
}
