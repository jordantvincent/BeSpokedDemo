using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.Models
{
    public class TrackableModel 
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Process { get; set; }
    }
}
