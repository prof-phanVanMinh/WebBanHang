using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebBanHang.Models
{
    public class User
    {

        [Key]
        public string UserName { set; get; }
        public string PassWord { set; get; }
    }
}