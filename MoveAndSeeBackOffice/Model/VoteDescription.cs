using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveAndSeeBackOffice.Model
{
    class VoteDescription
    {
        [JsonProperty("IsPositiveAssessment")]
        public bool IsPositiveAssessment { get; set; }

        [JsonProperty("IdUser")]
        public long IdUser { get; set; }

        [JsonProperty("IdDescription")]
        public long IdDescription { get; set; }

        [JsonProperty("IdDescriptionNavigation")]
        public Description IdDescriptionNavigation { get; set; }

        [JsonProperty("IdUserNavigation")]
        public User IdUserNavigation { get; set; }
    }
}