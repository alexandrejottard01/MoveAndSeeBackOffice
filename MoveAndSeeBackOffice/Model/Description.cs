using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveAndSeeBackOffice.Model
{
    class Description
    {
        public long IdDescription { get; set; }
        public string Explication { get; set; }
        public string IdUser { get; set; }
        public long IdInterestPoint { get; set; }
        public InterestPoint IdInterestPointNavigation { get; set; }
        public User IdUserNavigation { get; set; }
    }
}