namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Station")]
    public partial class Station
    {
        public Station()
        {
            WorkTimes = new HashSet<WorkTime>();
        }

    
        public int StationID { get; set; }

        [StringLength(50)]
        public string StationName { get; set; }

        public int TeamID { get; set; }

        public virtual Team Team { get; set; }

        public virtual ICollection<WorkTime> WorkTimes { get; set; }
    }
}
