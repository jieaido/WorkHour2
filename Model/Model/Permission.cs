namespace Model
{
    public class Permission
    {
        public int  PermissionId { get; set; }  
        public string PermissionName { get; set; }
        public string ControllName { get; set; }
        public string ActionName  { get; set; }
        public string ActionType { get; set; }

    }
}