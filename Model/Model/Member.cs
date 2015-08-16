namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Member")]
    public partial class Member
    {
        public Member()
        {
            WorkTimes = new HashSet<WorkTime>();
           
        }

        public int MemberID { get; set; }

        [Required]
        [StringLength(50)]
        public string MemberName { get; set; }

       
        public int? TeamID { get; set; }

        public virtual Team Team { get; set; }

        public virtual ICollection<WorkTime> WorkTimes { get; set; }

      
    }
}
