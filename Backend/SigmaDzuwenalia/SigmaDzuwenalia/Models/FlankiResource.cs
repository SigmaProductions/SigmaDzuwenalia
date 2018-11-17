using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SigmaDzuwenalia.Models
{
    public class FlankiResource
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public double coordinate_x { get; set; }
        public double coordinate_y { get; set; }
        public string name { get; set; }
        public int counter { get; set; }
    }
}