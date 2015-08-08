using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Account
    {//todo

        public int Accountid { get; set; }
        [Required(ErrorMessage = "必须输入用户名")]    
        public string AccountName { get; set; }
        public string AccountPwd { get; set; }
        public bool IsCanLogin { get; set; }
        public bool IsAdmin { get; set; }
        public int TeamId { get; set; }
        public ICollection<WhRole> WhRoles { get; set; }    
    }
}
