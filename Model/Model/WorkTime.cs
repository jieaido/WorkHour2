namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkTime")]
    public partial class WorkTime
    {
        
        public int WorkTimeID { get; set; }

        public int MemberID { get; set; }

        public int StationID { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }
        public string WorkProgram { get; set; }

        public string Remarks { get; set; }


        public double? WorkTimeValue { get; set; }

        public DateTime? SubTime { get; set; }

        public int? SubMemberID { get; set; }

        public byte isDel { get; set; }

        public virtual Member Member { get; set; }

        public virtual Member SubMember { get; set; }

        public virtual Station Station { get; set; }
    }
}
