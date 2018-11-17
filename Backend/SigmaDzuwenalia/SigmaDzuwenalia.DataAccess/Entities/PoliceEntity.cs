using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaDzuwenalia.DataAccess.Entities
{
    public class PoliceEntity
    {
        public int Id { get; set; }
        public double XCoordinate { get; set; }
        public double YCoordinate { get; set; }
        public int PatrolSize { get; set; }
        public DateTime PatrolDate { get; set; }
    }
}
