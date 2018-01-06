using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveAndSeeBackOffice.Model
{
    class InterestPoint : Point
    {
        public long IdInterestPoint { get; set; }
        public string Name { get; set; }
        public ICollection<Description> Description { get; set; }
    }
}