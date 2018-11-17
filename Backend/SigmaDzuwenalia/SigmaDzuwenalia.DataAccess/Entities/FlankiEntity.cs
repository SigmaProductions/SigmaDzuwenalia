using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaDzuwenalia.DataAccess.Entities
{
    public class FlankiEntity
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public float coordinate_x { get; set; }
        public float coordinate_y { get; set; }
        public string name { get; set; }
            
    }
}
