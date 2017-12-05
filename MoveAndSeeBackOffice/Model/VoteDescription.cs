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
        public bool IsPositiveAssessment { get; set; }
        public string IdUser { get; set; }
        public long IdDescription { get; set; }
        public Description IdDescriptionNavigation { get; set; }
        public User IdUserNavigation { get; set; }
    }
}