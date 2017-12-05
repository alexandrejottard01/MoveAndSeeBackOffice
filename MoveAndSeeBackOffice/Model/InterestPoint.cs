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
        public long IdInterestPoint { get; set; }
        public string IdUser { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Name { get; set; }
        public DateTime DateCreation { get; set; }
        public ICollection<Description> Description { get; set; }
        public User IdUserNavigation { get; set; }
    }
}