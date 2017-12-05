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
        public long IdUnknownPoint { get; set; }
        public string IdUser { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DateCreation { get; set; }
        public User IdUserNavigation { get; set; }
    }
}