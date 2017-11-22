using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveAndSeeBackOffice.Model
{
    class DescriptionWithVote
    {
        [JsonProperty("Description")]
        public Description Description { get; set; }

        [JsonProperty("Moyenne")]
        public int Moyenne { get; set; }
    }
}