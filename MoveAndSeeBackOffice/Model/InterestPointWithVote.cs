using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveAndSeeBackOffice.Model
{
    class InterestPointWithVote
    {
        [JsonProperty("InterestPoint")]
        public InterestPoint InterestPoint { get; set; }

        [JsonProperty("Moyenne")]
        public int Moyenne { get; set; }
    }
}