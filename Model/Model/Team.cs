namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Team")]
    public partial class Team
    {
        public Team()
        {
            Members = new HashSet<Member>();
            Stations = new HashSet<Station>();
            WorkSets=new HashSet<WorkSet>();
        }

        public int TeamID { get; set; }

        [Required]
        [StringLength(50)]
        public string TeamName { get; set; }

        public virtual ICollection<Member> Members { get; set; }

        public virtual ICollection<Station> Stations { get; set; }

        public virtual ICollection<WorkSet> WorkSets { get; set; } 
    }
}
