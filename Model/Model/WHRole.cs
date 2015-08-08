using System.Collections.Generic;

namespace Model
{
    public class WhRole
    {
        public WhRole()
        {
            Permissions=new HashSet<Permission>();
        }
        public int WhRoleId { get; set; }
        public string RoleName { get; set; }
        public  virtual ICollection<Permission> Permissions { get; set; }
         
    }
}