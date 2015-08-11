namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public  class WorkTime
    {
        
        public int WorkTimeID { get; set; }
        //成员id
        public int MemberID { get; set; }
        //干活的站点
        public int StationID { get; set; }
        //开始时间
        public DateTime StartTime { get; set; }
        //结束时间
        public DateTime EndTime { get; set; }
        //工作内容
        public string WorkProgram { get; set; }
        //备注
        public string Remarks { get; set; }
        //工时

        public double? WorkTimeValue { get; set; }
        //登记时间
        public DateTime? SubTime { get; set; }
        //登记人id
        public int? SubMemberID { get; set; }
        //删除标记
        public byte isDel { get; set; }

        public virtual Member Member { get; set; }

        public virtual Member SubMember { get; set; }

        public virtual Station Station { get; set; }
    }
}
