using System.ComponentModel;

namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public class WorkTime
    {
        public WorkTime()
        {
            Members = new HashSet<Member>();
        }
        [DisplayName("工时编号")]
        public int WorkTimeID { get; set; }
        //成员id

        //干活的站点
        //todo 虽然不知道为什么,这种导航属性会直接绑定在模型上,比如stationid赋值后,station也就有了
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

        //删除标记
        public byte isDel { get; set; }

        public virtual ICollection<Member> Members { get; set; }



        public virtual Station Station { get; set; }
    }
}
