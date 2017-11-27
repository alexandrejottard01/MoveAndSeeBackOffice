using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveAndSeeBackOffice.Model
{
    class VoteInterestPoint
    {
        [JsonProperty("IsPositiveAssessment")]
        public bool IsPositiveAssessment { get; set; }

        [JsonProperty("IdUser")]
        public string IdUser { get; set; }

        [JsonProperty("IdInterestPoint")]
        public long IdInterestPoint { get; set; }

        [JsonProperty("IdInterestPointNavigation")]
        public InterestPoint IdInterestPointNavigation { get; set; }

        [JsonProperty("IdUserNavigation")]
        public User IdUserNavigation { get; set; }
    }
}