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
        [DisplayName("��ʱ���")]
        public int WorkTimeID { get; set; }
        //��Աid

        //�ɻ��վ��
        //todo ��Ȼ��֪��Ϊʲô,���ֵ������Ի�ֱ�Ӱ���ģ����,����stationid��ֵ��,stationҲ������
        public int StationID { get; set; }
        //��ʼʱ��
        public DateTime StartTime { get; set; }
        //����ʱ��
        public DateTime EndTime { get; set; }
        //��������
        public string WorkProgram { get; set; }
        //��ע
        public string Remarks { get; set; }
        //��ʱ

        public double? WorkTimeValue { get; set; }
        //�Ǽ�ʱ��
        public DateTime? SubTime { get; set; }
        //�Ǽ���id

        //ɾ�����
        public byte isDel { get; set; }

        public virtual ICollection<Member> Members { get; set; }



        public virtual Station Station { get; set; }
    }
}
