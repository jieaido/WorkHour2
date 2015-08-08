using System.Collections.Generic;

namespace Model
{
    public class Permission
    {
        public Permission()
        {
            WhRoles=new HashSet<WhRole>();
        }
        public int  PermissionId { get; set; }  
        public string PermissionName { get; set; }
        public string ControllName { get; set; }
        public string ActionName  { get; set; }
        public string ActionType { get; set; }
        public virtual ICollection<WhRole> WhRoles { get; set; }

    }
}