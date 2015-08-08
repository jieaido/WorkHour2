using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WorkSet
    {

        public int WorkSetID { get; set; }
        public string WorkSetName { get; set; }
        public float WorkSetValue { get; set; }

        public int TeamId { get; set; } 

        public virtual Team Team { get; set; }
        



    }
}
