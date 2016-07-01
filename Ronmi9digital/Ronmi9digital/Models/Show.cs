using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ronmi9digital.Models
{
    public class Show
    {
        public List<Payload> payload { get; set; }
        public int skip { get; set; }
        public int take { get; set; }
        public int totalRecords { get; set; }
    }
}