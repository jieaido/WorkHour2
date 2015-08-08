using System.Data.Entity;
using Model;

namespace WorkHour.Models
{
    public class WHDB : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public WHDB()
            : base("name=DbWHDB")
        {

        }

        public DbSet<Team> Teams { get; set; }


        public DbSet<Member> Members   { get; set; }

        public DbSet<Station> Stations { get; set; }
        public DbSet<WorkSet> WorkSets { get; set; }
        public DbSet<WorkTime> WorkTimes { get; set; }
        public DbSet<Account> Accounts { get; set; } 
       
        public DbSet<Permission> Permissions { get; set; } 

        public DbSet<WhRole> WhRoles { get; set; } 

    }
}
