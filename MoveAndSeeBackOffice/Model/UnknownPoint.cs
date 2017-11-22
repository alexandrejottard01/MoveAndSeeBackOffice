using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveAndSeeBackOffice.Model
{
    class UnknownPoint
    {

        [JsonProperty("IdUnknownPoint")]
        public long IdUnknownPoint { get; set; }

        [JsonProperty("IdUser")]
        public long IdUser { get; set; }

        [JsonProperty("Latitude")]
        public double Latitude { get; set; }

        [JsonProperty("Longitude")]
        public double Longitude { get; set; }

        [JsonProperty("DateCreation")]
        public DateTime DateCreation { get; set; }

        [JsonProperty("IdUserNavigation")]
        public User IdUserNavigation { get; set; }
    }
}