using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveAndSeeBackOffice.Model
{
    class InterestPoint
    {
        [JsonProperty("IdInterestPoint")]
        public long IdInterestPoint { get; set; }

        [JsonProperty("IdUser")]
        public string IdUser { get; set; }

        [JsonProperty("Latitude")]
        public decimal Latitude { get; set; }

        [JsonProperty("Longitude")]
        public decimal Longitude { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("DateCreation")]
        public DateTime DateCreation { get; set; }

        [JsonProperty("Description")]
        public ICollection<Description> Description { get; set; }

        [JsonProperty("IdUserNavigation")]
        public User IdUserNavigation { get; set; }
    }
}