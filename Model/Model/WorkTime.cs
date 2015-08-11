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
        //��Աid
        public int MemberID { get; set; }
        //�ɻ��վ��
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
        public int? SubMemberID { get; set; }
        //ɾ�����
        public byte isDel { get; set; }

        public virtual Member Member { get; set; }

        public virtual Member SubMember { get; set; }

        public virtual Station Station { get; set; }
    }
}
