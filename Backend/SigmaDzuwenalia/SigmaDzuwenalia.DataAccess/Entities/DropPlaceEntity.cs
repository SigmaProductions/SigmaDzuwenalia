using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaDzuwenalia.DataAccess.Entities
{
    public class DropPlaceEntity
    {
        public int Id { get; set; }
        public double XCoordinate { get; set; }
        public double YCoordinate { get; set; }
        public string DropType { get; set; }
        public DateTime DropDate { get; set; }
    }
}
