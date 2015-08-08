using System.Collections.Generic;

namespace Model
{
    public class WhRole
    {
        public int WhRoleId { get; set; }
        public string RoleName { get; set; }
        public ICollection<Permission> Permissions { get; set; }
         
    }
}